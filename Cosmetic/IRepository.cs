using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticApp.Model
{
    /// <summary>
    /// Общий интерфейс репозитория для CRUD операций
    /// </summary>
    /// <typeparam name="T">Тип доменного объекта</typeparam>
    public interface IRepository<T> where T : IDomainObject
    {
        /// <summary>
        /// Добавляет новую сущность
        /// </summary>
        /// <param name="entity">Добавляемая сущность</param>
        void Add(T entity);

        /// <summary>
        /// Удаляет сущность по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор сущности</param>
        void Delete(int id);

        /// <summary>
        /// Получает все сущности
        /// </summary>
        /// <returns>Коллекция всех сущностей</returns>
        IEnumerable<T> ReadAll();

        /// <summary>
        /// Получает сущность по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор сущности</param>
        /// <returns>Найденная сущность или null</returns>
        T ReadById(int id);

        /// <summary>
        /// Обновляет существующую сущность
        /// </summary>
        /// <param name="entity">Обновляемая сущность</param>
        void Update(T entity);
    }
}
