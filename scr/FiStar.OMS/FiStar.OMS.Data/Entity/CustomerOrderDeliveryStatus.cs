using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace FiStar.OMS.Data.Entity;

public class CustomerOrderDeliveryStatus
{
    public int CustomerOrderDeliveryStatusId { get; set; }

    [Required]
    [StringLength(50)]
    public string StatusName { get; set; } = null!;

    public static void Builder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerOrderDeliveryStatus>(entity =>
        {
            entity.HasKey(e => e.CustomerOrderDeliveryStatusId).HasName("PK_customer_order_delivery_status");
            entity.ToTable("customer_order_delivery_status");
            entity.Property(e => e.CustomerOrderDeliveryStatusId).HasColumnName("customer_order_delivery_status_id");
            entity.Property(e => e.StatusName).HasColumnName("status_name").HasMaxLength(50);
        });
    }
}