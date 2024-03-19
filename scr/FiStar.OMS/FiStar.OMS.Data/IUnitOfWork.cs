using Microsoft.EntityFrameworkCore;

namespace FiStar.OMS.Data;


/// <summary>
/// Represents a single business transaction.
/// </summary>
public interface IUnitOfWork
{
    DbContext Context { get; }

    Task<ITransaction> BeginTransactionAsync();

    Task SaveChangesAsync();
}