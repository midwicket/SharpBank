using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Money;
using Money.Internal.Helpers;

namespace SharpBank.Services
{
    public class CurrencyConverterService : ICurrencyConverter<decimal>
    {
        private readonly IDictionary<string, decimal> rateCache;

        public CurrencyConverterService(IDictionary<string,decimal> rateCache)
        {
            this.rateCache = rateCache;
        }
        public decimal Convert(decimal fromAmount, Currency fromCurrency, Currency toCurrency)
        {
            

            if (!this.rateCache.ContainsKey(fromCurrency.ToString()))
                return 0m;

            var usdEquivalent = BinaryOperationHelper.Divide(fromAmount, rateCache[fromCurrency.ToString()]);

            return BinaryOperationHelper.MultiplyChecked(usdEquivalent, rateCache[toCurrency.ToString()]);
        }

        
    }
}
