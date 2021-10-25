using SharpBank.CLI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpBank.CLI.Views
{
    class AccountOperations : IPage
    {
        public string Selection { get; set; }

        public Navigation Prompt()
        {
            UserOptions option;
            Enum.TryParse(AnsiConsole.Prompt(menu.UserMenu()).Replace(" ", ""), out option);
            Money<decimal> amount;
            Currency currency;


            switch (option)
            {
                case UserOptions.Deposit:
                    return Navigation.Deposit;
                case UserOptions.Withdraw:
                    currency = Inputs.GetCurrency();
                    amount = Inputs.GetAmount(currency);
                    transactionsController.Withdraw(userBankId, userAccountId, amount);
                    break;
                case UserOptions.Transfer:
                    List<long> recp = Inputs.GetRecipient();
                    currency = Inputs.GetCurrency();
                    amount = Inputs.GetAmount(currency);

                    transactionsController.Transfer(TransactionType.RTGS, userBankId, userAccountId, recp[0], recp[1], amount);
                    break;
                case UserOptions.Balance:
                    {
                        Funds balance = accountsController.GetBalance(userBankId, userAccountId);
                        currency = Inputs.GetCurrency();
                        Money<decimal> money = balance.Evaluate(currencyConverterService, currency);
                        AnsiConsole.WriteLine("Your Balance is: " + money.Amount + " " + money.Currency);
                        break;
                    }
                case UserOptions.TransactionHistory:
                    List<Transaction> hist = accountsController.GetTransactionHistory(userBankId, userAccountId);

                    Table table = new Table();
                    table.Border(TableBorder.Rounded);
                    table.AddColumns("TransactionId", "Source Bank", "Source Account", " Dest. Bank  ", "Dest. Account", " Amount ", "Timestamp ");
                    foreach (Transaction t in hist)
                    {
                        table.AddRow(
                            "[red]" + t.TransactionId.ToString("D10") + "[/]",
                            "[green]" + t.SourceBankId.ToString("D10") + "[/]",
                            "[green]" + t.SourceAccountId.ToString("D10") + "[/]",
                            "[yellow]" + t.DestinationBankId.ToString("D10") + "[/]",
                            "[yellow]" + t.DestinationAccountId.ToString("D10") + "[/]",
                            //replace with CultureInfo.CurrentCulture
                            "[green]" + t.Amount.Amount + " " + t.Amount.Currency.ToString() + "[/]",
                            "[yellow]" + t.On.ToString() + "[/]"
                            );

                    }
                    AnsiConsole.Write(table);
                    break;
                case UserOptions.Back:
                    currentMenu--;
                    break;
                case UserOptions.Exit:
                    currentMenu = 0;
                    Environment.Exit(0);
                    break;
                default:
                    AnsiConsole.WriteLine("Invalid ma");
                    break;

            }
        }
    }
}
