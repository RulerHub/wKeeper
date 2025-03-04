namespace wKeeper.Core.DataTransferObjets.ItemDtos;

public class CreateItemDto
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string MeasureUnit { get; set; } = string.Empty;
}
