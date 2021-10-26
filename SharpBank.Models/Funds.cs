using Money;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpBank.Models
{
    public class Funds : Wallet<decimal>
    {

        public List<Money<decimal>> Wallets { get; set; }

        protected override Currency Currency => throw new NotImplementedException();

        public static Funds operator +(Funds left, Money<decimal> right) {

            left.Wallets.Add(right);

            return left;
        
        }



        protected override Money<decimal> EvaluateInner(ICurrencyConverter<decimal> currencyConverter, Currency toCurrency)
        {
            decimal totalConvertedValue = 0m;
            foreach (Money<decimal> money in Wallets) {
                totalConvertedValue += currencyConverter.Convert(money.Amount, money.Currency, toCurrency);
                
            }
            return new Money<decimal>(totalConvertedValue, toCurrency);
        }
    }
}
