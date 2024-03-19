using Microsoft.EntityFrameworkCore.Storage;

namespace FiStar.OMS.Data;


/// <summary>
/// Database transaction based on EF core context.
/// </summary>
public sealed class EfCoreTransaction : ITransaction
{
    private readonly IDbContextTransaction _trans;

    /// <summary>
    /// Database transaction based on EF core context.
    /// </summary>
    public EfCoreTransaction(IDbContextTransaction trans)
    {
        _trans = trans;
    }

    public void Commit() => _trans.Commit();

    public void Rollback() => _trans.Rollback();

    public void Dispose() => _trans.Dispose();
}