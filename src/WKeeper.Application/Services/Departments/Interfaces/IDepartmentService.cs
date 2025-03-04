
using wKeeper.Core.DataTransferObjets.DepartmentDtos;
using wKeeper.Core.Entities.Warehouses;

namespace wKeeper.Application.Services.Departments.Interfaces;

public interface IDepartmentService
{
    Task<List<Department>> GetAsync();
    Task<Department?> GetByIdAsync(int id);
    Task<Department?> CreateAsync(Department model);
    Task<Department?> UpdateAsync(int id, UpdateDepartmentDto model);
    Task<Department> DeleteAsync(int id);
}
