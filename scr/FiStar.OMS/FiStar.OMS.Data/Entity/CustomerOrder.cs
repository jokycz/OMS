using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace FiStar.OMS.Data.Entity;

public class CustomerOrder
{
    public int CustomerOrderId { get; set; }

    [Required] 
    [StringLength(10)] 
    public string OrderNumber { get; set; } = null!;

    public DateTime OrderDate { get; set; }

    public int OrderStatus { get; set; }

    public int OrderPaymentType { get; set; }

    public int OrderPaymentStatus { get; set; }

    public DateTime? OrderPaymentDate { get; set; }

    public DateTime? OrderDeliveryAfter { get; set; }

    public DateTime? OrderDeliveryBy { get; set; }

    public int? OrderDeliveryType { get; set; }

    public int? OrderDeliveryStatus { get; set; } 

    public DateTime? OrderDateReservation { get; set; }

    public DateTime? OrderDateExpedition { get; set; }

    public DateTime? OrderDateDelivery { get; set; }

    public DateTime? OrderDateCancel { get; set; }

    public double OrderTotalAmount { get; set; } 

    public int OrderCurrency { get; set; }

    public double OrderCurrencyRate { get; set; }

    public double OrderTotalAmountAc { get; set; }

    public int CustomerID { get; set; }

    public int CustomerAddressInvoicingId { get; set; }

    public int CustomerAddressDeliveryId { get; set; }

    public int OrderSourceWeb { get; set; }

    public DateTime OrderCreate { get; set; }

    public int? OrderCreateUser { get; set; }

    public DateTime? OrderModify { get; set; }

    public int? OrderModifyUser { get; set; }

    public DateTime? OrderDelete { get; set; }

    public int? OrderDeleteUser { get; set; }

    public virtual CustomerOrderStatus? CustomerOrderStatusNavigation { get; set; }
    public virtual CustomerOrderPaymentType? CustomerOrderPaymentTypeNavigation { get; set; }
    public virtual CustomerOrderPaymentStatus? CustomerOrderPaymentStatusNavigation { get; set; }
    public virtual CustomerOrderDeliveryType? CustomerOrderDeliveryTypeNavigation { get; set; }
    public virtual CustomerOrderDeliveryStatus? CustomerOrderDeliveryStatusNavigation { get; set; }
    public virtual Currency? CurrencyNavigation { get; set; }
    public virtual Customer? CustomerNavigation { get; set; }

    public virtual CustomerAddress? CustomerAddressInvoicingNavigation { get; set; }
    public virtual CustomerAddress? CustomerAddressDeliveryNavigation { get; set; }

    public virtual Eshop? EshopNavigation { get; set; }

    public virtual SystemUser? OrderCreateUserNavigation { get; set; }
    public virtual SystemUser? OrderModifyUserNavigation { get; set; }
    public virtual SystemUser? OrderDeleteUserNavigation { get; set; }

    public virtual ICollection<CustomerOrderItem> CustomerOrderItems { get; set; } = new List<CustomerOrderItem>();

    public virtual ICollection<CustomerOrderSum> CustomerOrderSums { get; set; } = new List<CustomerOrderSum>();

    public static void Builder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerOrder>(entity =>
        {
            entity.HasKey(e => e.CustomerOrderId).HasName("PK_customer_order");
            entity.ToTable("customer_order");
            entity.Property(e => e.CustomerOrderId).HasColumnName("customer_order_id");
            entity.Property(e => e.OrderNumber).HasColumnName("order_number");
            entity.Property(e => e.OrderDate).HasColumnName("order_date");
            entity.Property(e => e.OrderStatus).HasColumnName("order_status");
            entity.Property(e => e.OrderPaymentType).HasColumnName("order_payment_type");
            entity.Property(e => e.OrderPaymentStatus).HasColumnName("order_payment_status");
            entity.Property(e => e.OrderPaymentDate).HasColumnName("order_payment_date");
            entity.Property(e => e.OrderDeliveryAfter).HasColumnName("order_delivery_after");
            entity.Property(e => e.OrderDeliveryBy).HasColumnName("order_delivery_by");
            entity.Property(e => e.OrderDeliveryType).HasColumnName("order_delivery_type");
            entity.Property(e => e.OrderDeliveryStatus).HasColumnName("order_delivery_status");
            entity.Property(e => e.OrderDateReservation).HasColumnName("order_date_reservation");
            entity.Property(e => e.OrderDateExpedition).HasColumnName("order_date_expedition");
            entity.Property(e => e.OrderDateDelivery).HasColumnName("order_date_delivery");
            entity.Property(e => e.OrderDateCancel).HasColumnName("order_date_cancel");
            entity.Property(e => e.OrderTotalAmount).HasColumnName("order_total_amount");
            entity.Property(e => e.OrderCurrency).HasColumnName("order_currency");
            entity.Property(e => e.OrderCurrencyRate).HasColumnName("order_currency_rate");
            entity.Property(e => e.OrderTotalAmountAc).HasColumnName("order_total_amount_ac");
            entity.Property(e => e.CustomerID).HasColumnName("customer_id");
            entity.Property(e => e.CustomerAddressInvoicingId).HasColumnName("customer_address_invoicing_id");
            entity.Property(e => e.CustomerAddressDeliveryId).HasColumnName("customer_address_delivery_id");
            entity.Property(e => e.OrderSourceWeb).HasColumnName("order_source_web");
            entity.Property(e => e.OrderCreate).HasColumnName("order_create");
            entity.Property(e => e.OrderCreateUser).HasColumnName("order_create_user");
            entity.Property(e => e.OrderModify).HasColumnName("order_modify");
            entity.Property(e => e.OrderModifyUser).HasColumnName("order_modify_user");
            entity.Property(e => e.OrderDelete).HasColumnName("order_delete");
            entity.Property(e => e.OrderDeleteUser).HasColumnName("order_delete_user");

            entity.HasOne(d => d.CustomerOrderStatusNavigation).
                WithOne().
                HasForeignKey<CustomerOrder>(d => d.CustomerOrderId).
                HasConstraintName("FK_customer_order_customer_order_status").OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(d => d.CustomerOrderPaymentTypeNavigation).
                WithOne().
                HasForeignKey<CustomerOrder>(d => d.CustomerOrderId).
                HasConstraintName("FK_customer_order_customer_order_payment_type").OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(d => d.CustomerOrderPaymentStatusNavigation).
                WithOne().
                HasForeignKey<CustomerOrder>(d => d.CustomerOrderId).
                HasConstraintName("FK_customer_order_customer_order_payment_status").OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(d => d.CustomerOrderDeliveryTypeNavigation).
                WithOne().
                HasForeignKey<CustomerOrder>(d => d.CustomerOrderId).
                HasConstraintName("FK_customer_order_customer_order_delivery_type").OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(d => d.CustomerOrderDeliveryStatusNavigation).
                WithOne().
                HasForeignKey<CustomerOrder>(d => d.CustomerOrderId).
                HasConstraintName("FK_customer_order_customer_order_delivery_status").OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(d => d.CurrencyNavigation).
                WithOne().
                HasForeignKey<CustomerOrder>(d => d.OrderCurrency).
                HasConstraintName("FK_customer_order_currency").OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(d => d.CustomerNavigation).
                WithOne().
                HasForeignKey<CustomerOrder>(d => d.CustomerID).
                HasConstraintName("FK_customer_order_customer").OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(d => d.CustomerAddressInvoicingNavigation).
                WithOne().
                HasForeignKey<CustomerOrder>(d => d.CustomerAddressInvoicingId).
                HasConstraintName("FK_customer_order_customer_address_invoicing").OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(d => d.CustomerAddressDeliveryNavigation).
                WithOne().
                HasForeignKey<CustomerOrder>(d => d.CustomerAddressDeliveryId).
                HasConstraintName("FK_customer_order_customer_address_delivery").OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(d => d.EshopNavigation).
                WithOne().
                HasForeignKey<CustomerOrder>(d => d.OrderSourceWeb).
                HasConstraintName("FK_customer_order_eshop").OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(d => d.OrderCreateUserNavigation).
                WithOne().
                HasForeignKey<CustomerOrder>(d => d.OrderCreateUser).
                HasConstraintName("FK_customer_order_system_user_create").OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(d => d.OrderModifyUserNavigation).
                WithOne().
                HasForeignKey<CustomerOrder>(d => d.OrderModifyUser).
                HasConstraintName("FK_customer_order_system_user_modify").OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(d => d.OrderDeleteUserNavigation).
                WithOne().
                HasForeignKey<CustomerOrder>(d => d.OrderDeleteUser).
                HasConstraintName("FK_customer_order_system_user_delete").OnDelete(DeleteBehavior.NoAction);

            entity.HasMany(d => d.CustomerOrderItems).
                WithOne(p => p.CustomerOrderNavigation).
                HasForeignKey(d => d.CustomerOrderId).
                HasConstraintName("FK_customer_order_item_customer_order").OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(d => d.CustomerOrderSums).
                WithOne(p => p.CustomerOrderNavigation).
                HasForeignKey(d => d.CustomerOrderId).
                HasConstraintName("FK_customer_order_sum_customer_order").OnDelete(DeleteBehavior.Cascade);
        });
    }
}