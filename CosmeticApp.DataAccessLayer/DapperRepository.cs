using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using CosmeticApp.Model;

namespace CosmeticApp.DataAccessLayer
{
    /// <summary>
    /// Реализация репозитория для работы с базой данных с использованием Dapper
    /// </summary>
    /// <typeparam name="T">Тип доменного объекта, должен реализовывать IDomainObject</typeparam>
    public class DapperRepository<T> : IRepository<T> where T : class, IDomainObject
    {
        private readonly string _connectionString;

        /// <summary>
        /// Инициализирует новый экземпляр DapperRepository и загружает строку подключения из конфигурации
        /// </summary>
        public DapperRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["CosmeticDb"].ConnectionString;
        }

        /// <summary>
        /// Добавляет новую сущность в базу данных
        /// </summary>
        /// <param name="entity">Добавляемая сущность</param>
        /// <exception cref="NotImplementedException">Выбрасывается, если тип сущности не поддерживается</exception>
        public void Add(T entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                if (typeof(T) == typeof(Cosmetic))
                {
                    var cosmetic = entity as Cosmetic;
                    var sql = @"INSERT INTO Cosmetics (Name, Brand, Category, Price, ExpiryInMonths) 
                               VALUES (@Name, @Brand, @Category, @Price, @ExpiryInMonths)";
                    connection.Execute(sql, cosmetic);
                }
                else
                {
                    throw new NotImplementedException($"Add method not implemented for type {typeof(T).Name}");
                }
            }
        }

        /// <summary>
        /// Удаляет сущность из базы данных по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор удаляемой сущности</param>
        /// <exception cref="NotImplementedException">Выбрасывается, если тип сущности не поддерживается</exception>
        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                if (typeof(T) == typeof(Cosmetic))
                {
                    var sql = "DELETE FROM Cosmetics WHERE Id = @Id";
                    connection.Execute(sql, new { Id = id });
                }
                else
                {
                    throw new NotImplementedException($"Delete method not implemented for type {typeof(T).Name}");
                }
            }
        }

        /// <summary>
        /// Получает все сущности из базы данных
        /// </summary>
        /// <returns>Коллекция всех сущностей</returns>
        /// <exception cref="NotImplementedException">Выбрасывается, если тип сущности не поддерживается</exception>
        public IEnumerable<T> ReadAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                if (typeof(T) == typeof(Cosmetic))
                {
                    return connection.Query<T>("SELECT * FROM Cosmetics").ToList();
                }
                else
                {
                    throw new NotImplementedException($"ReadAll method not implemented for type {typeof(T).Name}");
                }
            }
        }

        /// <summary>
        /// Получает сущность из базы данных по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор искомой сущности</param>
        /// <returns>Найденная сущность или null, если сущность не найдена</returns>
        /// <exception cref="NotImplementedException">Выбрасывается, если тип сущности не поддерживается</exception>
        public T ReadById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                if (typeof(T) == typeof(Cosmetic))
                {
                    return connection.QueryFirstOrDefault<T>("SELECT * FROM Cosmetics WHERE Id = @Id", new { Id = id });
                }
                else
                {
                    throw new NotImplementedException($"ReadById method not implemented for type {typeof(T).Name}");
                }
            }
        }

        /// <summary>
        /// Обновляет существующую сущность в базе данных
        /// </summary>
        /// <param name="entity">Обновляемая сущность с новыми данными</param>
        /// <exception cref="NotImplementedException">Выбрасывается, если тип сущности не поддерживается</exception>
        public void Update(T entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                if (typeof(T) == typeof(Cosmetic))
                {
                    var cosmetic = entity as Cosmetic;
                    var sql = @"UPDATE Cosmetics 
                               SET Name = @Name, Brand = @Brand, Category = @Category, 
                                   Price = @Price, ExpiryInMonths = @ExpiryInMonths 
                               WHERE Id = @Id";
                    connection.Execute(sql, cosmetic);
                }
                else
                {
                    throw new NotImplementedException($"Update method not implemented for type {typeof(T).Name}");
                }
            }
        }
    }
}