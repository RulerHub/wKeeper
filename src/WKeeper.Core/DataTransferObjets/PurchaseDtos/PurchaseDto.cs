using System.ComponentModel.DataAnnotations.Schema;
using wKeeper.Core.DataTransferObjets.ProviderDtos;
using wKeeper.Core.DataTransferObjets.PurchaseItemDtos;

namespace wKeeper.Core.DataTransferObjets.PurchaseDtos;

public class PurchaseDto
{
    public string Code { get; set; } = string.Empty;

    public DateTime PurchaseDate { get; set; }
    [Column(TypeName = "decimal(8, 2)")]
    public decimal TotalPrice { get; set; }

    public int? ProviderId { get; set; }
    public ProviderDto? Provider { get; set; }

    public List<PurchaseItemDto> PurchaseItems { get; set; } = [];

    public bool IsActive { get; set; }
    public bool ItsPaid { get; set; }
}
