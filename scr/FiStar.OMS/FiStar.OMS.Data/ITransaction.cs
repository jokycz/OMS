namespace FiStar.OMS.Data;

/// <summary>
/// Represents a database transaction.
/// </summary>
public interface ITransaction : IDisposable
{
    void Commit();

    void Rollback();
}