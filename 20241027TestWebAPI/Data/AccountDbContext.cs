using System;
using _20241027TestWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace _20241027TestWebAPI.Data
{
    public class AccountDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        
        // Updated to PascalCase
        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<AccountDetails> AccountDetails { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<WebForms> WebForms { get; set; }

        public AccountDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
