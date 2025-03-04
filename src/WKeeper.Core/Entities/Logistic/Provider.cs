using WKeeper.Core.Entities.Abstractions;

namespace WKeeper.Core.Entities.Logistic;

public class Provider : Entity
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;

    public List<Purchase>? Buys { get; set; } = [];
}
