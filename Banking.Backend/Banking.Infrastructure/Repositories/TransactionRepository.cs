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

    public async Task<Transaction> GetTransactionByCancelRequest(CancelRequest request)
    {
        var result = await _context.Transactions.FirstOrDefaultAsync(
            x=> x.ID == request.TransactionId && x.TranscationDate.Date == DateTime.Now.Date);
        
        return result;
    }
}
