namespace FiStar.OMS.Data;

/// <summary>
/// Identifies a query object.
/// </summary>
// ReSharper disable once TypeParameterCanBeVariant
public interface IQuery<TResult, TContext>
{
    /// <summary>
    /// Executes the query on the specified db context.
    /// </summary>
    /// <param name="context">The db context. Cannot be null.</param>
    Task<TResult> GetResultsAsync(TContext context);
}