using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Money;

namespace SharpBank.Services
{
    public class CurrencyConverterService : ICurrencyConverter<decimal>
    {
        public decimal Convert(decimal fromAmount, Currency fromCurrency, Currency toCurrency)
        {
            return (((decimal)fromCurrency)/((decimal)toCurrency)) * fromAmount;
        }
    }
}
