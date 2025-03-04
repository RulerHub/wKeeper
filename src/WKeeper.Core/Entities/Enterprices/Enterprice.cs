using WKeeper.Core.Entities.Abstractions;
using WKeeper.Core.Entities.Identity;
using WKeeper.Core.Entities.Warehouses;

namespace WKeeper.Core.Entities.Enterprices;

public class Enterprice : Entity
{
    public required string Name { get; set; }
    public required string Description { get; set; }

    public string? UserId { get; set; }
    public ApplicationUser? User { get; set; }

    public List<Warehouse> Warehouses { get; set; } = [];
}
