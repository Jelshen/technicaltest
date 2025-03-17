using Microsoft.EntityFrameworkCore;
using SalesOrder.Models;

namespace SalesOrder.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<SOOrder> SOOrders { get; set; }
        public DbSet<SOItem> SOItems { get; set; }
        public DbSet<COMCustomer> COMCustomers { get; set; }

        /* protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SOOrder>()
                .Property(e => e.SOOrderId)
                .HasColumnName("SO_ORDER_ID");

            modelBuilder.Entity<SOOrder>()
                .Property(e => e.OrderNo)
                .HasColumnName("ORDER_NO");

            modelBuilder.Entity<SOOrder>()
                .Property(e => e.OrderDate)
                .HasColumnName("ORDER_DATE");

            modelBuilder.Entity<SOOrder>()
                .Property(e => e.COMCustomerId)
                .HasColumnName("COM_CUSTOMER_ID");

            modelBuilder.Entity<SOOrder>()
                .Property(e => e.Address)
                .HasColumnName("ADDRESS");
        } */
    }
}
