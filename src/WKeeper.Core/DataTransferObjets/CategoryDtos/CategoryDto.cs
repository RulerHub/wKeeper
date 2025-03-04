using wKeeper.Core.DataTransferObjets.ItemDtos;

namespace wKeeper.Core.DataTransferObjets.CategoryDtos;

public class CategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public List<ItemDto> Items { get; set; } = [];
    public DateTime CreateAt { get; set; } = DateTime.Now;
}
