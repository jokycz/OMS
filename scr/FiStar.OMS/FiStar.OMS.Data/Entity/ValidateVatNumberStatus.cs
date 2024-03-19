using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace FiStar.OMS.Data.Entity;

public class ValidateVatNumberStatus
{
    public int ValidateVatNumberStatusId { get; set; }

    [Required]
    [StringLength(50)]
    public string StatusName { get; set; } = null!;

    public static void Builder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ValidateVatNumberStatus>(entity =>
        {
            entity.HasKey(e => e.ValidateVatNumberStatusId).HasName("PK_validate_vat_number_status");
            entity.ToTable("validate_vat_number_status");
            entity.Property(e => e.ValidateVatNumberStatusId).HasColumnName("validate_vat_number_status_id");
            entity.Property(e => e.StatusName).HasColumnName("status_name").HasMaxLength(50);
        });
    }
}