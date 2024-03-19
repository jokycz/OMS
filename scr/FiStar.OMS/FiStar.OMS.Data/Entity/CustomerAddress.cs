using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace FiStar.OMS.Data.Entity;

public class CustomerAddress
{
    public int CustomerAddressId { get; set; }

    public int CustomerId { get; set; }

    public int CustomerAddressTypeId { get; set; }

    [Required] [StringLength(200)] public string AddressName { get; set; } = string.Empty;

    [StringLength(200)] public string? AddressName1 { get; set; }

    [StringLength(200)] public string? AddressStreet { get; set; }

    [Required]
    [StringLength(200)] public string AddressCity { get; set; } = string.Empty;

    [StringLength(200)] public string? AddressDistrict { get; set; } 


    [Required]
    [StringLength(20)] public string AddressZip { get; set; } = string.Empty;

    public int?  CountryId { get; set; }

    public virtual Customer? CustomerNavigation { get; set; }
    public virtual CustomerAddressType? CustomerAddressTypeNavigation { get; set; }
    public virtual Country? CountryNavigation { get; set; } 

    public static void Builder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerAddress>(entity =>
        {
            entity.HasKey(e => e.CustomerAddressId).HasName("PK_customer_address");
            entity.ToTable("customer_address");
            entity.Property(e => e.CustomerAddressId).HasColumnName("customer_address_id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.CustomerAddressTypeId).HasColumnName("customer_address_type_id");
            entity.Property(e => e.AddressName).HasColumnName("address_name").HasMaxLength(200);
            entity.Property(e => e.AddressName1).HasColumnName("address_name1").HasMaxLength(200);
            entity.Property(e => e.AddressStreet).HasColumnName("address_street").HasMaxLength(200);
            entity.Property(e => e.AddressCity).HasColumnName("address_city").HasMaxLength(200);
            entity.Property(e => e.AddressDistrict).HasColumnName("address_district").HasMaxLength(200);
            entity.Property(e => e.AddressZip).HasColumnName("address_zip").HasMaxLength(20);
            entity.Property(e => e.CountryId).HasColumnName("country_id");

            entity.HasOne(d => d.CustomerNavigation)
                .WithMany(p => p.CustomerAddresses)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_customer_address_customer");

            entity.HasOne(d => d.CustomerAddressTypeNavigation)
                .WithOne()
                .HasForeignKey<CustomerAddress>(d => d.CustomerAddressTypeId)
                .HasConstraintName("FK_customer_address_customer_address_type").OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(d => d.CountryNavigation)
                .WithOne()
                .HasForeignKey<CustomerAddress>(d => d.CountryId)
                .HasConstraintName("FK_customer_address_country").OnDelete(DeleteBehavior.NoAction);
        });
    }
}