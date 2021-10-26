using SharpBank.CLI.Controllers;
using SharpBank.CLI.Enums;
using SharpBank.Models;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpBank.CLI.Views
{
    class TransactionHistory : IPage
    {
        private readonly AccountsController accountsController;
        private readonly TransactionsController transactionsController;
        private readonly long bankId;
        private readonly long accountId;

        public string Selection { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public TransactionHistory(AccountsController accountsController ,TransactionsController transactionsController, long BankId,long AccountId)
        {
            this.accountsController = accountsController;
            this.transactionsController = transactionsController;
            bankId = BankId;
            accountId = AccountId;
        }

        public Navigation Prompt()
        {
            List<Transaction> hist = accountsController.GetTransactionHistory(bankId, accountId);

            Table table = new Table();
            table.Border(TableBorder.Rounded);
            table.AddColumns("[yellow]TransactionId[/]", "[green]Source Bank[/]", "[green]Source Account[/]", "[red]Dest. Bank[/]", "[red]Dest. Account[/]", "[green]Amount[/]", "[yellow]Timestamp[/]");
            foreach (Transaction t in hist)
            {
                table.AddRow(
                    "[yellow]" + t.TransactionId.ToString("D10") + "[/]",
                    t.SourceBankId.ToString("D10"),
                    t.SourceAccountId.ToString("D10"),
                    t.DestinationBankId.ToString("D10"),
                    t.DestinationAccountId.ToString("D10"),
                    "[green]" + t.Amount.Amount + " " + t.Amount.Currency.ToString() + "[/]",
                    t.On.ToString()
                    );

            }
            AnsiConsole.Write(table);

            return Navigation.AccountOperations;
        }
    }
}
