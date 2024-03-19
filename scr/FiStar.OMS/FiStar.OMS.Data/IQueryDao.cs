
using FiStar.OMS.Data.Data;

namespace FiStar.OMS.Data;


/// <summary>
/// Describes data access object that provides query functionality.
/// </summary>
public interface IQueryDao
{
    /// <summary>
    /// Executes the specified query and returns the result entities.
    /// </summary>
    /// <typeparam name="TResult">The query result type.</typeparam>
    /// <param name="query">The query to execute.</param>
    Task<TResult> GetAsync<TResult>(IQuery<TResult, FiStarOmrDBContext> query);
}