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
    public DbSet<Session> sessions {get; set;}
    public DbSet<Client> clients {get; set;}
    public DbSet<Device> devices {get; set;}


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=192.168.1.101,1433;Database=UserManagement;User Id=dev;Password=P@ssw0rd;TrustServerCertificate=True;");
    }
}
