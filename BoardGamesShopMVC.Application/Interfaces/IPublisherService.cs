using BoardGamesShopMVC.Application.ViewModels.BoardGame;
using BoardGamesShopMVC.Application.ViewModels.Publisher;

namespace BoardGamesShopMVC.Application.Interfaces
{
    public interface IPublisherService
    {
        ListPublisherForListVm GetAllPublishers();
        ListBoardGameForListVm GetBoardGamesByPublisherId(int id);
        int AddPublisher(NewPublisherVm newPublisher);
        void DeletePublisher(int id);
        NewPublisherVm GetPublisherForEdit(int id);
        void UpdatePublisher(NewPublisherVm model);
    }
}
