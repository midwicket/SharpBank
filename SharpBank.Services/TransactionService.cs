using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Money;
using SharpBank.Models;
using SharpBank.Models.Enums;
using SharpBank.Models.Exceptions;

namespace SharpBank.Services
{
    public class TransactionService
    {
        private readonly AccountService accountService;
        private readonly BankService bankService;

        public TransactionService(AccountService accountService,BankService bankService)
        {
            this.accountService = accountService;
            this.bankService = bankService;
        }
        public long GenerateId(long sourceBankId, long sourceAccountId, long destinationBankId,long destinationAccountId)
        {
            Random rand = new Random(123);
            Account sourceAccount = accountService.GetAccount(sourceBankId, sourceAccountId);
            Account destinationAccount = accountService.GetAccount(destinationBankId, destinationAccountId);

            long Id;
            do
            {
                Id = rand.Next();
            }

            while ((sourceAccount.Transactions.SingleOrDefault(t => t.TransactionId == Id) != null) ||
                    (destinationAccount.Transactions.SingleOrDefault(t => t.TransactionId == Id)!=null));
            return Id;
        }
        public long AddTransaction(TransactionType transactionType, long sourceBankId, long sourceAccountId,long destinationBankId, long destinationAccountId,Money<decimal> amount)
        {

            Money<decimal> deductible = GetDeductible(transactionType, sourceBankId,destinationBankId, amount);

            accountService.UpdateBalance(sourceBankId,sourceAccountId,-deductible);
            accountService.UpdateBalance(destinationBankId, destinationAccountId,amount);

            Transaction transaction = new Transaction
            {
                TransactionId = GenerateId(sourceBankId, sourceAccountId, destinationBankId, destinationAccountId),
                SourceAccountId = sourceAccountId,
                DestinationAccountId = destinationAccountId,
                SourceBankId = sourceBankId,
                DestinationBankId = destinationBankId,
                Type=transactionType,
                Amount = amount,
                On=DateTime.Now
            };
            accountService.GetAccount(sourceBankId,sourceAccountId).Transactions.Add(transaction);
            accountService.GetAccount(destinationBankId, destinationAccountId).Transactions.Add(transaction);

            return transaction.TransactionId;
        }
        public Money<decimal> GetDeductible(TransactionType transactionType, long sourceBankId,long destinationBankId, Money<decimal> amount)
        {
            var transactionCharges = bankService.GetTransactionCharge(sourceBankId, transactionType);
            decimal chargePercentage = (sourceBankId == destinationBankId) ? transactionCharges.IntraBank : transactionCharges.InterBank;
            return new Money<decimal>(amount.Amount * (1 + 0.01m * chargePercentage ), amount.Currency);
        }

        public Transaction GetTransaction(long bankId, long accountId, long TransactionId)
        {
            Account account = accountService.GetAccount(bankId, accountId);
            var transaction = account.Transactions.SingleOrDefault(t => t.TransactionId == TransactionId);
            return transaction;
        }
    }
}
