using wKeeper.Core.DataTransferObjets.ItemDtos;
using WKeeper.Core.Entities.Warehouses;

namespace wKeeper.Core.Mappers;

public static class ItemMapper
{
    public static ItemDto ToModelDto(this Item model)
    {
        return new ItemDto
        {
            Id = model.Id,
            Name = model.Name,
            Description = model.Description,
            Code = model.Code,
            MeasureUnit = model.MeasureUnit,
            Amount = model.Amount,
            Price = model.Price,
        };
    }

    public static Item ToModelFromCreateDto(this CreateItemDto create)
    {
        return new Item
        {
            Code = create.Code,
            Name = create.Name,
            Description = create.Description,
            MeasureUnit = create.MeasureUnit,
        };
    }
}
