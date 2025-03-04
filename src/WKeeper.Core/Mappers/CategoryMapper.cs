using wKeeper.Core.DataTransferObjets.CategoryDtos;
using WKeeper.Core.Entities.Warehouses;

namespace wKeeper.Core.Mappers;

public static class CategoryMapper
{
    public static CategoryDto ToModelDto(this Category model)
    {
        return new CategoryDto
        {
            Id = model.Id,
            Name = model.Name,
            Description = model.Description,
            CreateAt = model.DateCreate,
            Items = model.Items.Select(c => c.ToModelDto()).ToList()
        };
    }

    public static Category ToModelFromCreateDto(this CreateCategoryDto create)
    {
        return new Category
        {
            Name = create.Name,
            Description = create.Description,
        };
    }
}
