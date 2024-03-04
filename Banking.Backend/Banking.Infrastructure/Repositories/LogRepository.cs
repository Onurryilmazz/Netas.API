using Banking.Application.Interfaces.Repositories;
using Banking.Domain.Models;
using Banking.Infrastructure.Context;

namespace Banking.Infrastructure.Repositories;

public class LogRepository : GenericRepository<Log, Log>, ILogRepository
{
    public LogRepository(BankingDataContext context) : base(context)
    {
    }
}