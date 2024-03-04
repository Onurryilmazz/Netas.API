using Banking.Application.Interfaces.Repositories;
using Banking.Infrastructure.Context;

namespace Banking.Infrastructure.Repositories;

public class UnitOfWork : IDisposable, IUnitOfWork
{
    
    private bool _disposed = false;
    private readonly BankingDataContext _context;
    
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        _disposed = true;
    }

    public void Save()
    {
        try
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.SaveChanges();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        catch (Exception e)
        {
            // TODO: Hata işleme alanı
        }
    }

    public IBankRepository BankRepository { get; }
    public ITransactionRepository TransactionRepository { get; }
    public ILogRepository LogRepository { get; }
    public IStatuRepository StatuRepository { get; }
    public ITransactionDetailRepository TransactionDetailRepository { get; }
    public ITransactionTypeRepository TransactionTypeRepository { get; }
    
    public UnitOfWork(IBankRepository bankRepository, ITransactionRepository transactionRepository, ILogRepository logRepository, IStatuRepository statuRepository, ITransactionDetailRepository transactionDetailRepository, ITransactionTypeRepository transactionTypeRepository, BankingDataContext context)
    {
        _context = context;
        BankRepository = bankRepository;
        TransactionRepository = transactionRepository;
        LogRepository = logRepository;
        StatuRepository = statuRepository;
        TransactionDetailRepository = transactionDetailRepository;
        TransactionTypeRepository = transactionTypeRepository;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}