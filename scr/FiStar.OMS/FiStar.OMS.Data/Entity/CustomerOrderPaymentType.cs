using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace FiStar.OMS.Data.Entity;

public class CustomerOrderPaymentType
{
    public int CustomerOrderPaymentTypeId { get; set; }

    [Required]
    [StringLength(50)]
    public string PaymentTypeName { get; set; } = null!;

    public static void Builder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerOrderPaymentType>(entity =>
        {
            entity.HasKey(e => e.CustomerOrderPaymentTypeId).HasName("PK_customer_order_payment_type");
            entity.ToTable("customer_order_payment_type");
            entity.Property(e => e.CustomerOrderPaymentTypeId).HasColumnName("customer_order_payment_type_id");
            entity.Property(e => e.PaymentTypeName).HasColumnName("payment_type_name").HasMaxLength(50);
        });
    }

}