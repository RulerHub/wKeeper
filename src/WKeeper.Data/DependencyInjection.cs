﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WKeeper.Data.Data;
using WKeeper.Data.Services.Categories.Implements;
using WKeeper.Data.Services.Categories.Interfaces;
using WKeeper.Data.Services.Departments.Implements;
using WKeeper.Data.Services.Departments.Interfaces;
using WKeeper.Data.Services.Enterprices.Implements;
using WKeeper.Data.Services.Enterprices.Interfaces;
using WKeeper.Data.Services.Items.Implements;
using WKeeper.Data.Services.Items.Interfaces;
using WKeeper.Data.Services.Warehouses.Implements;
using WKeeper.Data.Services.Warehouses.Interfaces;

namespace WKeeper.Data;

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
