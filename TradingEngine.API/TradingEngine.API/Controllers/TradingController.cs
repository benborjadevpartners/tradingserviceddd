using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TradingEngine.Domain.Entities;
using TradingEngine.Domain.Interfaces;
using TradingEngine.Domain.Service;

namespace TradingEngine.API.Controllers
{
    public class TradingController : ApiController
    {
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IUserRepository _userRepository;

        public TradingController(ICurrencyRepository currencyRepository,IUserRepository userRepository)
        {
            _currencyRepository = currencyRepository;
            _userRepository = userRepository;
           
        }
      

        [HttpPost]
        public IHttpActionResult SendMoneyToOthers(Money money,string toUsername,string fromUsername)
        {
            //initialize
            Currency usd = new Currency("USD", (decimal)1.0);
            Currency eur = new Currency("EUR", (decimal)1.5);
            Currency php = new Currency("PHP", (decimal)0.02);

            _currencyRepository.Save(usd);
            _currencyRepository.Save(eur);
            _currencyRepository.Save(php);

            // sender initialize
            Balance myBalance = new Balance();
            myBalance.AddMoney(new Money(usd, 20));
            myBalance.AddMoney(new Money(eur, 100));

            // recipient initialize
            Balance toBalance = new Balance();
            toBalance.AddMoney(new Money(usd, 0));
            toBalance.AddMoney(new Money(eur, 0));

            //Send Money
            myBalance.ChargeMoney(money); //the input parameter
            toBalance.AddMoney(money);

            _userRepository.Save(new User(fromUsername, myBalance));
            _userRepository.Save(new User(toUsername, toBalance));
                       
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult StoreAndExchangeMoney(Money moneyFrom,string username)
        {
            //initialize
            Currency usd = new Currency("USD", (decimal)1.0);
            Currency eur = new Currency("EUR", (decimal)1.5);
            Currency php = new Currency("PHP", (decimal)0.02);

            _currencyRepository.Save(usd);
            _currencyRepository.Save(eur);
            _currencyRepository.Save(php);

            // initialize
            Balance myBalance = new Balance();
            myBalance.AddMoney(new Money(usd, 20));
            myBalance.AddMoney(new Money(eur, 100));
            myBalance.AddMoney(new Money(php, 0));


            //change to PHP
            myBalance.Exchange(moneyFrom,php);

            _userRepository.Save(new User(username, myBalance));

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetMyBalance(string username) 
        {
            //initialize
            Currency usd = new Currency("USD", (decimal)1.0);
            Currency eur = new Currency("EUR", (decimal)1.5);
            Currency php = new Currency("PHP", (decimal)0.02);

            _currencyRepository.Save(usd);
            _currencyRepository.Save(eur);
            _currencyRepository.Save(php);

            // initialize
            Balance myBalance = new Balance();
            myBalance.AddMoney(new Money(usd, 20));
            myBalance.AddMoney(new Money(eur, 100));
            myBalance.AddMoney(new Money(php, 0));

            _userRepository.Save(new User(username, myBalance));

            // get balance
            var user = _userRepository.FindByUsername(username);

            var result = user.GetBalance()["php"];
            
            return Ok(result);
        }

    }
}