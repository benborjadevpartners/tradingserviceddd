using System;
using System.Collections.Generic;
using System.Text;
using TradingEngine.Domain.Entities;
using TradingEngine.Domain.Interfaces;
using TradingEngine.Infrastructure.Data;
using System.Linq;

namespace TradingEngine.Infrastructure.Repository
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly TradingEngineContext _context;
        public CurrencyRepository(TradingEngineContext context)
        {
            _context = context;
        }

        public void Save(Currency currency)
        {
            _context.Currencies.Add(currency);
            _context.SaveChangesAsync();
        }
    }
}
