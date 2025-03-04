using wKeeper.Core.Entities.Abstractions;
using wKeeper.Core.Entities.Identity;
using wKeeper.Core.Entities.Warehouses;

namespace wKeeper.Core.Entities.Enterprices;

public class Enterprice : Entity
{
    public required string Name { get; set; }
    public required string Description { get; set; }

    public string? UserId { get; set; }
    public ApplicationUser? User { get; set; }

    public List<Warehouse> Warehouses { get; set; } = [];
}
