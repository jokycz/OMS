using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace FiStar.OMS.Data.Entity;

public class CustomerOrderItem
{
    public int CustomerOrderItemId { get; set; }

    public int CustomerOrderId { get; set; }

    public int ItemTypeId { get; set; }

    public int WarehouseCardId { get; set; }

    public int OrderByItem { get; set; }

    [MaxLength(50)]
    public string Code { get; set; } = string.Empty;

    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? Description { get; set; }

    [Precision(18, 5)]
    public decimal Quantity { get; set; }

    [Precision(18, 5)]
    public decimal QuantityReserved { get; set; }

    [Precision(18, 5)]
    public decimal QuantityDelivery { get; set; } 

    public int UnitOfMeasure { get; set; }

    public int UnitOfMeasureBase { get; set; }

    [Precision(18, 5)]
    public decimal UnitOfMeasureRatio  { get; set; }

    [Precision(18, 2)]
    public decimal UnitPriceCurrency { get; set; }

    [Precision(18, 2)]
    public decimal UnitPriceAc { get; set; }

    public int CurrencyId { get; set; }

    [Precision(18, 5)]
    public decimal CurrencyRatio { get; set; }

    public int VatId { get; set; }

    [Precision(18, 2)]
    public decimal VatRate { get; set; }

    [Precision(18, 2)]
    public decimal DiscountAddOn { get; set; }

    public int RoutingTypeID { get; set; }

    [Precision(18, 2)]
    public decimal TotalPriceCurrency { get; set; }

    [Precision(18, 2)]
    public decimal TotalPriceAc { get; set; }

    [Precision(18, 2)]
    public decimal TotalPriceVatCurrency { get; set; }

    [Precision(18, 2)]
    public decimal TotalPriceVatAc { get; set; }

    public DateTime OrderItemCreate { get; set; }

    public DateTime OrderItemUpdate { get; set; }

    public DateTime OrderItemDelete { get; set; }

    public int OrderItemCreateUser { get; set; }
    public int OrderItemUpdateUser { get; set; }
    public int OrderItemDeleteUser { get; set; }

    public CustomerOrder? CustomerOrderNavigation { get; set; }

    public OrderItemType? ItemTypeNavigation { get; set; }
    public WarehouseCard? WarehouseCardNavigation { get; set; }
    public UnitOfMeasure? UnitOfMeasureNavigation { get; set; }

    public UnitOfMeasure? UnitOfMeasureBaseNavigation { get; set; }

    public Currency? CurrencyNavigation { get; set; }

    public Vat? VatNavigation { get; set; }

    public RoutingType? RoutingTypeNavigation { get; set; }

    public SystemUser? OrderItemCreateUserNavigation { get; set; }
    public SystemUser? OrderItemUpdateUserNavigation { get; set; }

    public SystemUser? OrderItemDeleteUserNavigation { get; set; }

    public static void Builder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerOrderItem>(entity =>
        {
            entity.HasKey(e => e.CustomerOrderItemId).HasName("PK_customer_order_item");
            entity.ToTable("customer_order_item");
            entity.Property(e => e.CustomerOrderItemId).HasColumnName("customer_order_item_id");
            entity.Property(e => e.ItemTypeId).HasColumnName("item_type_id");
            entity.Property(e => e.WarehouseCardId).HasColumnName("warehouse_card_id");
            entity.Property(e => e.OrderByItem).HasColumnName("order_by_item");
            entity.Property(e => e.Code).HasColumnName("code").HasMaxLength(50);
            entity.Property(e => e.Name).HasColumnName("name").HasMaxLength(200);
            entity.Property(e => e.Description).HasColumnName("description").HasMaxLength(500);
            entity.Property(e => e.Quantity).HasColumnName("quantity").HasPrecision(18,5);
            entity.Property(e => e.QuantityReserved).HasColumnName("quantity_reserved").HasPrecision(18, 5);
            entity.Property(e => e.QuantityDelivery).HasColumnName("quantity_delivery").HasPrecision(18, 5);
            entity.Property(e => e.UnitOfMeasure).HasColumnName("unit_of_measure");
            entity.Property(e => e.UnitOfMeasureBase).HasColumnName("unit_of_measure_base");
            entity.Property(e => e.UnitOfMeasureRatio).HasColumnName("unit_of_measure_ratio").HasPrecision(18, 5);
            entity.Property(e => e.UnitPriceCurrency).HasColumnName("unit_price_currency").HasPrecision(18, 2);
            entity.Property(e => e.UnitPriceAc).HasColumnName("unit_price_ac").HasPrecision(18, 2);
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.CurrencyRatio).HasColumnName("currency_ratio").HasPrecision(18, 5);
            entity.Property(e => e.VatId).HasColumnName("vat_id");
            entity.Property(e => e.VatRate).HasColumnName("vat_rate").HasPrecision(18, 2);
            entity.Property(e => e.DiscountAddOn).HasColumnName("discount_add_on");
            entity.Property(e => e.RoutingTypeID).HasColumnName("routing_type_id");
            entity.Property(e => e.TotalPriceCurrency).HasColumnName("total_price_currency").HasPrecision(18, 2);
            entity.Property(e => e.TotalPriceAc).HasColumnName("total_price_ac").HasPrecision(18, 2);
            entity.Property(e => e.TotalPriceVatCurrency).HasColumnName("total_price_vat_currency").HasPrecision(18, 2);
            entity.Property(e => e.TotalPriceVatAc).HasColumnName("total_price_vat_ac").HasPrecision(18, 2);
            entity.Property(e => e.OrderItemCreate).HasColumnName("order_item_create");
            entity.Property(e => e.OrderItemUpdate).HasColumnName("order_item_update");
            entity.Property(e => e.OrderItemDelete).HasColumnName("order_item_delete");
            entity.Property(e => e.OrderItemCreateUser).HasColumnName("order_item_create_user");
            entity.Property(e => e.OrderItemUpdateUser).HasColumnName("order_item_update_user");
            entity.Property(e => e.OrderItemDeleteUser).HasColumnName("order_item_delete_user");

            entity.HasOne(d => d.CustomerOrderNavigation)
                .WithMany(p => p.CustomerOrderItems)
                .HasForeignKey(d => d.CustomerOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_customer_order_item_customer_order").OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.ItemTypeNavigation)
                .WithMany()
                .HasForeignKey(d => d.ItemTypeId)
                .HasConstraintName("FK_customer_order_item_order_item_type").OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(d => d.WarehouseCardNavigation)
                .WithMany()
                .HasForeignKey(d => d.WarehouseCardId)
                .HasConstraintName("FK_customer_order_item_warehouse_card").OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(d => d.UnitOfMeasureNavigation)
                .WithMany()
                .HasForeignKey(d => d.UnitOfMeasure)
                .HasConstraintName("FK_customer_order_item_unit_of_measure").OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(d => d.UnitOfMeasureBaseNavigation)
                .WithMany()
                .HasForeignKey(d => d.UnitOfMeasureBase)
                .HasConstraintName("FK_customer_order_item_unit_of_measure_base").OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(d => d.CurrencyNavigation)
                .WithMany()
                .HasForeignKey(d => d.CurrencyId)
                .HasConstraintName("FK_customer_order_item_currency").OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(d => d.VatNavigation)
                .WithMany()
                .HasForeignKey(d => d.VatId)
                .HasConstraintName("FK_customer_order_item_vat").OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(d => d.RoutingTypeNavigation)
                .WithMany()
                .HasForeignKey(d => d.RoutingTypeID)
                .HasConstraintName("FK_customer_order_item_routing_type").OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(d => d.OrderItemCreateUserNavigation)
                .WithMany()
                .HasForeignKey(d => d.OrderItemCreateUser)
                .HasConstraintName("FK_customer_order_item_order_item_create_user").OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(d => d.OrderItemUpdateUserNavigation)
                .WithMany()
                .HasForeignKey(d => d.OrderItemUpdateUser)
                .HasConstraintName("FK_customer_order_item_order_item_update_user").OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(d => d.OrderItemDeleteUserNavigation)
                .WithMany()
                .HasForeignKey(d => d.OrderItemDeleteUser)
                .HasConstraintName("FK_customer_order_item_order_item_delete_user").OnDelete(DeleteBehavior.NoAction);
        });
    }
}