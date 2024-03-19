using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace FiStar.OMS.Data.Entity;

public class Customer
{
    public int CustomerId { get; set; }

    [Required] [StringLength(200)] public string CustomerName { get; set; } = string.Empty;

    [StringLength(200)]
    public string? CustomerCompany { get; set; }

    [StringLength(20)]
    public string? CustomerCompanyID { get; set; }

    [StringLength(20)]
    public string? CustomerVatID { get; set; }

    [StringLength(20)]
    public string? CustomerTaxID { get; set; }

    [Required]
    [StringLength(400)]
    public string CustomerEmail { get; set; } = null!;

    [Required]
    [StringLength(50)]
    public string CustomerPhone { get; set; } = null!;

    public int ValidateVatNumberStatusId { get; set; }

    public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; } = new List<CustomerAddress>();

    public virtual ValidateVatNumberStatus? ValidateVatNumberStatus { get; set; }

    public static void Builder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK_customer");
            entity.ToTable("customer");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.CustomerName).HasColumnName("customer_name").HasMaxLength(200);
            entity.Property(e => e.CustomerCompany).HasColumnName("customer_company").HasMaxLength(200);
            entity.Property(e => e.CustomerCompanyID).HasColumnName("customer_company_id").HasMaxLength(20);
            entity.Property(e => e.CustomerVatID).HasColumnName("customer_vat_id").HasMaxLength(20);
            entity.Property(e => e.CustomerTaxID).HasColumnName("customer_tax_id").HasMaxLength(20);
            entity.Property(e => e.CustomerEmail).HasColumnName("customer_email").HasMaxLength(400);
            entity.Property(e => e.CustomerPhone).HasColumnName("customer_phone").HasMaxLength(50);

            entity.HasMany(d => d.CustomerAddresses)
                .WithOne(p => p.CustomerNavigation)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_customer_customer_address").OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.ValidateVatNumberStatus)
                .WithOne()
                .HasForeignKey<Customer>(d => d.ValidateVatNumberStatusId)
                .HasConstraintName("FK_customer_validate_vat_number_status").OnDelete(DeleteBehavior.NoAction);
        });
    }
}