using Money;
using SharpBank.CLI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;

namespace SharpBank.CLI.Services
{
    class ExchangeRatesService
    {
        private readonly HttpClient httpClient;
        private readonly string appID = ConfigurationManager.AppSettings.Get("EXCHANGE_API_KEY");
        public ExchangeRatesService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<ApiResponse> GetExchangeRates()
        {
            return await httpClient.GetFromJsonAsync<ApiResponse>($"api/latest.json?app_id={appID}");
        
        }


}
       

}
