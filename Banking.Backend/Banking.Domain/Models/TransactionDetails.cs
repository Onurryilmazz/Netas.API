using System.ComponentModel.DataAnnotations.Schema;

namespace Banking.Domain.Models;

[Table("Banking.TransactionDetails")]
public class TransactionDetail
{
    public int ID { get; set; }
    public int TransactionId { get; set; }
    public int TransactionTypeId { get; set; }
    public int StatusId { get; set; }
    public int Amount { get; set; }
}