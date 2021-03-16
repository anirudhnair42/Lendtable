#nullable enable
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FinalSolution
{
    public class Models
    {
        public class TradingContext : DbContext
        {
            public TradingContext(DbContextOptions<TradingContext> options)
                : base(options)
            {
            }
            public DbSet<Identity> Identitys { get; set; }
            public DbSet<Trade> Trades { get; set; }
            
        }

        public class Identity
        {
            public int Id { get; set; }
            public string Name { get; set; }
            
            public List<Trade> Trades { get; } = new List<Trade>();
        }

        public class Trade
        {
            public int TransactionId { get; set; }
            public string Asset { get; set; }
            public double Value { get; set; }

            public int Id { get; set; }
            public Identity Identity { get; set; }
        }
    }
}