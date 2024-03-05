using Banking.Application.Models.RequestModels;
using Banking.Domain.Models;

namespace Banking.Application.Interfaces.Repositories;

public interface ITransactionRepository : IGenericRepository<Transaction,Transaction>
{
    Task<Transaction> GetMaxIdTransactionWithOrder(int orderId);
    Task<bool> UpdateOrderNetAmount(int orderId, int netAmount);
}