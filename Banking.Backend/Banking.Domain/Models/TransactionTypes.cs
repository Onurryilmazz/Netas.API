using System.ComponentModel.DataAnnotations.Schema;

namespace Banking.Domain.Models;

[Table("Banking.TransactionTypes")]
public class TransactionType
{
    public int Id { get; set; }
    public string TransactionTypeName { get; set; }
}

public enum TransactionTypeEnum
{
    Sale = 1,
    Refund = 2,
    Cancel = 3
}