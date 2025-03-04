
using wKeeper.Core.DataTransferObjets.CategoryDtos;
using wKeeper.Core.Entities.Warehouses;

namespace wKeeper.Application.Services.Categories.Interfaces;

public interface ICategoryService
{
    Task<List<Category>> GetAsync();
    Task<Category?> GetByIdAsync(int id);
    Task<Category?> CreateAsync(Category model);
    Task<Category?> UpdateAsync(int id, UpdateCategoryDto model);
    Task<Category> DeleteAsync(int id);
}
