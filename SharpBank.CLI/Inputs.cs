using SharpBank.Models.Enums;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Money;

namespace SharpBank.CLI
{
    public static class Inputs
    {
        public static bool AreYouSure(string message)
        {
            var response = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title($"[red]{message}[/]")
                .AddChoices("Yes", "No")
                );
            return response == "Yes";
        }

        public static long GetAccountId()
        {
            int id = AnsiConsole.Prompt<int>(
                new TextPrompt<int>("Enter Account ID")
                .Validate(id=> 
                {
                    return id switch
                    {
                        < 0 => ValidationResult.Error("[red]Negative Account Numbers[/] are not allowed"),
                        0 => ValidationResult.Error("[red]Protected Account[/]. Access Denied."),
                        >= int.MaxValue => ValidationResult.Error("[red]ID[/] Too large"),
                        _ => ValidationResult.Success(),
                    };
                
                })
                
                );
            return id;
        }

        public static TransactionType GetTransactionType(decimal amountINR)
        {
            var selectionPrompt = new SelectionPrompt<string>()
                .Title("Select [green]Transaction Type[/]")
                .AddChoices("IMPS", "NEFT");

            if (amountINR > 100000) {
                selectionPrompt.AddChoice("RTGS");
            }

            var option = AnsiConsole.Prompt(selectionPrompt);
            Enum.TryParse(option, out TransactionType transactionType);
            return transactionType;
        }

        public static string GetPassword()
        {
            string password = AnsiConsole.Prompt(
               new TextPrompt<string>("Enter [green] password [/]")
               .PromptStyle("red")
               .Secret()
               );

            return password;
        }
        public static string GetPassword(string hashedPassword)
        {
            string password = AnsiConsole.Prompt(
               new TextPrompt<string>("Enter [green] password [/]")
               .PromptStyle("red")
               .Secret()
               .Validate(p =>
               {
                   return p.GetHashCode().ToString() == hashedPassword ? ValidationResult.Success() : ValidationResult.Error("Wrong Password");

               }));
                
            return password;
        }
        public static string GetName()
        {
            var option = AnsiConsole.Ask<string>("Please Enter your Name");
            return option;
        }
        public static Gender GetGender()
        {
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Select [green]Gender[/]")
                .AddChoices("Male", "Female", "Other")
                );
            Enum.TryParse(option,out Gender gender);
            return gender;
        }

        public static Currency GetCurrency() {
            SelectionPrompt<Currency> selectionPrompt = new SelectionPrompt<Currency>().Title("Select Currency");
            IEnumerable<Currency> currencies = (Currency[])Enum.GetValues(typeof(Currency));

            selectionPrompt.AddChoices(currencies);

            Currency option = AnsiConsole.Prompt(
                selectionPrompt
                );
            return option;
        }

        public static Money<decimal> GetAmount(Currency currency)
        {

            AnsiConsole.WriteLine("Please Enter The Amount :");
            return new Money<decimal>(Convert.ToDecimal(Console.ReadLine()),currency);
        }

        public static List<long> GetRecipient()
        {
            List<long> res = new List<long>();
            AnsiConsole.WriteLine("Please Enter Recipient BankId");
            res.Add(Convert.ToInt64(Console.ReadLine()));
            AnsiConsole.WriteLine("Please Enter Recipient Account number");
            res.Add(Convert.ToInt64(Console.ReadLine()));
            return res;
        }
        public static SharpBank.Models.Enums.Status GetStatus()
        {
            SelectionPrompt<SharpBank.Models.Enums.Status> selectionPrompt = new SelectionPrompt<SharpBank.Models.Enums.Status>().Title("Select Status");
            IEnumerable<SharpBank.Models.Enums.Status> statuses = (SharpBank.Models.Enums.Status[])Enum.GetValues(typeof(SharpBank.Models.Enums.Status));

            selectionPrompt.AddChoices(statuses);

            var option = AnsiConsole.Prompt(
                selectionPrompt
                );
            return option;

        }
    }
}
