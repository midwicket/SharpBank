using Money;
using SharpBank.CLI.Controllers;
using SharpBank.CLI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpBank.CLI.Views
{
    class Deposit : IPage
    {
        private readonly TransactionsController transactionsController;
        private readonly long bankId;
        private readonly long accountId;

        public string Selection { get ; set ; }

        public Deposit(TransactionsController transactionsController,long BankId, long AccountId)
        {
            this.transactionsController = transactionsController;
            bankId = BankId;
            accountId = AccountId;
        }

        public Navigation Prompt()
        {
            Currency currency = Inputs.GetCurrency();
            Money<decimal> amount = Inputs.GetAmount(currency);
            transactionsController.Deposit(bankId, accountId, amount);
            return Navigation.AccountOperations;
        }
    }
}
