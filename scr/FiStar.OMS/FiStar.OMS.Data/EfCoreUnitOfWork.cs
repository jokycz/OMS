using Microsoft.EntityFrameworkCore;

namespace FiStar.OMS.Data;


/// <summary>
/// Business transaction based on EF Core context.
/// </summary>
public class EfCoreUnitOfWork<TContext> : IUnitOfWork
    where TContext : DbContext
{
    private readonly TContext _context;

    /// <summary>
    /// Business transaction based on EF Core context.
    /// </summary>
    public EfCoreUnitOfWork(TContext context)
    {
        _context = context;
    }

    public async Task<ITransaction> BeginTransactionAsync()
    {
        return new EfCoreTransaction(await _context.Database.BeginTransactionAsync());
    }

    public Task SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }

    public DbContext Context => _context;
}