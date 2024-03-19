using FiStar.OMS.Data.Entity;
using Microsoft.EntityFrameworkCore;
// ReSharper disable VirtualMemberCallInConstructor

namespace FiStar.OMS.Data.Data;

public class FiStarOmrDBContext : DbContext
{

    public FiStarOmrDBContext(DbContextOptions<FiStarOmrDBContext> options) : base(options)
    {
        ChangeTracker.LazyLoadingEnabled = false;
    }

    public FiStarOmrDBContext(DbContextOptions options) : base(options)
    {
        ChangeTracker.LazyLoadingEnabled = false;
    }

    public DbSet<Country> Countries { get; set; } = null!;
    public DbSet<Currency> Currencies { get; set; } = null!;
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<CustomerAddress> CustomerAddresses { get; set; } = null!;

    public DbSet<CustomerAddressType> CustomerAddressTypes { get; set; } = null!;
    public DbSet<CustomerOrder> CustomerOrders { get; set; } = null!;
    public DbSet<CustomerOrderDeliveryStatus> CustomerOrderDeliveryStatuses { get; set; } = null!;
    public DbSet<CustomerOrderDeliveryType> CustomerOrderDeliveryTypes { get; set; } = null!;
    public DbSet<CustomerOrderItem> CustomerOrderItems { get; set; } = null!;
    public DbSet<CustomerOrderPaymentStatus> CustomerOrderPaymentStatuses { get; set; } = null!;
    public DbSet<CustomerOrderPaymentType> CustomerOrderPaymentTypes { get; set; } = null!;
    public DbSet<CustomerOrderStatus> CustomerOrderStatuses { get; set; } = null!;
    public DbSet<CustomerOrderSum> CustomerOrderSums { get; set; } = null!;
    public DbSet<Eshop> EShops { get; set; } = null!;
    public DbSet<ItemType> ItemTypes { get; set; } = null!;
    public DbSet<OrderItemType> OrderItemTypes { get; set; } = null!;
    public DbSet<RoutingType> RoutingTypes { get; set; } = null!;
    public DbSet<SystemUser> SystemUsers { get; set; } = null!;
    public DbSet<UnitOfMeasure> UnitOfMeasures { get; set; } = null!;
    public DbSet<ValidateVatNumberStatus> ValidateVatNumberStatuses { get; set; } = null!;
    public DbSet<Vat> Vats { get; set; } = null!;
    public DbSet<WarehouseCard> WarehouseCards { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Country.Builder(modelBuilder);
        Currency.Builder(modelBuilder);
        Customer.Builder(modelBuilder);
        CustomerAddress.Builder(modelBuilder);
        CustomerAddressType.Builder(modelBuilder);
        CustomerOrder.Builder(modelBuilder);
        CustomerOrderDeliveryStatus.Builder(modelBuilder);
        CustomerOrderDeliveryType.Builder(modelBuilder);
        CustomerOrderItem.Builder(modelBuilder);
        CustomerOrderPaymentStatus.Builder(modelBuilder);
        CustomerOrderPaymentType.Builder(modelBuilder);
        CustomerOrderStatus.Builder(modelBuilder);
        CustomerOrderSum.Builder(modelBuilder);
        Eshop.Builder(modelBuilder);
        ItemType.Builder(modelBuilder);
        OrderItemType.Builder(modelBuilder);
        RoutingType.Builder(modelBuilder);
        SystemUser.Builder(modelBuilder);
        UnitOfMeasure.Builder(modelBuilder);
        ValidateVatNumberStatus.Builder(modelBuilder);
        Vat.Builder(modelBuilder);
        WarehouseCard.Builder(modelBuilder);
    }
}