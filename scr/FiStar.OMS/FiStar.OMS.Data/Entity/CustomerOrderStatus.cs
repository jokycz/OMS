using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace FiStar.OMS.Data.Entity;

public class CustomerOrderStatus
{
    public int CustomerOrderStatusId { get; set; }

    [Required]
    [StringLength(50)] 
    public string StatusName { get; set; } = null!;

    public static void Builder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerOrderStatus>(entity =>
        {
            entity.HasKey(e => e.CustomerOrderStatusId).HasName("PK_customer_order_status");
            entity.ToTable("customer_order_status");
            entity.Property(e => e.CustomerOrderStatusId).HasColumnName("customer_order_status_id");
            entity.Property(e => e.StatusName).HasColumnName("status_name").HasMaxLength(50);
        });
    }
}