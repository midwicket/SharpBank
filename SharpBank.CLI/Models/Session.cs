using SharpBank.CLI.Controllers;
using SharpBank.CLI.Enums;
using SharpBank.CLI.Views;
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
                    AuthenticationOperations authenticationOperations = new AuthenticationOperations();

                    break;

            }
        
        }
        public Session(BanksController banksController,AccountsController accountsController,TransactionsController transactionsController)
        {
            this.banksController = banksController;
            this.accountsController = accountsController;
            this.transactionsController = transactionsController;
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
