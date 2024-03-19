using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

// ReSharper disable UnusedMember.Global

namespace FiStar.OMS.Data;

/// <summary>
/// Base class for data access object implementations. Provides primitive data entity manipulation
/// methods, that can be used by concrete inheritors.
/// </summary>
/// <typeparam name="TContext">The EF Core context type.</typeparam>
public abstract class DataAccessObject<TContext>
    where TContext : DbContext
{
    private readonly ILogger<DataAccessObject<TContext>> logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="DataAccessObject{TContext}"/> class with the specified context.
    /// </summary>
    /// <param name="context">The source db context. Cannot be null.</param>
    /// <param name="logger"></param>
    protected DataAccessObject(TContext context, ILogger<DataAccessObject<TContext>> logger)
    {
        Context = context ?? throw new ArgumentNullException(nameof(context));
        this.logger = logger;
    }

    /// <summary>
    /// Gets the source db context.
    /// </summary>
    protected TContext Context { get; }

    protected void Add<TEntity>(TEntity entity)
        where TEntity : class
    {
        Context.Add(entity);
    }

    /// <summary>
    /// Adds the entity to the database.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <param name="entity">The entity to add.</param>
    /// <exception cref="DbUpdateException">The entity already exists.</exception>
    public Task AddAsync<TEntity>(TEntity entity) where TEntity : class
    {
        return entity == null ? 
            throw new ArgumentNullException(nameof(entity)) : 
            AddInternalAsync(entity);
    }

    /// <summary>
    /// Adds the entity to the database.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <param name="entity">The entity to add.</param>
    /// <exception cref="DbUpdateException">The entity already exists.</exception>
    private async Task AddInternalAsync<TEntity>(TEntity entity)
        where TEntity : class
    {
        Context.Add(entity);
        await Context.SaveChangesAsync();
    }



    /// <summary>
    /// Finds the entity identified by the specified key value. If not found, returns null.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <param name="keyValues">The key values.</param>
    /// <exception cref="ArgumentNullException"><paramref name="keyValues"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="keyValues"/> is empty.</exception>
    protected async Task<TEntity?> GetByKeyAsync<TEntity>(params object[] keyValues)
        where TEntity : class
    {
        ValidateKeyValues(keyValues);
        var entity = await Context.FindAsync<TEntity>(keyValues);
        return entity;
    }

    /// <summary>
    /// Executes the specified query and returns the result entities.
    /// </summary>
    /// <typeparam name="TResult">The query result type.</typeparam>
    /// <param name="query">The query to execute.</param>
    public Task<TResult> GetAsync<TResult>(IQuery<TResult, TContext> query)
    {
        return query == null ? 
            throw new ArgumentNullException(nameof(query)) : 
            GetInternalAsync(query);
    }


    /// <summary>
    /// Executes the specified query and returns the result entities.
    /// </summary>
    /// <typeparam name="TResult">The query result type.</typeparam>
    /// <param name="query">The query to execute.</param>
    private async Task<TResult> GetInternalAsync<TResult>(IQuery<TResult, TContext> query)
    {
        var stopwatch = Stopwatch.StartNew();
        var queryToString = query.ToString();
        logger.LogDebug("Executing DAO GetAsync for Query '{queryToString}' (START)", queryToString);

        var result = await query.GetResultsAsync(Context);

        logger.LogDebug(
            "Executing DAO GetAsync for Query '{queryToString}' (duration: {TotalMilliseconds} ms) (END)", query, stopwatch.Elapsed.TotalMilliseconds);

        return result;
    }


    /// <summary>
    /// Saves changes in the specified entity.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <param name="entity">The entity to save.</param>
    protected Task UpdateAsync<TEntity>(TEntity entity)
        where TEntity : class
    {
        return entity == null ? 
            throw new ArgumentNullException(nameof(entity)) : 
            UpdateInternalAsync(entity);
    }

    /// <summary>
    /// Saves changes in the specified entity.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <param name="entity">The entity to save.</param>
    private async Task UpdateInternalAsync<TEntity>(TEntity entity)
        where TEntity : class
    {
        Context.Update(entity);
        await Context.SaveChangesAsync();
    }


    protected void Remove<TEntity>(TEntity entity)
        where TEntity : class
    {
        Context.Remove(entity);
    }

    /// <summary>
    /// Deletes the entity from the database.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <param name="entity">The entity to delete.</param>
    /// <returns>A value indicating whether the entity existed.</returns>
    protected Task<bool> RemoveAsync<TEntity>(TEntity entity)
        where TEntity : class
    {
        return entity == null ? 
            throw new ArgumentNullException(nameof(entity)) : 
            RemoveInternalAsync(entity);
    }


    /// <summary>
    /// Deletes the entity from the database.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <param name="entity">The entity to delete.</param>
    /// <returns>A value indicating whether the entity existed.</returns>
    private async Task<bool> RemoveInternalAsync<TEntity>(TEntity entity)
        where TEntity : class
    {
        Context.Remove(entity);

        try
        {
            await Context.SaveChangesAsync();
            return true;
        }
        catch (DbUpdateConcurrencyException)
        {
            return false;
        }
    }

    /// <summary>
    /// Deletes the entity specified by its key from the database.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <param name="setKeys">A method that assigns key values to the given entity.</param>
    /// <param name="keyValues">The key values identifying the entity to delete.</param>
    /// <returns>A value indicating whether the entity existed.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="keyValues"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="keyValues"/> is empty.</exception>
    protected Task<bool> RemoveByKeyAsync<TEntity>(Action<TEntity> setKeys, params object[] keyValues)
        where TEntity : class, new()
    {
        if (setKeys == null)
        {
            throw new ArgumentNullException(nameof(setKeys));
        }

        ValidateKeyValues(keyValues);

        return RemoveInternalByKeyAsync(setKeys, keyValues);
    }

    /// <summary>
    /// Deletes the entity specified by its key from the database.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <param name="setKeys">A method that assigns key values to the given entity.</param>
    /// <param name="keyValues">The key values identifying the entity to delete.</param>
    /// <returns>A value indicating whether the entity existed.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="keyValues"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="keyValues"/> is empty.</exception>
    private async Task<bool> RemoveInternalByKeyAsync<TEntity>(Action<TEntity> setKeys, params object[] keyValues)
        where TEntity : class, new()
    {
        var entity = Context.FindTracked<TEntity>(keyValues) ?? new TEntity();

        setKeys(entity);

        return await RemoveAsync(entity);
    }



    /// <exception cref="ArgumentNullException"><paramref name="keyValues"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="keyValues"/> is empty.</exception>
    private static void ValidateKeyValues(object[] keyValues)
    {
        switch (keyValues)
        {
            case null:
                throw new ArgumentNullException(nameof(keyValues));
        }

        if (keyValues.Length == 0)
        {
            throw new ArgumentException("There was no key value specified.", nameof(keyValues));
        }
    }
}