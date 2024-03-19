using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace FiStar.OMS.Data.Entity;

public class OrderItemType
{
    public int OrderItemTypeId { get; set; }

    [Required]
    public int ItemTypeID { get; set; }

    public string OrderItemTypeName { get; set; } = string.Empty;
    public virtual ItemType ItemTypeNavigation { get; set; }

    public static void Builder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderItemType>(entity =>
        {
            entity.HasKey(e => e.OrderItemTypeId).HasName("PK_order_item_type");
            entity.ToTable("order_item_type");
            entity.Property(e => e.OrderItemTypeId).HasColumnName("order_item_type_id");
            entity.Property(e => e.OrderItemTypeName).HasColumnName("order_item_type_name").HasMaxLength(50);
            entity.Property(e => e.ItemTypeID).HasColumnName("item_type_id");

            entity.HasOne(d => d.ItemTypeNavigation).
                WithMany().
                HasForeignKey(d => d.ItemTypeID).
                OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_order_item_type_item_type");
        });
    }
}