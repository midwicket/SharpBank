using System;
using System.Collections.Generic;
using SharpBank.Services;
using SharpBank.Models;
using SharpBank.CLI.Controllers;
using SharpBank.CLI.Enums;

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
            long userBankId = 0;
            long userAccountId = 0;
            while (true) { 
                if (currentMenu == 0) {
                    menu.BankMenu(datastore);
                    long bnk = inputs.GetSelection();
                    userBankId = bnk;
                    currentMenu++;
                }
                if (currentMenu == 1) {
                    menu.LoginMenu();
                    LoginOptions option = (LoginOptions)Enum.Parse(typeof(LoginOptions), Console.ReadLine());
                    switch(option)
                    {
                        case LoginOptions.Create:
                            userAccountId= accountsController.CreateAccount(userBankId);
                            Console.WriteLine("Your account number is " + userAccountId + " Dont forget it .");
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
                    UserOptions option = (UserOptions)Enum.Parse(typeof(UserOptions), Console.ReadLine());
                    decimal amount = 0m;
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
                        case UserOptions.ShowBalance:
                            {
                                Console.WriteLine("Your Balance is: " + accountsController.GetBalance(userBankId,userAccountId));
                                break;
                            }
                        case UserOptions.TransactionHistory:
                            List<Transaction> hist = accountsController.GetTransactionHistory(userBankId,userAccountId);
                            
                            foreach (Transaction t in hist)
                            {
                                Console.WriteLine(t.ToString());
                            }
                            break;
                        case UserOptions.Exit:
                            currentMenu = 0;
                            break;
                        default:
                            Console.WriteLine("Invalid ma");
                            break;

                    }

                }
       
            }

        }

    }
}
