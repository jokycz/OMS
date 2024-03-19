using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace FiStar.OMS.Data.Entity;

public class CustomerOrderDeliveryType
{
    public int CustomerOrderDeliveryTypeId { get; set; }

    [Required]
    [StringLength(50)]
    public string DeliveryTypeName { get; set; } = null!;

    public int? CarrierServicesId { get; set; }

    public static void Builder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerOrderDeliveryType>(entity =>
        {
            entity.HasKey(e => e.CustomerOrderDeliveryTypeId).HasName("PK_customer_order_delivery_type");
            entity.ToTable("customer_order_delivery_type");
            entity.Property(e => e.CustomerOrderDeliveryTypeId).HasColumnName("customer_order_delivery_type_id");
            entity.Property(e => e.DeliveryTypeName).HasColumnName("delivery_type_name").HasMaxLength(50);
            entity.Property(e => e.CarrierServicesId).HasColumnName("carrier_services_id");
        });
    }
}