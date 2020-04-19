using System;
using System.Collections.Generic;
using System.Text;

namespace TradingEngine.Domain.Entities
{
    public class User
    {
        public int Id;
        public string Username;
        public string Password;

        private readonly Balance _balance;
        private readonly string _username;

        public User(string username, Balance balance)
        {
            _username = username;
            _balance = balance;
        }

        public User()
        {
        }

        public void Exchange(Money money, Currency to)
        {
            _balance.Exchange(money, to);
        }

        public void ReceiveMoney(Money money)
        {
            _balance.AddMoney(money);
        }

        //return currency name and amount dictionary
        public Dictionary<string,double> GetBalance()
        {
            var currencies = _balance.GetAllMoney();
            var result = new Dictionary<string, double>();
            //loop to get the currency name then the value. Currency object is name + ratio
            foreach (var key in currencies.Keys)
            {
                result.Add(key.GetName(), currencies[key]);
            }

            return result;
        }

        
        public void SendMoney(User userTo, Money money)
        {
            _balance.ChargeMoney(money);
            userTo.ReceiveMoney(money);
        }


    }
}
