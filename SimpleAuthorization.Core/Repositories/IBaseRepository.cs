namespace SimpleAuthorization.Core.Repositories;

/// <summary>
/// Базовый репозиторий
/// </summary>
/// <typeparam name="TEntity">сущность</typeparam>
/// <typeparam name="T">тип идентификатора сущности в бд</typeparam>
public interface IBaseRepository<TEntity ,T>
{
    /// <summary>
    /// Метод создания сущности в бд
    /// </summary>
    /// <param name="entity">сущность</param>
    /// <returns>идентфиикатор сущности</returns>
    Task<T> CreateAsync(TEntity entity);

    /// <summary>
    /// Метод обновления сущности в бд
    /// </summary>
    /// <param name="entity">сущность</param>
    Task UpdateAsync(TEntity entity);

    /// <summary>
    /// Метод удаления сущности из бд
    /// </summary>
    /// <param name="entity">сущность</param>
    Task DeleteAsync(TEntity entity);

    /// <summary>
    /// Метод поулчения сущноси из бд
    /// </summary>
    /// <param name="id">идентификатор сущности</param>
    /// <returns>сущность</returns>
    Task<TEntity?> GetAsync(T id);
}