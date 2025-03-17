using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesOrder.Models
{
    [Table("COM_CUSTOMER")]
    public class COMCustomer
    {
        [Key]
        [Column("COM_CUSTOMER_ID")]
        public int ComCustomerId{ get; set; }

        [Column("CUSTOMER_NAME")]
        public string? CustomerName { get; set; }
    }
}
