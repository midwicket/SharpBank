using SharpBank.Models;
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
        public long Withdraw(long bankId, long accountId, decimal amount)
        {
            long id=0;
            try
            {
                id=transactionService.AddTransaction(bankId, accountId, 0, 0, amount);
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
        public long Deposit(long bankId, long accountId, decimal amount)
        {

            long id = 0;
            try
            {
                id = transactionService.AddTransaction(0,0,bankId, accountId, amount);
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
        public long Transfer(long sourceBankId,long sourceAccountId,long destinationBankId,long destinationAccountId ,decimal amount)
        {
            long id = 0;
            try
            {
                id=transactionService.AddTransaction(sourceBankId, sourceAccountId, destinationBankId, destinationAccountId, amount);
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
    }
}
