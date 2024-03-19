using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace FiStar.OMS.Data.Entity;

public class Eshop
{
    public int EShopId { get; set; }

    [Required] [StringLength(50)] public string EShopName { get; set; } = string.Empty;

    [StringLength(200)] public string? EshopUrl { get; set; }

    public static void Builder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Eshop>(entity =>
        {
            entity.HasKey(e => e.EShopId).HasName("PK_eshop");
            entity.ToTable("eshop");
            entity.Property(e => e.EShopId).HasColumnName("eshop_id");
            entity.Property(e => e.EShopName).HasColumnName("eshop_name");
            entity.Property(e => e.EshopUrl).HasColumnName("eshop_url").HasMaxLength(200);
        });
    }



}