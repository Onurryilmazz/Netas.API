using Banking.Application.Interfaces.Repositories;
using Banking.Domain.Models;
using Banking.Infrastructure.Context;

namespace Banking.Infrastructure.Repositories;

public class TransactionTypeRepository : GenericRepository<TransactionType, TransactionType>, ITransactionTypeRepository
{
    public TransactionTypeRepository(BankingDataContext context) : base(context)
    {
    }
}
