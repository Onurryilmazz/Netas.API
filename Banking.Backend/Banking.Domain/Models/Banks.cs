using System.ComponentModel.DataAnnotations.Schema;

namespace Banking.Domain.Models;

[Table("Banking.Banks")]
public class Bank
{
    public int ID { get; set; }
    public string Name { get; set; }
}

public enum BanksEnum
{
    Akbank = 1,
    Garanti = 2,
    YapıKredi = 3,
}