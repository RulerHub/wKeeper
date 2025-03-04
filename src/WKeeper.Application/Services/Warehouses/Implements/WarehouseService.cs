using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WKeeper.Application.Data;
using WKeeper.Application.Services.Enterprices.Interfaces;
using WKeeper.Application.Services.Warehouses.Interfaces;
using WKeeper.Core.Entities.Identity;
using WKeeper.Core.Entities.Warehouses;

namespace WKeeper.Application.Services.Warehouses.Implements;

public class WarehouseService(
    ApplicationDbContext context,
    UserManager<ApplicationUser> userManager,
    IEnterpriceService enterpriceService,
    AuthenticationStateProvider authenticationStateProvider) : IWarehouseService
{
    private readonly ApplicationDbContext _context = context;
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly IEnterpriceService _enterpriceService = enterpriceService;
    private readonly AuthenticationStateProvider _authenticationStateProvider = authenticationStateProvider;

    public async Task<int> GetEnterpriseIdAsync()
    {
        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync().ConfigureAwait(false);
        var user = authState.User;
        var appUser = await _userManager.GetUserAsync(user).ConfigureAwait(false);
        var enterpriceModel = await _enterpriceService.GetEnterpriceAsync(appUser.Id).ConfigureAwait(false);
        return enterpriceModel.Id;
    }

    public async Task<Warehouse?> CreateAsync(Warehouse model)
    {
        try
        {
            model.EnterpriceId = await GetEnterpriseIdAsync().ConfigureAwait(false);
            await _context.Warehouses.AddAsync(model).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return model;
        }
        catch (Exception ex)
        {
            // Log the exception (logging mechanism not shown here)
            return null;
        }
    }

    public async Task<Warehouse?> DeleteAsync(int id)
    {
        try
        {
            var warehouse = await GetByIdAsync(id).ConfigureAwait(false);
            if (warehouse is null)
            {
                return null;
            }
            if (warehouse.Departments.Count > 0 || warehouse.Departments.Count > 0 || warehouse.Items.Count > 0)
            {
                return null;
            }
            _context.Warehouses.Remove(warehouse);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return warehouse;
        }
        catch (Exception)
        {
            // Log the exception (logging mechanism not shown here)
            return null;
        }
    }

    public async Task<List<Warehouse>> GetAsync()
    {
        var enterpriseId = await GetEnterpriseIdAsync().ConfigureAwait(false);

        return await _context.Warehouses
            .Where(c => c.EnterpriceId == enterpriseId)
            .Include(c => c.Categories)
            .Include(c => c.Departments)
            .Include(c => c.Items)
            .ToListAsync().ConfigureAwait(false);
    }

    public async Task<Warehouse?> GetByIdAsync(int id)
    {
        return await _context.Warehouses
            .Include(c => c.Categories)
            .Include(c => c.Departments)
            .Include(c => c.Items)
            .FirstOrDefaultAsync(c => c.Id == id).ConfigureAwait(false);
    }

    public async Task<Warehouse?> UpdateAsync(int id, Warehouse model)
    {
        try
        {
            var warehouse = await GetByIdAsync(id).ConfigureAwait(false);
            if (warehouse is null)
            {
                return null;
            }

            warehouse.Name = model.Name;
            warehouse.DateUpdate = DateTime.Now;

            await _context.SaveChangesAsync().ConfigureAwait(false);
            return warehouse;
        }
        catch (Exception ex)
        {
            // Log the exception (logging mechanism not shown here)
            return null;
        }
    }
}
