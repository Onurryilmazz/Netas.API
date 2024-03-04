using System.ComponentModel.DataAnnotations.Schema;

namespace Banking.Domain.Models;

[Table("Banking.Logs")]
public class Log
{
    public int ID { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
}