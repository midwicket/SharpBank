using SharpBank.CLI.Controllers;
using SharpBank.CLI.Enums;
using SharpBank.CLI.Views;
using SharpBank.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpBank.CLI.Models
{
    class Session:IDisposable
    {
        private bool disposedValue;
        private readonly BanksController banksController;
        private readonly AccountsController accountsController;
        private readonly TransactionsController transactionsController;
        private readonly CurrencyConverterService currencyConverterService;
        private readonly Menu menu;

        
        public long BankId { get; set; }
        public long AccountId { get; set; }
        public Navigation CurrentPage { get; set; }

        public void Display()
        {
            switch (CurrentPage) {

                case Navigation.HomePage:

                    HomePage homepage = new HomePage(menu);
                    CurrentPage = homepage.Prompt();
                    this.BankId = banksController.GetBankByName(homepage.Selection).BankId; 
                    
                    break;

                case Navigation.CreateAccount:

                    CreateAccount createAccount = new CreateAccount(accountsController,this.BankId);
                    CurrentPage = createAccount.Prompt();

                    break;

                case Navigation.Login:

                    Login login = new Login(accountsController, this.BankId);
                    CurrentPage = login.Prompt();
                    this.AccountId = login.AccountId;

                    break;

                case Navigation.AuthenticationOperations:

                    AuthenticationOperations authenticationOperations = new AuthenticationOperations(banksController,BankId,menu);
                    CurrentPage = authenticationOperations.Prompt();

                    break;

                case Navigation.AccountOperations:

                    AccountOperations accountOperations = new AccountOperations(this.menu);
                    CurrentPage = accountOperations.Prompt();

                    break;

                case Navigation.Deposit:

                    Deposit deposit = new Deposit(transactionsController,this.BankId,this.AccountId);
                    CurrentPage = deposit.Prompt();
                    break;

                case Navigation.Withdraw:
                    Withdraw withdraw = new Withdraw(transactionsController, this.BankId, this.AccountId);
                    CurrentPage = withdraw.Prompt();
                    break;

                case Navigation.Transfer:
                    Transfer transfer = new Transfer(transactionsController, this.BankId, this.AccountId,this.currencyConverterService);
                    CurrentPage = transfer.Prompt();
                    break;

                case Navigation.TransactionHistory:
                    TransactionHistory transactionHistory = new TransactionHistory(accountsController, transactionsController, BankId, AccountId);
                    CurrentPage = transactionHistory.Prompt();
                    break;

                case Navigation.Balance:
                    Balance balance = new Balance(accountsController, BankId, AccountId,currencyConverterService);
                    CurrentPage = balance.Prompt();
                    break;

            }
        
        }
        public Session(
            BanksController banksController,
            AccountsController accountsController,
            TransactionsController transactionsController,
            CurrencyConverterService currencyConverterService,
            Menu menu)
        {
            this.banksController = banksController;
            this.accountsController = accountsController;
            this.transactionsController = transactionsController;
            this.currencyConverterService = currencyConverterService;
            this.menu = menu;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }
        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~Session()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
