using SharpBank.CLI.Controllers;
using SharpBank.CLI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpBank.CLI.Views
{
    class Withdraw : IPage
    {
        private readonly TransactionsController transactionsController;
        private readonly long bankId;
        private readonly long accountId;
        public long TransactionId { get; set; }

        public Withdraw(TransactionsController transactionsController,long BankId,long AccountId)
        {
            this.transactionsController = transactionsController;
            bankId = BankId;
            accountId = AccountId;
        }
        public string Selection { get; set; }

        public Navigation Prompt()
        {
            var currency = Inputs.GetCurrency();
            var amount = Inputs.GetAmount(currency);
            TransactionId = transactionsController.Withdraw(bankId, accountId, amount);
            return Navigation.AccountOperations;
        }
    }
}
