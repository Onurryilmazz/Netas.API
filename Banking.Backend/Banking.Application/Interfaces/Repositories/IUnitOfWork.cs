namespace Banking.Application.Interfaces.Repositories;

public interface IUnitOfWork : IDisposable
{
    void Save();
    IBankRepository BankRepository { get; }
    ITransactionRepository TransactionRepository { get; }
    ILogRepository LogRepository { get; }
    IStatuRepository StatuRepository { get; }
    ITransactionDetailRepository TransactionDetailRepository { get; }
    ITransactionTypeRepository TransactionTypeRepository { get; }
}