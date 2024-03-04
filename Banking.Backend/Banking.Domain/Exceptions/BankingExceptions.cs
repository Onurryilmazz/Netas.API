namespace Banking.Domain.Exceptions;

public class BankingExceptions : Exception
{
    
    public BankingExceptions()
    {
    }

    public BankingExceptions(string message) : base(message)
    {
    }


    public BankingExceptions(string message, Exception innerException) : base(message, innerException)
    {
    }
    
}