using System;
using System.Collections.Generic;
using System.Text;

namespace TradingEngine.Domain.Entities
{
    public class Money
    {
        private readonly Currency _currency;
        private readonly double _amount;

        public Money(Currency currency, double amount)
        {
            _currency = currency;
            _amount = amount;
        }

        public Currency GetCurrency()
        {
            return _currency;
        }

        public double GetAmount()
        {
            return _amount;
        }
    }
}
