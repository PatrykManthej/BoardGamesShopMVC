﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using BoardGamesShopMVC.Application.Interfaces;
using BoardGamesShopMVC.Application.ViewModels.BoardGame;
using BoardGamesShopMVC.Application.ViewModels.Publisher;
using BoardGamesShopMVC.Domain.Interfaces;
using BoardGamesShopMVC.Domain.Model;

namespace BoardGamesShopMVC.Application.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;
        public PublisherService(IPublisherRepository publisherRepository, IMapper mapper)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }

        public ListPublisherForListVm GetAllPublishers()
        {
            var publishers = _publisherRepository.GetAllPublishers().ProjectTo<PublisherForListVm>(_mapper.ConfigurationProvider).ToList();
            var listPublishers = new ListPublisherForListVm()
            {
                Publishers = publishers,
                Count = publishers.Count
            };
            return listPublishers;
        }

        public ListBoardGameForListVm GetBoardGamesByPublisherId(int id)
        {
            var boardGames = _publisherRepository.GetAllBoardGamesByPublisherId(id)
                .ProjectTo<BoardGameForListVm>(_mapper.ConfigurationProvider).ToList();
            var boardGamesList = new ListBoardGameForListVm()
            {
                BoardGames = boardGames,
                Count = boardGames.Count
            };
            return boardGamesList;
        }
        public int AddPublisher(NewPublisherVm newPublisher)
        {
            var publisher = _mapper.Map<Publisher>(newPublisher);
            var id = _publisherRepository.AddPublisher(publisher);
            return id;
        }

        public void DeletePublisher(int id)
        {
            _publisherRepository.DeletePublisher(id);
        }

        public NewPublisherVm GetPublisherForEdit(int id)
        {
            var publisher = _publisherRepository.GetPublisherById(id);
            var publisherVm = _mapper.Map<NewPublisherVm>(publisher);
            return publisherVm;
        }

        public void UpdatePublisher(NewPublisherVm model)
        {
            var publisher = _mapper.Map<Publisher>(model);
            _publisherRepository.UpdatePublisher(publisher);
        }
    }
}
