namespace wKeeper.Core.DataTransferObjets.ItemDtos;

public class ItemDto
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public string MeasureUnit { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public decimal Price { get; set; }
}
