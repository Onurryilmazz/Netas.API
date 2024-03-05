namespace Banking.Application.Models.RequestModels;

public class CancelRequest
{
    public int BankId { get; set; }
    public int TransactionId { get; set; }
}