namespace Banking.Application.Models.RequestModels;

public class ReportFilterRequest
{
    public string BankName { get; set; }
    public string StatuName { get; set; }
    public string OrderReference { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    
}