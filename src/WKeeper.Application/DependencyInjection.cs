using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WKeeper.Application.Data;
using WKeeper.Application.Services.Categories.Implements;
using WKeeper.Application.Services.Categories.Interfaces;
using WKeeper.Application.Services.Departments.Implements;
using WKeeper.Application.Services.Departments.Interfaces;
using WKeeper.Application.Services.Enterprices.Implements;
using WKeeper.Application.Services.Enterprices.Interfaces;
using WKeeper.Application.Services.Items.Implements;
using WKeeper.Application.Services.Items.Interfaces;
using WKeeper.Application.Services.Warehouses.Implements;
using WKeeper.Application.Services.Warehouses.Interfaces;

namespace WKeeper.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddAplication(this IServiceCollection services)
    {
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IDepartmentService, DepartmentService>();
        services.AddScoped<IEnterpriceService, EnterpriceService>();
        services.AddScoped<IItemService, ItemService>();
        services.AddScoped<IWarehouseService, WarehouseService>();

        return services;
    }

    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        // Db context configuration
        var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString)
            .ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning)));
        services.AddDatabaseDeveloperPageExceptionFilter();

        return services;
    }
}
