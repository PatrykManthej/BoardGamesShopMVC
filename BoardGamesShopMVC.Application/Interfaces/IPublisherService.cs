﻿using BoardGamesShopMVC.Application.ViewModels.BoardGame;
using BoardGamesShopMVC.Application.ViewModels.Publisher;

namespace BoardGamesShopMVC.Application.Interfaces
{
    public interface IPublisherService
    {
        ListPublisherForListVm GetAllPublishers(int pageSize, int pageNo, string searchString);
        int AddPublisher(NewPublisherVm newPublisher);
        void DeletePublisher(int id);
        NewPublisherVm GetPublisherForEdit(int id);
        void UpdatePublisher(NewPublisherVm model);
    }
}
