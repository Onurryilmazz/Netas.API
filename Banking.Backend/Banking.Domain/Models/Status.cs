using System.ComponentModel.DataAnnotations.Schema;

namespace Banking.Domain.Models;

[Table("Banking.Status")]
public class Statu
{
    public int Id { get; set; }
    public string StatuName { get; set; }
}

public enum StatusEnum
{
    Active = 1,
    Failed = 2,
}