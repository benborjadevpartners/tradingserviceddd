using System;
using System.Collections.Generic;
using System.Text;

namespace TradingEngine.Domain.Entities
{
    //CORE LOGIC
    public class Balance
    {
        //dictionary of balances per currency type
        private Dictionary<Currency, double> _currencies = new Dictionary<Currency,double>();

        public Dictionary<Currency,double> GetAllMoney()
        {
            return _currencies;
        }

        public void Exchange(Money money, Currency to)
        {
            var enough = hasEnoughMoneyInBalance(money);
            if ( enough)
            {
                var inputRatio = money.GetCurrency().GetRatio();
                var toCurrencyRatio = to.GetRatio();
                double diffRatio = Convert.ToDouble(Math.Round(inputRatio / toCurrencyRatio));
                double newMoneyAmount = money.GetAmount() * diffRatio;
                var newMoney = new Money(to, newMoneyAmount);
                AddMoney(newMoney); // add to destination currency wallet
                ChargeMoney(money); // charge to source currency wallet
            }
        }

        public void AddMoney(Money money)
        {
            //check dictionary
            if (_currencies.ContainsKey(money.GetCurrency()))
            {
                var currentValue = _currencies[money.GetCurrency()];
                var newValue = currentValue + money.GetAmount();
                //update
                _currencies[money.GetCurrency()] = newValue;
            }
            else
            {
                //insert 
                _currencies.Add(money.GetCurrency(), money.GetAmount());
            }
        }

        //Deduct 
        public void ChargeMoney(Money charge)
        {
            //check dictionary
            if (_currencies.ContainsKey(charge.GetCurrency()))
            {
                var currentValue = _currencies[charge.GetCurrency()];
                var newValue = currentValue - charge.GetAmount();
                //update
                _currencies[charge.GetCurrency()] = newValue;
            }
            else
            {
                //insert negated
                _currencies.Add(charge.GetCurrency(), charge.GetAmount() * -1);
            }
        }

        private bool hasEnoughMoneyInBalance(Money money)
        {    
            //how much left of this type of currency?
            double moneyBalance = _currencies[money.GetCurrency()];
            if (moneyBalance == 0)
            {
                //currency not found
                return false;
            }
            else if (moneyBalance < money.GetAmount())
            {
                //not enough balance
                return false;
            }
            else
            {
                return true;
            }
            
        }
    }
}
