using Microsoft.EntityFrameworkCore;

namespace FiStar.OMS.Data.Entity;

public class UnitOfMeasure
{
    public int UnitOfMeasureId { get; set; }

    public string UnitOfMeasureCode { get; set; } = string.Empty;

    public string UnitOfMeasureName { get; set; } = string.Empty;

    public static void Builder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UnitOfMeasure>(entity =>
        {
            entity.HasKey(e => e.UnitOfMeasureId).HasName("PK_unit_of_measure");
            entity.ToTable("unit_of_measure");
            entity.Property(e => e.UnitOfMeasureId).HasColumnName("unit_of_measure_id");
            entity.Property(e => e.UnitOfMeasureCode).HasColumnName("unit_of_measure_code").HasMaxLength(3);
            entity.Property(e => e.UnitOfMeasureName).HasColumnName("unit_of_measure_name").HasMaxLength(50);
        });
    }
}