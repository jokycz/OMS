using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace FiStar.OMS.Data.Entity;

public class CustomerAddressType
{
    public int CustomerAddressTypeId { get; set; }

    [Required]
    [StringLength(50)]
    public string AddressTypeName { get; set; } = null!;

    public bool IsInvoicing { get; set; } = false;

    public static void Builder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerAddressType>(entity =>
        {
            entity.HasKey(e => e.CustomerAddressTypeId).HasName("PK_customer_address_type");
            entity.ToTable("customer_address_type");
            entity.Property(e => e.CustomerAddressTypeId).HasColumnName("customer_address_type_id");
            entity.Property(e => e.AddressTypeName).HasColumnName("address_type_name").HasMaxLength(50);
            entity.Property(e => e.IsInvoicing).HasColumnName("is_invoicing");
        });
    }
}