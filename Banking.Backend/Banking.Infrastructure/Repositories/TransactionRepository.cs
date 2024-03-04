using Banking.Application.Interfaces.Repositories;
using Banking.Domain.Models;
using Banking.Infrastructure.Context;

namespace Banking.Infrastructure.Repositories;

public class TransactionRepository : GenericRepository<Transaction, Transaction>, ITransactionRepository
{
    public TransactionRepository(BankingDataContext context) : base(context)
    {
    }
}
