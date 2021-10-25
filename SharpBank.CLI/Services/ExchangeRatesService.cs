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
using System.IO;
using Newtonsoft.Json;

namespace SharpBank.CLI.Services
{
    class ExchangeRatesService
    {
        private readonly HttpClient httpClient;
        private readonly string appID;

        public ExchangeRatesService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            appID = ConfigurationManager.AppSettings.Get("EXCHANGE_API_KEY");
        }
        public async Task<ApiResponse> GetExchangeRates()
        {
            if (appID == null)
            {
                using (StreamReader r = new StreamReader("rates_cached.json"))
                {
                    string jsonData = r.ReadToEnd();
                    return JsonConvert.DeserializeObject<ApiResponse>(jsonData);
                }
            }
            else
            {
                //ADD CACHING TO JSON
                return await httpClient.GetFromJsonAsync<ApiResponse>($"api/latest.json?app_id={appID}");
            }
        }


}
       

}
