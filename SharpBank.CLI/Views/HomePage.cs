using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpBank.CLI.Enums;
using Spectre.Console;

namespace SharpBank.CLI.Views
{
    class HomePage:IPage
    {
        private readonly Menu menu;

        public HomePage(Menu menu)
        {
            this.menu = menu;
        }

        public string Selection { get; set; }

        public Navigation Prompt() {

            AnsiConsole.Write(new Rule("[red]SharpBank[/]"));
            Selection = AnsiConsole.Prompt(menu.BankMenu());
            if (Selection == "Exit")
            {
                Environment.Exit(0);
            }
            return Navigation.HomePage;
        }

    }
}
