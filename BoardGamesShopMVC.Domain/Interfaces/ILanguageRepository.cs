﻿using BoardGamesShopMVC.Domain.Model;

namespace BoardGamesShopMVC.Domain.Interfaces
{
    public interface ILanguageRepository
    {
        int AddLanguage(Language language);
        void DeleteLanguage(int languageId);
        IQueryable<Language> GetAllLanguages();
        Language GetLanguageById(int languageId);
    }
}