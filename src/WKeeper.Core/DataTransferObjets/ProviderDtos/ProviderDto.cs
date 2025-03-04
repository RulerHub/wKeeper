using wKeeper.Core.DataTransferObjets.PurchaseDtos;

namespace wKeeper.Core.DataTransferObjets.ProviderDtos
{
    public class ProviderDto
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;

        public List<PurchaseDto>? Buys { get; set; } = [];
    }
}