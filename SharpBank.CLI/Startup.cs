using SharpBank.CLI.Controllers;
using SharpBank.CLI.Services;
using SharpBank.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SharpBank.CLI
{
    class Startup
    {
        private readonly Datastore datastore;
        private BankService bankService;
        private AccountService accountService;
        private TransactionService transactionService;
        private HttpClient client;
        
        public Startup()
        {
            this.datastore = new Datastore();

            LoadServices();
            LoadClient();

            
        }

        void LoadClient() {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://openexchangerates.org");
        }

        public async Task<IDictionary<string, decimal>> GetExchangeRates()
        {
            ExchangeRatesService exchangeRates = new ExchangeRatesService(client);
            var result = await exchangeRates.GetExchangeRates();
            return result.Rates;
        }


        public void LoadControllers(ref BanksController banksController, ref AccountsController accountsController, ref TransactionsController transactionsController) {
            banksController = new BanksController(bankService);
            accountsController = new AccountsController(accountService);
            transactionsController = new TransactionsController(transactionService);
        }

        public void LoadMenus(ref Menu menu) {
            menu = new Menu(datastore);
        }

        void LoadServices() {

            bankService = new BankService(datastore);
            accountService = new AccountService(bankService);
            transactionService = new TransactionService(accountService);

        }
    }
}
