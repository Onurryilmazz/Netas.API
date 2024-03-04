using Banking.Application.Interfaces.Repositories;
using Banking.Domain.Models;
using Banking.Infrastructure.Context;

namespace Banking.Infrastructure.Repositories;

public class TransactionDetailRepository : GenericRepository<TransactionDetail, TransactionDetail>, ITransactionDetailRepository
{
    public TransactionDetailRepository(BankingDataContext context) : base(context)
    {
    }
}
