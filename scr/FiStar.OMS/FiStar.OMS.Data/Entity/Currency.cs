using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace FiStar.OMS.Data.Entity;

public class Currency
{
    public int CurrencyId { get; set; }

    [Required]
    [StringLength(3)]
    public string CurrencyCode { get; set; } = null!;

    [Required]
    [StringLength(50)]
    public string CurrencyName { get; set; } = null!;

    public static void Builder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Currency>(entity =>
        {
            entity.HasKey(e => e.CurrencyId).HasName("PK_currency");
            entity.ToTable("currency");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.CurrencyCode).HasColumnName("currency_code").HasMaxLength(3);
            entity.Property(e => e.CurrencyName).HasColumnName("currency_name").HasMaxLength(50);
        });
    }
}