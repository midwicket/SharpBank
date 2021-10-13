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
    static class TransactionsController
    {
        public static Transaction Withdraw( Account acc, decimal amount)
        {
            try
            {
                if (acc.Balance < amount)
                {
                    throw new BalanceException();
                }
                acc.Balance -= amount;
                Transaction t = new Transaction
                {
                    TransactionID = "00" + (TransactionService.GetTransactions().Count + 1).ToString(),
                    SenderAccount = acc.AccountNumber,
                    SenderIFSC = acc.IFSC,
                    RecepientAccount = "Withdraw",
                    RecepientIFSC = "Withdraw",
                    Amount = amount

                };
                AccountService.UpdateAccount(acc);
                TransactionService.AddTransaction(t);
                return t;
            }
            catch (BalanceException) 
            {
                Console.WriteLine("Insufficient Balance");
            }
            catch (Exception)
            {
                Console.WriteLine("Internal Error");

            }
            return null;
        }
        public static Transaction Deposit(Account acc, decimal amount)
        {
            try
            {
               
                acc.Balance += amount;
                Transaction t = new Transaction
                {
                    TransactionID = "00" + (TransactionService.GetTransactions().Count + 1).ToString(),
                    RecepientAccount = acc.AccountNumber,
                    RecepientIFSC = acc.IFSC,
                    SenderAccount = "Deposit",
                    SenderIFSC = "Deposit",
                    Amount = amount

                };
                AccountService.UpdateAccount(acc);
                TransactionService.AddTransaction(t);
                return t;
            }
            catch (Exception)
            {
                Console.WriteLine("Internal Error");

            }
            return null;
        }
        public static Transaction Transfer(Account sacc,Account racc ,decimal amount)
        {
            try
            {
                if (sacc.Balance < amount)
                {
                    throw new BalanceException();
                }
                sacc.Balance -= amount;
                racc.Balance += amount;
                Transaction t = new Transaction
                {
                    TransactionID = "00" + (TransactionService.GetTransactions().Count + 1).ToString(),
                    SenderAccount = sacc.AccountNumber,
                    SenderIFSC = sacc.IFSC,
                    RecepientAccount = racc.AccountNumber,
                    RecepientIFSC = racc.IFSC,
                    Amount = amount

                };
                AccountService.UpdateAccount(sacc);
                AccountService.UpdateAccount(racc);
                TransactionService.AddTransaction(t);
                return t;
            }
            catch (BalanceException)
            {
                Console.WriteLine("Insufficient Balance");
            }
            catch (Exception)
            {
                Console.WriteLine("Internal Error");

            }
            return null;
        }
        public static List<Transaction> GetTransactionHistory(Account acc)
        {
            List<Transaction> transactions = new List<Transaction>();
            try
            {
                foreach (Transaction t in TransactionService.GetTransactions())
                {
                    if (((t.SenderIFSC == acc.IFSC) && (t.SenderAccount == acc.AccountNumber)) || ((t.RecepientIFSC == acc.IFSC) && (t.RecepientAccount == acc.AccountNumber)))
                    {
                        transactions.Add(t);
                    }
                }
                return transactions;
            }
            catch(Exception)
            {
                Console.WriteLine("Internal Error");
            }
            return null;
        }
    }
}
