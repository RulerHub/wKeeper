using WKeeper.Core.Entities.Warehouses;

namespace WKeeper.Data.Services.Departments.Interfaces;

public interface IDepartmentService
{
    Task<List<Department>> GetAsync();
    Task<Department?> GetByIdAsync(int id);
    Task<Department?> CreateAsync(Department model);
    Task<Department?> UpdateAsync(int id, Department model);
    Task<Department> DeleteAsync(int id);
}
