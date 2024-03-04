using Banking.Application.Interfaces.Repositories;
using Banking.Domain.Models;
using Banking.Infrastructure.Context;

namespace Banking.Infrastructure.Repositories;

public class BankRepository : GenericRepository<Bank, Bank>, IBankRepository
{
    public BankRepository(BankingDataContext context) : base(context)
    {
    }
}
