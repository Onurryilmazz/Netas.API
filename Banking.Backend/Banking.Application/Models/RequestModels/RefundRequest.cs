namespace Banking.Application.Models.RequestModels;

public class RefundRequest
{
    public int BankId { get; set; }
    public int OrderId { get; set; }
    public int RefundAmount { get; set; }
}