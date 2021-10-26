using SharpBank.CLI.Controllers;
using SharpBank.CLI.Enums;
using SharpBank.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpBank.CLI.Views
{
    class Transfer : IPage
    {
        private readonly TransactionsController transactionsController;
        private readonly long bankId;
        private readonly long accountId;

        public string Selection { get; set; }
        public long TransactionId { get; set; }
        public Transfer(TransactionsController transactionsController, long BankId,long AccountId)
        {
            this.transactionsController = transactionsController;
            bankId = BankId;
            accountId = AccountId;
        }

        public Navigation Prompt()
        {
            List<long> recp = Inputs.GetRecipient();
            var currency = Inputs.GetCurrency();
            var amount = Inputs.GetAmount(currency);

            TransactionId = transactionsController.Transfer(TransactionType.RTGS, bankId, accountId, recp[0], recp[1], amount);
            return Navigation.AccountOperations;
        }
    }
}
