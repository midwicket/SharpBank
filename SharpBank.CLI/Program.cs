using System;
using System.Collections.Generic;
using SharpBank.Services;
using SharpBank.Models;
using SharpBank.CLI.Controllers;
using SharpBank.CLI.Enums;
using Spectre.Console;
using System.Globalization;
using Money;

namespace SharpBank.CLI
{
    class Program
    {
        static void Main(string[] args)
        {


            Inputs inputs = new Inputs();
            Datastore datastore = new Datastore();
            
            BankService bankService = new BankService(datastore);
            AccountService accountService = new AccountService(bankService);
            TransactionService transactionService = new TransactionService(accountService);


            BanksController banksController = new BanksController(bankService,inputs);
            AccountsController accountsController = new AccountsController(accountService,inputs);
            TransactionsController transactionsController = new TransactionsController(transactionService);
            //SEED

            
            banksController.CreateBank("Yaxis");
            banksController.CreateBank("YesBI");
            banksController.CreateBank("FDHC");
            banksController.CreateBank("YCYCY");
            
            


            Menu menu = new Menu();


            int currentMenu = 0;
            string bankName = "";
            long userBankId = 0;
            long userAccountId = 0;
            while (true) { 
                if (currentMenu == 0) {
                    AnsiConsole.Write(new Rule("[red]SharpBank[/]"));
                    bankName = AnsiConsole.Prompt(menu.BankMenu(datastore));
                    if (bankName == "Exit")
                    {
                        Environment.Exit(0);
                    }
                    userBankId = banksController.GetBankByName(bankName).BankId;
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
                            string userPassword = inputs.GetPassword();
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
                    Money<decimal> amount = new Money<decimal>(0, Currency.INR);
                    switch (option)
                    {
                        case UserOptions.Deposit:
                            amount = inputs.GetAmount();
                            transactionsController.Deposit(userBankId,userAccountId,amount);
                            break;
                        case UserOptions.Withdraw:
                            amount = inputs.GetAmount();
                            transactionsController.Withdraw(userBankId, userAccountId, amount);
                            break;
                        case UserOptions.Transfer:
                            List<long> recp = inputs.GetRecipient();
                            amount = inputs.GetAmount();
                            
                            transactionsController.Transfer(userBankId,userAccountId,  recp[0],recp[1],amount);
                            break;
                        case UserOptions.Balance:
                            {
                                AnsiConsole.WriteLine("Your Balance is: " + accountsController.GetBalance(userBankId,userAccountId));
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
                                    "[green]" + t.Amount.Amount + t.Amount.Currency.ToString() + "[/]",
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

    }
}
