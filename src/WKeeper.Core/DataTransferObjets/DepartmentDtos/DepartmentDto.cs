using wKeeper.Core.DataTransferObjets.ItemDtos;

namespace wKeeper.Core.DataTransferObjets.DepartmentDtos;

public class DepartmentDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public List<ItemDto> Items { get; set; } = [];
    public DateTime CreateAt { get; set; }
}
