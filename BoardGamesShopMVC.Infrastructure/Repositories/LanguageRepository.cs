using BoardGamesShopMVC.Domain.Models;

namespace BoardGamesShopMVC.Infrastructure.Repositories
{
    public class LanguageRepository
    {
        private readonly Context _context;
        public LanguageRepository(Context context)
        {
            _context = context;
        }
        public int AddLanguage(Language language)
        {
            _context.Languages.Add(language);
            _context.SaveChanges();
            return language.Id;
        }

        public void DeleteLanguage(int languageId)
        {
            var language = _context.Languages.Find(languageId);
            if (language != null)
            {
                _context.Languages.Remove(language);
                _context.SaveChanges();
            }
        }

        public Language GetLanguageById(int languageId)
        {
            var language = _context.Languages.FirstOrDefault(b => b.Id == languageId);
            return language;
        }

        public IQueryable<Language> GetAllLanguages()
        {
            var languages = _context.Languages;
            return languages;
        }
    }
}
