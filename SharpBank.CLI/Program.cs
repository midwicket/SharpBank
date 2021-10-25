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

namespace SharpBank.CLI
{
    class Program
    {

        static async Task Main(string[] args)
        {

            await Initialize();
            int currentMenu = 0;
            string bankName = "";
            long userBankId = 0;
            long userAccountId = 0;
            while (true) { 
                if (currentMenu == 0) {
                    HomePage homepage = new HomePage(menu);
                    userBankId = banksController.GetBankByName(homepage.Prompt()).BankId;
                    currentMenu++;
                }
                if (currentMenu == 1) {
                    AnsiConsole.Write(new Rule("[red]"+bankName+"[/] Services"));

                    LoginOptions option;
                    Enum.TryParse(AnsiConsole.Prompt(menu.LoginMenu()).Split()[0], out option);

                    switch(option)
                    {
                        case LoginOptions.Create:
                            userAccountId = accountsController.CreateAccount(userBankId);
                            AnsiConsole.WriteLine("Your account number is " + userAccountId.ToString("D10") + " Dont forget it .");
                            break;
                        case LoginOptions.Login:
                            userAccountId = inputs.GetAccountId();
                            string hashedPassword = accountsController.GetHashedPassword(userBankId,userAccountId);
                            string userPassword = inputs.GetPassword(hashedPassword);

                            currentMenu++;
                            break;
                        case LoginOptions.Back:
                            currentMenu--;
                            break;
                        case LoginOptions.Exit:
                            Environment.Exit(0);
                            break;
                    }
                }
                if (currentMenu == 2) {
                    menu.UserMenu();
                    UserOptions option;
                    Enum.TryParse(AnsiConsole.Prompt(menu.UserMenu()).Replace(" ",""),out option);
                    Money<decimal> amount;
                    Currency currency;


                    switch (option)
                    {
                        case UserOptions.Deposit:
                            currency = inputs.GetCurrency();
                            amount = inputs.GetAmount(currency);
                            transactionsController.Deposit(userBankId,userAccountId,amount);
                            break;
                        case UserOptions.Withdraw:
                            currency = inputs.GetCurrency();
                            amount = inputs.GetAmount(currency);
                            transactionsController.Withdraw(userBankId, userAccountId, amount);
                            break;
                        case UserOptions.Transfer:
                            List<long> recp = inputs.GetRecipient();
                            currency = inputs.GetCurrency();
                            amount = inputs.GetAmount(currency);
                            
                            transactionsController.Transfer(TransactionType.RTGS,userBankId,userAccountId,  recp[0],recp[1],amount);
                            break;
                        case UserOptions.Balance:
                            {
                                Funds balance = accountsController.GetBalance(userBankId, userAccountId);
                                currency = inputs.GetCurrency();
                                Money<decimal> money = balance.Evaluate(currencyConverterService, currency);
                                AnsiConsole.WriteLine("Your Balance is: " + money.Amount + " " + money.Currency);
                                break;
                            }
                        case UserOptions.TransactionHistory:
                            List<Transaction> hist = accountsController.GetTransactionHistory(userBankId,userAccountId);

                            Table table = new Table();
                            table.Border(TableBorder.Rounded);
                            table.AddColumns("TransactionId" , "Source Bank" , "Source Account" , " Dest. Bank  " , "Dest. Account" , " Amount " , "Timestamp ");
                            foreach (Transaction t in hist)
                            {
                                table.AddRow(
                                    "[red]" + t.TransactionId.ToString("D10") + "[/]",
                                    "[green]" + t.SourceBankId.ToString("D10") + "[/]",
                                    "[green]" + t.SourceAccountId.ToString("D10") + "[/]",
                                    "[yellow]" + t.DestinationBankId.ToString("D10") + "[/]",
                                    "[yellow]" + t.DestinationAccountId.ToString("D10") + "[/]",
                                    //replace with CultureInfo.CurrentCulture
                                    "[green]" + t.Amount.Amount +" "+ t.Amount.Currency.ToString() + "[/]",
                                    "[yellow]" + t.On.ToString() + "[/]"
                                    ) ;

                            }
                                AnsiConsole.Write(table);
                                break;
                        case UserOptions.Back:
                            currentMenu--;
                            break;
                        case UserOptions.Exit:
                            currentMenu = 0;
                            Environment.Exit(0);
                            break;
                        default:
                            AnsiConsole.WriteLine("Invalid ma");
                            break;

                    }

                }
       
            }

        }
        private static BanksController banksController;
        private static AccountsController accountsController;
        private static TransactionsController transactionsController;
        private static CurrencyConverterService currencyConverterService;
        private static Menu menu;
        private static Inputs inputs;

        static async Task Initialize()
        {
            Startup startup = new Startup();
            inputs = new Inputs();
            startup.LoadControllers(ref banksController, ref accountsController, ref transactionsController, inputs);
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
