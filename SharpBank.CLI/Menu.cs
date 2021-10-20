using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpBank.Models;
using SharpBank.Services;
using Spectre.Console;

namespace SharpBank.CLI
{
     class  Menu
    {
        public SelectionPrompt<string> BankMenu(Datastore datastore)
        {
            SelectionPrompt<string> bankMenuPrompt = new SelectionPrompt<string>()
                .Title("Select [green]Bank[/] to perform operations")
                .PageSize(10)
                .MoreChoicesText("[grey]Move up and down to reveal more banks[/]");
                
            foreach (Bank bank in datastore.Banks) {
                bankMenuPrompt.AddChoice(bank.Name);
            }
            bankMenuPrompt.AddChoice("Exit");
            return bankMenuPrompt;
        }
        public SelectionPrompt<string> LoginMenu()
        {
            SelectionPrompt<string> selectionPrompt = new SelectionPrompt<string>()
                .Title("Select one of the following [green]operations[/]")
                .PageSize(10)
                .AddChoices(new[] { 
                    "Create Account" ,
                    "Login",
                    "Back",
                    "Exit"
                });
            return selectionPrompt;

        }
        public SelectionPrompt<string> UserMenu()
        {
            SelectionPrompt<string> selectionPrompt = new SelectionPrompt<string>()
               .Title("Select one of the following [green]operations[/]")
               .PageSize(10)
               .AddChoices(new[] {
                     "Deposit",
                     "Withdraw",
                     "Transfer",
                     "Balance",
                     "Transaction History",
                     "Back",
                     "Exit"
               });
            return selectionPrompt;
        }
    }
}
