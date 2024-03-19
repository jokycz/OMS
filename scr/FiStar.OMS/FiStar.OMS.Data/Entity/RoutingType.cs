using Microsoft.EntityFrameworkCore;

namespace FiStar.OMS.Data.Entity;

public class RoutingType
{
    public int RoutingTypeId { get; set; }

    public string RoutingTypeName { get; set; } = string.Empty;

    public static void Builder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RoutingType>(entity =>
        {
            entity.HasKey(e => e.RoutingTypeId).HasName("PK_routing_type");
            entity.ToTable("routing_type");
            entity.Property(e => e.RoutingTypeId).HasColumnName("routing_type_id");
            entity.Property(e => e.RoutingTypeName).HasColumnName("routing_type_name").HasMaxLength(50);
        });
    }
}