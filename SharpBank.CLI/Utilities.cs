using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpBank.Models;
using SharpBank.Services;


namespace SharpBank.CLI
{
    public static class Utilities
    {
        public static string PrintReciept(Transaction t)
        {
            Transaction trans = TransactionService.GetTransaction(t.TransactionID);
            string res = "";
            res += "Transaction ID : " + trans.TransactionID + Environment.NewLine;
            res += "-------------------" + Environment.NewLine;
            res += "Recepient IFSC : " + trans.RecepientAccount + Environment.NewLine + "Recepient Acc Number : " + trans.RecepientAccount + Environment.NewLine;
            res += "Sender IFSC : " + trans.SenderAccount + Environment.NewLine + "Sender Acc Number : " + trans.SenderAccount + Environment.NewLine;
            res += "Transacted Amount : " + trans.Amount + "/-" + Environment.NewLine;
            return res;

        }
    }
}
