using System.ComponentModel.DataAnnotations.Schema;
using wKeeper.Core.Entities.Abstractions;

namespace wKeeper.Core.Entities.Logistic;

public class ReturnItem : Entity
{
    public int IdReturn { get; set; }

    [Column(TypeName = "decimal(8, 5)")]
    public decimal Amount { get; set; }
    [Column(TypeName = "decimal(8, 2)")]
    public decimal Price { get; set; }

    public DateTime ReturnDate { get; set; } = DateTime.Now;
}