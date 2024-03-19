using Microsoft.EntityFrameworkCore;

namespace FiStar.OMS.Data.Entity;

public class WarehouseCard
{
    public int WarehouseCardId { get; set; }

    public string WarehouseCardName { get; set; } = string.Empty;

    public string WarehouseCardDescription { get; set; } = string.Empty;

    public int WarehouseCardType { get; set; }

    public int WarehouseCardStatus { get; set; }

    public int WarehouseCardCreateUser { get; set; }

    public int WarehouseCardUpdateUser { get; set; }

    public int WarehouseCardDeleteUser { get; set; }

    public DateTime WarehouseCardCreate { get; set; }

    public DateTime WarehouseCardUpdate { get; set; }

    public DateTime WarehouseCardDelete { get; set; }

    public SystemUser? WarehouseCardCreateUserNavigation { get; set; }

    public SystemUser? WarehouseCardUpdateUserNavigation { get; set; }

    public SystemUser? WarehouseCardDeleteUserNavigation { get; set; }

    public static void Builder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WarehouseCard>(entity =>
        {
            entity.HasKey(e => e.WarehouseCardId).HasName("PK_warehouse_card");
            entity.ToTable("warehouse_card");
            entity.Property(e => e.WarehouseCardId).HasColumnName("warehouse_card_id");
            entity.Property(e => e.WarehouseCardName).HasColumnName("warehouse_card_name").HasMaxLength(50);
            entity.Property(e => e.WarehouseCardDescription).HasColumnName("warehouse_card_description").HasMaxLength(250);
            entity.Property(e => e.WarehouseCardType).HasColumnName("warehouse_card_type");
            entity.Property(e => e.WarehouseCardStatus).HasColumnName("warehouse_card_status");
            entity.Property(e => e.WarehouseCardCreateUser).HasColumnName("warehouse_card_create_user");
            entity.Property(e => e.WarehouseCardUpdateUser).HasColumnName("warehouse_card_update_user");
            entity.Property(e => e.WarehouseCardDeleteUser).HasColumnName("warehouse_card_delete_user");
            entity.Property(e => e.WarehouseCardCreate).HasColumnName("warehouse_card_create");
            entity.Property(e => e.WarehouseCardUpdate).HasColumnName("warehouse_card_update");
            entity.Property(e => e.WarehouseCardDelete).HasColumnName("warehouse_card_delete");
        });
    }
}