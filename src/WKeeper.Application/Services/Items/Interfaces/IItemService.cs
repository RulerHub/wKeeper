using wKeeper.Core.DataTransferObjets.ItemDtos;
using wKeeper.Core.Entities.Warehouses;

namespace wKeeper.Application.Services.Items.Interfaces;

public interface IItemService
{
    Task<List<Item>> GetAsync();
    Task<Item?> GetByIdAsync(int id);
    Task<Item?> CreateAsync(Item model);
    Task<Item?> UpdateAsync(int id, UpdateItemDto model);
    Task<Item> DeleteAsync(int id);
}
