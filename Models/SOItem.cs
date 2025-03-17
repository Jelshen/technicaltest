using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesOrder.Models
{
    [Table("SO_ITEM")]
    public class SOItem
    {
        [Key]
        [Column("SO_ITEM_ID")]
        public long SOItemId { get; set; }

        [Column("SO_ORDER_ID")]
        public long SOOrderId { get; set; }

        [Column("ITEM_NAME")]
        public required string ItemName { get; set; }

        [Column("QUANTITY")]
        public int Quantity { get; set; }

        [Column("PRICE")]
        public double Price { get; set; }
    }
}
