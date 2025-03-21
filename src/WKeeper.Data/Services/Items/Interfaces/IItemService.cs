﻿using RulerHub.Shared.Entities.Warehouses;

namespace WKeeper.Data.Services.Items.Interfaces;

public interface IItemService
{
    Task<List<Item>> GetAsync();
    Task<Item?> GetByIdAsync(int id);
    Task<Item?> CreateAsync(Item model);
    Task<Item?> UpdateAsync(int id, Item model);
    Task<Item> DeleteAsync(int id);
}
