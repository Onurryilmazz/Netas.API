namespace Banking.Application.Models.ResponseModels;

public class ReportResponse
{
    public int BankId { get; set; }
    public int TransactionId { get; set; }
    public int NetAmount { get; set; }
}