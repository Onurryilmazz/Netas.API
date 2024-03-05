using System.ComponentModel.DataAnnotations.Schema;

namespace Banking.Domain.Models;

[Table("Banking.Transactions")]
public class Transaction
{
    public int ID { get; set; }
    public int BankID { get; set; }
    public int TotalAmount { get; set; }
    public int NetAmount { get; set; }
    public int StatusID { get; set; }
    public int OrderReferenceId { get; set; }
    public DateTime TranscationDate { get; set; }
}