using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security;

namespace SalesOrder.Models
{
    [Table("SO_ORDER")]
    public class SOOrder
    {
        [Key]
        [Column("SO_ORDER_ID")]
        public long SOOrderId { get; set; }

        [Column("ORDER_NO")]
        public required string OrderNo{ get; set; }

        [Column("ORDER_DATE")]
        public required DateTime OrderDate{ get; set; }

        [Column("COM_CUSTOMER_ID")]
        public int COMCustomerId { get; set; }

        [Column("ADDRESS")]
        public required string Address { get; set; }
    }
}
