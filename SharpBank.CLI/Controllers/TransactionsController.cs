using Money;
using SharpBank.Models;
using SharpBank.Models.Enums;
using SharpBank.Models.Exceptions;
using SharpBank.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpBank.CLI.Controllers
{
     class TransactionsController
    {
        private readonly TransactionService transactionService;

        public TransactionsController(TransactionService transactionService)
        {
            this.transactionService = transactionService;
        }
        public long Withdraw(long bankId, long accountId, Money<decimal> amount)
        {
            long id=0;
            try
            {
                id=transactionService.AddTransaction(TransactionType.CASH,bankId, accountId, 0, 0, amount);
            }
            catch (BalanceException) 
            {
                Console.WriteLine("Insufficient Balance");
            }
            catch (Exception)
            {
                Console.WriteLine("Internal Error");

            }
            return id;
        }
        public long Deposit(long bankId, long accountId, Money<decimal> amount)
        {

            long id = 0;
            try
            {
                id = transactionService.AddTransaction(TransactionType.CASH,0,0,bankId, accountId, amount);
            }
            catch (BalanceException)
            {
                Console.WriteLine("Insufficient Balance");
            }
            catch (Exception)
            {
                Console.WriteLine("Internal Error");

            }
            return id;
        }
        public long Transfer(TransactionType transactionType ,long sourceBankId,long sourceAccountId,long destinationBankId,long destinationAccountId ,Money<decimal> amount)
        {
            long id = 0;
            try
            {
                id=transactionService.AddTransaction(transactionType, sourceBankId, sourceAccountId, destinationBankId, destinationAccountId, amount);
            }
            catch (BalanceException)
            {
                Console.WriteLine("Insufficient Balance");
            }
            catch (Exception)
            {
                Console.WriteLine("Internal Error");

            }
            return id;
        }
        public Money<decimal> GetDeductible(TransactionType transactionType, long sourceBankId,long destinationBankId, Money<decimal> amount)
        {
            return transactionService.GetDeductible(transactionType, sourceBankId,destinationBankId, amount);
        }
    }
}
