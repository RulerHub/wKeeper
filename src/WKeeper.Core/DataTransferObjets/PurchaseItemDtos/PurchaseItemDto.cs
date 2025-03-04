using System.ComponentModel.DataAnnotations.Schema;

namespace wKeeper.Core.DataTransferObjets.PurchaseItemDtos
{
    public class PurchaseItemDto
    {
        public int IdPurchase { get; set; }

        [Column(TypeName = "decimal(8, 5)")]
        public decimal Amount { get; set; }
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }

        public DateTime PurchaseDate { get; set; } = DateTime.Now;
    }
}