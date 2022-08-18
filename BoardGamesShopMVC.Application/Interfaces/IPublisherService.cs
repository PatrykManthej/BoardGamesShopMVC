using BoardGamesShopMVC.Application.ViewModels.BoardGame;
using BoardGamesShopMVC.Application.ViewModels.Publisher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesShopMVC.Application.Interfaces
{
    public interface IPublisherService
    {
        ListPublisherForListVm GetAllPublishers();
        ListBoardGameForListVm GetBoardGamesByPublisherId(int id);
        int AddPublisher(NewPublisherVm newPublisher);
        void DeletePublisher(int id);
        void UpdatePublisher(NewPublisherVm model);
    }
}
