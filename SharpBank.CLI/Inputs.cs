﻿using SharpBank.Models.Enums;
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
        public static int GetSelection()
        {
            try
            {
                Console.WriteLine("Please Enter Your Selection :");

                return Convert.ToInt32(Console.ReadLine());
            }
            catch(FormatException e)
            {
                Console.WriteLine("Invalid Selection");
            }
            //Goback
            return -1;
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

            Console.WriteLine("Please Enter The Amount :");
            return new Money<decimal>(Convert.ToDecimal(Console.ReadLine()),currency);
        }

        public static List<long> GetRecipient()
        {
            List<long> res = new List<long>();
            Console.WriteLine("Please Enter Recipient BankId");
            res.Add(Convert.ToInt64(Console.ReadLine()));
            Console.WriteLine("Please Enter Recipient Account number");
            res.Add(Convert.ToInt64(Console.ReadLine()));
            return res;
        }
    }
}
