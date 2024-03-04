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
    Success = 1,
    Fail = 2,
}