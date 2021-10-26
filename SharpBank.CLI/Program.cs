using System;
using System.Collections.Generic;
using SharpBank.Services;
using SharpBank.Models;
using SharpBank.CLI.Controllers;
using SharpBank.CLI.Enums;
using Spectre.Console;
using System.Globalization;
using Money;
using SharpBank.Models.Enums;
using System.Threading.Tasks;
using System.Net.Http;
using SharpBank.CLI.Services;
using SharpBank.CLI.Views;
using SharpBank.CLI.Models;

namespace SharpBank.CLI
{
    class Program
    {

        static async Task Main(string[] args)
        {

            await Initialize();
            using Session session = new Session(banksController,accountsController,transactionsController,currencyConverterService,menu);
            while (true)
            {
                session.Display();
            }

        }
        private static BanksController banksController;
        private static AccountsController accountsController;
        private static TransactionsController transactionsController;
        private static CurrencyConverterService currencyConverterService;
        private static Menu menu;

        static async Task Initialize()
        {
            Startup startup = new Startup();
            startup.LoadControllers(ref banksController, ref accountsController, ref transactionsController);
            LoadBanks();
            startup.LoadMenus(ref menu);

            IDictionary<string, decimal> exchangeRates = await startup.GetExchangeRates();
            currencyConverterService = new CurrencyConverterService(exchangeRates);
        }
        static void LoadBanks()
        {

            banksController.CreateBank("Yaxis");
            banksController.CreateBank("YesBI");
            banksController.CreateBank("FDHC");
            banksController.CreateBank("YCYCY");

        }

    }
}
