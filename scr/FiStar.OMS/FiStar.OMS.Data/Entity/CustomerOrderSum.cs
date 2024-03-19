using Microsoft.EntityFrameworkCore;

namespace FiStar.OMS.Data.Entity;

public class CustomerOrderSum
{
    public int CustomerOrderSumId { get; set; }

    public int CustomerOrderId { get; set; }

    public int CurrencyId { get; set; }

    public int VatId { get; set; }

    public double VatPercent { get; set; }

    public double WithOutVat { get; set; }
    public double VatAmount { get; set; }

    public double WithVat { get; set; }

    public virtual CustomerOrder CustomerOrderNavigation { get; set; }

    public virtual Currency? CurrencyNavigation { get; set; }

    public virtual Vat? VatNavigation { get; set; }

    public static void Builder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerOrderSum>(entity =>
        {
            entity.HasKey(e => e.CustomerOrderSumId).HasName("PK_customer_order_sum");
            entity.ToTable("customer_order_sum");
            entity.Property(e => e.CustomerOrderSumId).HasColumnName("customer_order_sum_id");
            entity.Property(e => e.CustomerOrderId).HasColumnName("customer_order_id");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.VatId).HasColumnName("vat_id");
            entity.Property(e => e.VatPercent).HasColumnName("vat_percent");
            entity.Property(e => e.WithOutVat).HasColumnName("with_out_vat");
            entity.Property(e => e.VatAmount).HasColumnName("vat_amount");
            entity.Property(e => e.WithVat).HasColumnName("with_vat");

            entity.HasOne(d => d.CustomerOrderNavigation).
                WithMany(p => p.CustomerOrderSums).
                HasForeignKey(d => d.CustomerOrderId).
                HasConstraintName("FK_customer_order_sum_customer_order");

            entity.HasOne(d => d.CurrencyNavigation).
                WithOne().
                HasForeignKey<CustomerOrderSum>(d => d.CurrencyId).
                HasConstraintName("FK_customer_order_sum_currency");

            entity.HasOne(d => d.VatNavigation).
                WithOne().
                HasForeignKey<CustomerOrderSum>(d => d.VatId).
                HasConstraintName("FK_customer_order_sum_vat");
        });
    }
}