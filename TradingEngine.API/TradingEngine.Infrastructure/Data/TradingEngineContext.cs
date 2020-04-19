using Microsoft.EntityFrameworkCore;
using TradingEngine.Domain.Entities;

namespace TradingEngine.Infrastructure.Data
{
    public class TradingEngineContext : DbContext
    {
        public TradingEngineContext(DbContextOptions<TradingEngineContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Currency> Currencies { get; set; }
    }
}
