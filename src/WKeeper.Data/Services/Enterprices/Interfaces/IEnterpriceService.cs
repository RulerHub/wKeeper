using WKeeper.Core.Entities.Enterprices;

namespace WKeeper.Data.Services.Enterprices.Interfaces;

public interface IEnterpriceService
{
    Task<Enterprice> CreateEnterpriceAsync(string userId, Enterprice enterprice);

    Task<List<Enterprice>> GetAllEnterpricesAsync();

    Task<Enterprice> GetEnterpriceAsync(string userId);
}
