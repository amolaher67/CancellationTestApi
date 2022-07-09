using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CancellationTestApi.Data
{
    public class CancelTestDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        protected CancelTestDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public CancelTestDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<OrderDetails> OrderDetails { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            }
        }
    }
}
