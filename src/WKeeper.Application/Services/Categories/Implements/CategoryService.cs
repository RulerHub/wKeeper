using Microsoft.EntityFrameworkCore;
using WKeeper.Application.Data;
using WKeeper.Application.Services.Categories.Interfaces;
using WKeeper.Core.Entities.Warehouses;

namespace WKeeper.Application.Services.Categories.Implements;

public class CategoryService(ApplicationDbContext context) : ICategoryService
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Category?> CreateAsync(Category model)
    {
        await _context.Categories.AddAsync(model);
        await _context.SaveChangesAsync();
        return model;
    }

    public async Task<Category> DeleteAsync(int id)
    {
        var query = await GetByIdAsync(id);
        if (query is null)
        {
            return null;
        }
        _context.Categories.Remove(query);
        await _context.SaveChangesAsync();
        return query;
    }

    public async Task<List<Category>> GetAsync()
    {
        var query = await _context.Categories
            .Include(i => i.Items)
            .ToListAsync();
        return query;
    }

    public async Task<Category?> GetByIdAsync(int id)
    {
        return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Category?> UpdateAsync(int id, Category model)
    {
        var query = await GetByIdAsync(id);
        if (query is null)
        {
            return null;
        }

        query.Name = model.Name;
        query.Description = model.Description;

        await _context.SaveChangesAsync();

        return query;
    }
}
