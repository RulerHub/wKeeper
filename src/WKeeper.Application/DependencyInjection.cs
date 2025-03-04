using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using wKeeper.Application.Data;
using wKeeper.Application.Services.Categories.Implements;
using wKeeper.Application.Services.Categories.Interfaces;
using wKeeper.Application.Services.Departments.Implements;
using wKeeper.Application.Services.Departments.Interfaces;
using wKeeper.Application.Services.Enterprices.Implements;
using wKeeper.Application.Services.Enterprices.Interfaces;
using wKeeper.Application.Services.Items.Implements;
using wKeeper.Application.Services.Items.Interfaces;
using wKeeper.Application.Services.Warehouses.Implements;
using wKeeper.Application.Services.Warehouses.Interfaces;

namespace wKeeper.Application;

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
