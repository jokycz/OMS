using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace FiStar.OMS.Data.Entity;

public class CustomerOrderPaymentStatus
{
    public int CustomerOrderPaymentStatusId { get; set; }

    [Required]
    [StringLength(50)]
    public string PaymentStatusName { get; set; } = null!;

    public static void Builder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerOrderPaymentStatus>(entity =>
        {
            entity.HasKey(e => e.CustomerOrderPaymentStatusId).HasName("PK_customer_order_payment_status");
            entity.ToTable("customer_order_payment_status");
            entity.Property(e => e.CustomerOrderPaymentStatusId).HasColumnName("customer_order_payment_status_id");
            entity.Property(e => e.PaymentStatusName).HasColumnName("payment_status_name").HasMaxLength(50);
        });
    }
}