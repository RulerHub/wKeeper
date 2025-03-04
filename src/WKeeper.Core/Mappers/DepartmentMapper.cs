using wKeeper.Core.DataTransferObjets.DepartmentDtos;
using wKeeper.Core.Entities.Warehouses;

namespace wKeeper.Core.Mappers;

public static class DepartmentMapper
{
    public static DepartmentDto ToModelDto(this Department model)
    {
        return new DepartmentDto
        {
            Id = model.Id,
            Name = model.Name,
            Description = model.Description,
            CreateAt = model.DateCreate,
            Items = model.Items.Select(c => c.ToModelDto()).ToList()
        };
    }

    public static Department ToModelFromCreateDto(this CreateDepartmentDto model)
    {
        return new Department
        {
            Name = model.Name,
            Description = model.Description,
        };
    }
}
