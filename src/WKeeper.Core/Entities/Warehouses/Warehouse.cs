using System.ComponentModel.DataAnnotations.Schema;
using wKeeper.Core.Entities.Abstractions;
using wKeeper.Core.Entities.Enterprices;

namespace wKeeper.Core.Entities.Warehouses;

public class Warehouse : Entity
{
    public string Name { get; set; } = string.Empty;

    public int? EnterpriceId { get; set; }
    public Enterprice? Enterprice { get; set; }

    public List<Department> Departments { get; set; } = [];
    public List<Category> Categories { get; set; } = [];
    public List<Item> Items { get; set; } = [];

    [Column(TypeName = "decimal(8, 2)")]
    public decimal WarehousePrice { get; set; }
}
