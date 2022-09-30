namespace SimpleAuthorization.Core.Entities;

/// <summary>
/// Базовый интерфейс сущности
/// </summary>
/// <typeparam name="T">тип идентфиикатора сущности</typeparam>
public interface IEntity<T>
{
    /// <summary>
    /// Идентификатор сущности
    /// </summary>
    public T Id { get; set; }
}