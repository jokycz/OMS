using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace FiStar.OMS.Data.Entity;

public class Country
{
    public int CountryId { get; set; }

    [Required]
    [StringLength(3)]
    public string CountryCode { get; set; } = null!;

    [Required]
    [StringLength(200)]
    public string CountryName { get; set; } = null!;

    public static void Builder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("PK_country");
            entity.ToTable("country");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.CountryCode).HasColumnName("country_code").HasMaxLength(3);
            entity.Property(e => e.CountryName).HasColumnName("country_name").HasMaxLength(200);
        });
    }


}