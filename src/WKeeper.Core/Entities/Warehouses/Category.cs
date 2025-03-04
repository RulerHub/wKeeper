using System.ComponentModel.DataAnnotations.Schema;
using WKeeper.Core.Entities.Abstractions;

namespace WKeeper.Core.Entities.Warehouses;

public class Category : Entity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public List<Item> Items { get; set; } = [];

    [Column(TypeName = "decimal(8, 2)")]
    public decimal CategoryPrice { get; set; }
}
