﻿using Microsoft.EntityFrameworkCore;
using wKeeper.Application.Data;
using wKeeper.Application.Services.Items.Interfaces;
using wKeeper.Core.DataTransferObjets.ItemDtos;
using wKeeper.Core.Entities.Warehouses;

namespace wKeeper.Application.Services.Items.Implements;

public class ItemService(ApplicationDbContext context) : IItemService
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Item?> CreateAsync(Item model)
    {
        await _context.Items.AddAsync(model);
        await _context.SaveChangesAsync();
        return model;
    }

    public async Task<Item> DeleteAsync(int id)
    {
        var query = await GetByIdAsync(id);
        if (query is null)
        {
            return null;
        }
        _context.Items.Remove(query);
        await _context.SaveChangesAsync();
        return query;
    }

    public async Task<List<Item>> GetAsync()
    {
        return await _context.Items.ToListAsync();
    }

    public async Task<Item?> GetByIdAsync(int id)
    {
        return await _context.Items.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Item?> UpdateAsync(int id, UpdateItemDto model)
    {
        var query = await GetByIdAsync(id);
        if (query is null)
        {
            return null;
        }

        query.Code = model.Code;
        query.Name = model.Name;
        query.Description = model.Description;
        query.MeasureUnit = model.MeasureUnit;

        await _context.SaveChangesAsync();
        return query;
    }
}
