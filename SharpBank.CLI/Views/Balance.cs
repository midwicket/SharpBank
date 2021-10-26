using Money;
using SharpBank.CLI.Controllers;
using SharpBank.CLI.Enums;
using SharpBank.Models;
using SharpBank.Services;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpBank.CLI.Views
{
    class Balance : IPage
    {
        private Currency currency;
        private readonly AccountsController accountsController;
        private readonly long bankId;
        private readonly long accountId;
        private readonly CurrencyConverterService currencyConverterService;

        public string Selection { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Balance(AccountsController accountsController,long BankId,long AccountId,CurrencyConverterService currencyConverterService)
        {
            this.accountsController = accountsController;
            bankId = BankId;
            accountId = AccountId;
            this.currencyConverterService = currencyConverterService;
        }

        public Navigation Prompt()
        {
            Funds balance = accountsController.GetBalance(bankId, accountId);
            currency = Inputs.GetCurrency();
            Money<decimal> money = balance.Evaluate(currencyConverterService, currency);
            AnsiConsole.WriteLine("Your Balance is: " + money.Amount + " " + money.Currency);
            return Navigation.AccountOperations;
        }
    }
}
