using WKeeper.Core.Entities.Warehouses;

namespace WKeeper.Data.Services.Categories.Interfaces;

public interface ICategoryService
{
    Task<List<Category>> GetAsync();
    Task<Category?> GetByIdAsync(int id);
    Task<Category?> CreateAsync(Category model);
    Task<Category?> UpdateAsync(int id, Category model);
    Task<Category> DeleteAsync(int id);
}
