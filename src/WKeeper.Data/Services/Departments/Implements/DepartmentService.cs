using Microsoft.EntityFrameworkCore;
using WKeeper.Core.Entities.Warehouses;
using WKeeper.Data.Data;
using WKeeper.Data.Services.Departments.Interfaces;

namespace WKeeper.Data.Services.Departments.Implements;

public class DepartmentService(ApplicationDbContext context) : IDepartmentService
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Department?> CreateAsync(Department model)
    {
        await _context.Departments.AddAsync(model);
        await _context.SaveChangesAsync();
        return model;
    }

    public async Task<Department> DeleteAsync(int id)
    {
        var query = await GetByIdAsync(id);
        if (query is null)
        {
            return null;
        }
        _context.Departments.Remove(query);
        await _context.SaveChangesAsync();
        return query;
    }

    public async Task<List<Department>> GetAsync()
    {
        return await _context.Departments.ToListAsync();
    }

    public async Task<Department?> GetByIdAsync(int id)
    {
        return await _context.Departments.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Department?> UpdateAsync(int id, Department model)
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
