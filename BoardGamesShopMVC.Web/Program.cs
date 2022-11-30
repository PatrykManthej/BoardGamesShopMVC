using BoardGamesShopMVC.Application;
using BoardGamesShopMVC.Application.ViewModels.BoardGame;
using BoardGamesShopMVC.Application.ViewModels.Category;
using BoardGamesShopMVC.Application.ViewModels.Publisher;
using BoardGamesShopMVC.Domain.Model;
using BoardGamesShopMVC.Infrastructure;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<Context>(options =>
{
    options.UseSqlServer(connectionString);
    options.LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information).EnableSensitiveDataLogging();
}
    );
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<Context>();
builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddControllersWithViews();
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredUniqueChars = 1;
    options.SignIn.RequireConfirmedEmail = false;
    options.User.RequireUniqueEmail = true;
});

builder.Services.AddAuthentication().AddGoogle(options =>
{
    IConfigurationSection googleAuthNSection = builder.Configuration.GetSection("Authentication:Google");
    options.ClientId = googleAuthNSection["ClientId"];
    options.ClientSecret = googleAuthNSection["ClientSecret"];
});

builder.Services.AddTransient<IValidator<NewBoardGameVm>, NewBoardGameValidation>();
builder.Services.AddTransient<IValidator<NewPublisherVm>, NewPublisherValidation>();
builder.Services.AddTransient<IValidator<NewCategoryVm>, NewCategoryValidation>();

builder.Logging.AddFile("Logs/myLog-{Date}.txt");

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/BoardGame/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=BoardGame}/{action=Index}/{id?}");
app.MapRazorPages();

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetService<Context>();

var pendingMigrations = dbContext.Database.GetPendingMigrations();
if (pendingMigrations.Any())
{
    dbContext.Database.Migrate();
}

app.Run();
