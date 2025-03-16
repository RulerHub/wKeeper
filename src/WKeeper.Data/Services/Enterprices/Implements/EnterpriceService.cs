using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WKeeper.Core.Entities.Enterprices;
using WKeeper.Core.Entities.Identity;
using WKeeper.Data.Data;
using WKeeper.Data.Services.Enterprices.Interfaces;

namespace WKeeper.Data.Services.Enterprices.Implements;

public class EnterpriceService : IEnterpriceService
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public EnterpriceService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<Enterprice> CreateEnterpriceAsync(string userId, Enterprice enterprice)
    {
        // Obtener el número de empresas del usuario de forma eficiente
        var count = await _context.Enterprices.CountAsync(x => x.UserId == userId);

        if (count < 1)
        {
            // Vinculacion 
            enterprice.UserId = userId;

            await _context.Enterprices.AddAsync(enterprice);
            await _context.SaveChangesAsync();
            return enterprice;
        }
        else
        {
            throw new InvalidOperationException("El usuario ya tiene una empresa registrada.");
        }
    }

    public async Task<List<Enterprice>> GetAllEnterpricesAsync()
    {
        return await _context.Enterprices.ToListAsync();
    }

    public async Task<Enterprice> GetEnterpriceAsync(string userId)
    {
        //return await _context.Enterprices.Where(x => x.UserId == userId);
        return await _context.Enterprices.Include(x => x.Warehouses).FirstOrDefaultAsync(x => x.UserId == userId);
    }

}
