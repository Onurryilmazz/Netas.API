using Banking.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Banking.Infrastructure.Context;

public class BankingDataContext : DbContext
{
    public BankingDataContext(DbContextOptions<BankingDataContext> options) : base(options)
    {
    }
    
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Bank> Banks { get; set; }
    public DbSet<TransactionType> TransactionTypes { get; set; }
    public DbSet<TransactionDetail> TransactionDetails { get; set; }
    public DbSet<Statu> Status { get; set; }
    public DbSet<Log> Logs { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}