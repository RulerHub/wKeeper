using System.ComponentModel.DataAnnotations.Schema;
using WKeeper.Core.Entities.Abstractions;
using WKeeper.Core.Entities.Enterprices;

namespace WKeeper.Core.Entities.Warehouses;

public class Department : Entity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public int EnterpriceId { get; set; }
    public Enterprice? Enterprice { get; set; }

    public List<Item> Items { get; set; } = [];
    public List<Category> Categories { get; set; } = [];

    [Column(TypeName = "decimal(8, 2)")]
    public decimal DepartmentPrice { get; set; }
}
