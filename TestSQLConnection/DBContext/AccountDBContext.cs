using System;
using TestSQLConnection.Entity;
using Microsoft.EntityFrameworkCore;

namespace TestSQLConnection.DBContext;

public class AccountDBContext : DbContext
{
    public DbSet<Account> accounts {get; set;}
    public DbSet<AccountDetails> accountDetails {get; set;}
    public DbSet<Country> countries {get; set;}
    public DbSet<WebForm> webForms {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=192.168.31.165,1433;Database=UserManagement;User Id=dev;Password=P@ssw0rd;TrustServerCertificate=True;");
    }
}
