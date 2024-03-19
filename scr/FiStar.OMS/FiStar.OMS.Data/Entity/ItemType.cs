using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace FiStar.OMS.Data.Entity;

public class ItemType
{
    public int ItemTypeId { get; set; }

    [Required]
    [StringLength(50)]
    public string ItemTypeName { get; set; } = string.Empty;

    public static void Builder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ItemType>(entity =>
        {
            entity.HasKey(e => e.ItemTypeId).HasName("PK_item_type");
            entity.ToTable("item_type");
            entity.Property(e => e.ItemTypeId).HasColumnName("item_type_id");
            entity.Property(e => e.ItemTypeName).HasColumnName("item_type_name").HasMaxLength(50);
        });
    }
}