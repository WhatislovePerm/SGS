using System;
using SystemGlobalServices.Helpers;
using SystemGlobalServices.Models;

namespace SystemGlobalServices.Services
{
    public interface ICurrencyService
    {
        Task<PaginationList<Currency>> GetCurrencies(CurrencyPaginationSettings paginationSettings);

        Task<Currency> GetCurrency(string id);
    }
}

