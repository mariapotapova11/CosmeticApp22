namespace CosmeticApp.Model
{
    /// <summary>
    /// Интерфейс для доменных объектов, имеющих идентификатор
    /// </summary>
    public interface IDomainObject
    {
        /// <summary>
        /// Уникальный идентификатор объекта
        /// </summary>
        int Id { get; set; }
    }
}
