using System;
using System.Collections.Generic;
using System.Text;
using TradingEngine.Domain.Entities;

namespace TradingEngine.Domain.Interfaces
{
    public interface ICurrencyRepository
    {
        void Save(Currency currency);        
    }
}
