using Microsoft.EntityFrameworkCore;

namespace FiStar.OMS.Data;

internal static class DbContextExtensions
{
    /// <summary>
    /// Tries to get an entity tracked in the context. Returns null, if it is not tracked.
    /// </summary>
    internal static TEntity? FindTracked<TEntity>(this DbContext context, params object[] keyValues)
        where TEntity : class
    {
        var entityType = context.Model.FindEntityType(typeof(TEntity));
        var key = entityType?.FindPrimaryKey();
        if (key == null)
        {
            return null;
        }

        var entry = context.ChangeTracker.Entries<TEntity>()
            .FirstOrDefault(e => key.Properties.Select(p => e.Property(p.Name).CurrentValue)
                .SequenceEqual(keyValues));

        return entry?.Entity;
    }
}