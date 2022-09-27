using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesShopMVC.Application.Interfaces
{
    public interface ICustomerService
    {
        int AddCustomerAfterConfirmEmail(string userId, string userMail);
    }
}
