using Banking.Application.Interfaces.Repositories;
using Banking.Application.Models.RequestModels;
using Banking.Domain.Models;
using Banking.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Banking.Infrastructure.Repositories;

public class TransactionRepository : GenericRepository<Transaction, Transaction>, ITransactionRepository
{
    public TransactionRepository(BankingDataContext context) : base(context)
    {
    }

    public async Task<Transaction> GetMaxIdTransactionWithOrder(int orderId)
    {
        var result = await _context.Transactions.OrderByDescending(x => x.ID).FirstOrDefaultAsync(x => x.OrderReferenceId == orderId);
        return result;
    }

    public async Task<bool> UpdateOrderNetAmount(int orderId, int netAmount)
    {
        var result = await  _context.Transactions.Where(x => x.OrderReferenceId == orderId).ToListAsync();
        result.ForEach(x => x.NetAmount = netAmount);
        return true;
    }
}
