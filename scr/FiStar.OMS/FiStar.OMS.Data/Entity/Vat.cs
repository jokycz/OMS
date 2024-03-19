using Microsoft.EntityFrameworkCore;

namespace FiStar.OMS.Data.Entity;

public class Vat
{
    public int VatId { get; set; }

    public string VatCode { get; set; } = string.Empty;

    public string VatName { get; set; } = string.Empty;

    [Precision(18, 2)]
    public decimal VatRate { get; set; }

    public static void Builder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Vat>(entity =>
        {
            entity.HasKey(e => e.VatId).HasName("PK_vat");
            entity.ToTable("vat");
            entity.Property(e => e.VatId).HasColumnName("vat_id");
            entity.Property(e => e.VatCode).HasColumnName("vat_code").HasMaxLength(3);
            entity.Property(e => e.VatName).HasColumnName("vat_name").HasMaxLength(50);
            entity.Property(e => e.VatRate).HasColumnName("vat_rate").HasPrecision(18, 2);
        });
    }
}