using SharpBank.CLI.Controllers;
using SharpBank.CLI.Enums;
using SharpBank.Models.Enums;
using SharpBank.Services;
using Spectre.Console;
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
        private readonly CurrencyConverterService currencyConverterService;

        public string Selection { get; set; }
        public long TransactionId { get; set; }
        public Transfer(TransactionsController transactionsController, long BankId,long AccountId, CurrencyConverterService currencyConverterService)
        {
            this.transactionsController = transactionsController;
            bankId = BankId;
            accountId = AccountId;
            this.currencyConverterService = currencyConverterService;
        }

        public Navigation Prompt()
        {
            List<long> recp = Inputs.GetRecipient();
            var currency = Inputs.GetCurrency();
            var amount = Inputs.GetAmount(currency);
            var convertedValue = currencyConverterService.Convert(amount.Amount, amount.Currency, Money.Currency.INR);
            var transactionType = Inputs.GetTransactionType(convertedValue);

            var deductible = transactionsController.GetDeductible(transactionType,bankId,amount);

            bool areYouSure = Inputs.AreYouSure($"This will deduct a total of {deductible.Amount} {deductible.Currency} from your account [yellow]This includes bank mandated charges for {transactionType.ToString()}[/]."+Environment.NewLine+"[green]Proceed?[/]");

            if (areYouSure)
            {
                TransactionId = transactionsController.Transfer(transactionType, bankId, accountId, recp[0], recp[1], amount);
                AnsiConsole.Write(new Markup($"Transferred {amount.Amount} {amount.Currency} to bearer of account id {recp[1]}"));
                AnsiConsole.Write(Environment.NewLine);

                AnsiConsole.Write(new Markup($"Transaction Reference ID: [yellow]{TransactionId}[/]"));
                AnsiConsole.Write(Environment.NewLine);

            }
            else
            {
                AnsiConsole.Write(new Markup("[red]Transaction Cancelled[/]"));
                AnsiConsole.Write(Environment.NewLine);

            }
            return Navigation.AccountOperations;
        }
    }
}
