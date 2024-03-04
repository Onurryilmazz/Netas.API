using Banking.Application.Interfaces.Repositories;
using Banking.Domain.Models;
using Banking.Infrastructure.Context;

namespace Banking.Infrastructure.Repositories;

public class StatuRepository : GenericRepository<Statu, Statu>, IStatuRepository
{
    public StatuRepository(BankingDataContext context) : base(context)
    {
    }
}
