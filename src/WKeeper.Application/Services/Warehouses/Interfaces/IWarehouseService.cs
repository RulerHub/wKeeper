﻿using wKeeper.Core.Entities.Warehouses;

namespace wKeeper.Application.Services.Warehouses.Interfaces;

public interface IWarehouseService
{
    Task<List<Warehouse>> GetAsync();
    Task<Warehouse?> GetByIdAsync(int id);
    Task<Warehouse?> CreateAsync(Warehouse model);
    Task<Warehouse?> UpdateAsync(int id, Warehouse model);
    Task<Warehouse> DeleteAsync(int id);
}
