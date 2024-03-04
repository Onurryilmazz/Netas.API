using Banking.Domain.Models;

namespace Banking.Application.Interfaces.Repositories;

public interface ITransactionRepository : IGenericRepository<Transaction,Transaction>
{
    
}