using System;
using SystemGlobalServices.Models;
using System.Web;
using System.Net;
using Newtonsoft.Json;
using SystemGlobalServices.Helpers;

namespace SystemGlobalServices.Services.Implementation
{
    public class CurrencyService : ICurrencyService
    {
        private readonly HttpClient _httpClient;

        public CurrencyService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("CurrencyClient");
        }

        public async Task<PaginationList<Currency>> GetCurrencies(CurrencyPaginationSettings paginationSettings)
        {

            var response = await _httpClient.GetAsync(_httpClient.BaseAddress);

            var json = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();

            var currency = JsonConvert.DeserializeObject<RootCurrency>(json);

            return PaginationList<Currency>.ToPaginationdList(
                currency.Valute.Select(x => x.Value),
                paginationSettings.PageNumber,
                paginationSettings.PageSize
                );
        }

        public async Task<Currency> GetCurrency(string id) { 

            var response = await _httpClient.GetAsync(_httpClient.BaseAddress);

            var json = await response.Content.ReadAsStringAsync();
            var currency = JsonConvert.DeserializeObject<RootCurrency>(json);

            return currency.Valute
                .Select(x => x.Value)
                .Where(x => x.Id == id)
                .FirstOrDefault(new Currency());
        }
    }
}

