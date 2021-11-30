using Money;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpBank.Models
{
    [Table("FundsTable")]
    public class Funds : Wallet<decimal>
    {
        public long Id { get; set; }

        public List<Money> Wallets { get; set; }

        protected override Currency Currency => Currency.INR;

        public static Funds operator +(Funds left, Money right) {

            left.Wallets.Add(right);

            return left;
        
        }



        protected override Money<decimal> EvaluateInner(ICurrencyConverter<decimal> currencyConverter, Currency toCurrency)
        {
            decimal totalConvertedValue = 0m;
            foreach (Money money in Wallets) {
                totalConvertedValue += currencyConverter.Convert(money.Amount, money.Currency, toCurrency);
                
            }
            return new Money<decimal>(totalConvertedValue, toCurrency);
        }
    }
}
