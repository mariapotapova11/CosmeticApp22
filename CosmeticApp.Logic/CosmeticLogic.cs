using System;
using System.Collections.Generic;
using System.Linq;
using CosmeticApp.DataAccessLayer;
using CosmeticApp.Model;

namespace CosmeticApp.Logic
{
    /// <summary>
    /// Реализует бизнес-логику для управления косметическими продуктами
    /// </summary>
    public class CosmeticLogic : ICosmeticLogic
    {
        private readonly IRepository<Cosmetic> _repository;

        /// <summary>
        /// Инициализирует новый экземпляр класса CosmeticLogic
        /// </summary>
        public CosmeticLogic()
        {
            _repository = new EntityRepository<Cosmetic>();
        }

        /// <summary>
        /// Создает новый косметический продукт
        /// </summary>
        /// <param name="cosmetic">Объект Cosmetic для создания</param>
        /// <exception cref="ArgumentNullException">Выбрасывается, если cosmetic равен null</exception>
        public void Create(Cosmetic cosmetic)
        {
            if (cosmetic == null)
                throw new ArgumentNullException(nameof(cosmetic), "Продукт не может быть null.");

            _repository.Add(cosmetic);  // ← ИЗМЕНИТЬ ЭТУ СТРОКУ
        }

        /// <summary>
        /// Удаляет косметический продукт по указанному ID
        /// </summary>
        /// <param name="id">ID продукта для удаления</param>
        /// <exception cref="ArgumentException">Выбрасывается, если продукт с заданным ID не найден</exception>
        public void Delete(int id)
        {
            var cosmetic = _repository.ReadById(id);  // ← ИЗМЕНИТЬ ЭТУ СТРОКУ
            if (cosmetic == null)
                throw new ArgumentException($"Продукт с ID {id} не найден.");

            _repository.Delete(id);  // ← ИЗМЕНИТЬ ЭТУ СТРОКУ
        }

        /// <summary>
        /// Возвращает косметический продукт по указанному ID
        /// </summary>
        /// <param name="id">ID продукта для поиска</param>
        /// <returns>Найденный объект Cosmetic</returns>
        /// <exception cref="ArgumentException">Выбрасывается, если продукт с заданным ID не найден</exception>
        public Cosmetic ReadById(int id)  // ← ИЗМЕНИТЬ НАЗВАНИЕ МЕТОДА
        {
            var cosmetic = _repository.ReadById(id);  // ← ИЗМЕНИТЬ ЭТУ СТРОКУ
            if (cosmetic == null)
                throw new ArgumentException($"Продукт с ID {id} не найден.");

            return cosmetic;
        }

        /// <summary>
        /// Обновляет данные существующего косметического продукта
        /// </summary>
        /// <param name="cosmetic">Объект Cosmetic с обновленными данными</param>
        /// <exception cref="ArgumentNullException">Выбрасывается, если cosmetic равен null</exception>
        /// <exception cref="ArgumentException">Выбрасывается, если продукт с заданным ID не найден</exception>
        public void Update(Cosmetic cosmetic)
        {
            if (cosmetic == null)
                throw new ArgumentNullException(nameof(cosmetic), "Продукт не может быть null.");

            var existingCosmetic = _repository.ReadById(cosmetic.Id);  // ← ИЗМЕНИТЬ ЭТУ СТРОКУ
            if (existingCosmetic == null)
                throw new ArgumentException($"Продукт с ID {cosmetic.Id} не найден.");

            _repository.Update(cosmetic);  // ← ИЗМЕНИТЬ ЭТУ СТРОКУ
        }

        /// <summary>
        /// Возвращает все косметические продукты
        /// </summary>
        /// <returns>Коллекция всех продуктов</returns>
        public IEnumerable<Cosmetic> GetAllCosmetics()
        {
            return _repository.ReadAll();  // ← ИЗМЕНИТЬ ЭТУ СТРОКУ
        }

        // БИЗНЕС-ФУНКЦИИ (2 штуки)

        /// <summary>
        /// Возвращает все продукты указанного бренда
        /// </summary>
        /// <param name="brand">Бренд для фильтрации</param>
        /// <returns>Коллекция продуктов отфильтрованная по бренду</returns>
        public IEnumerable<Cosmetic> GetCosmeticsByBrand(Brand brand)
        {
            return _repository.ReadAll().Where(c => c.Brand == brand).ToList();  // ← ИЗМЕНИТЬ ЭТУ СТРОКУ
        }

        /// <summary>
        /// Возвращает все продукты, цена которых превышает заданный порог
        /// </summary>
        /// <param name="threshold">Пороговая стоимость</param>
        /// <returns>Коллекция дорогих продуктов</returns>
        public IEnumerable<Cosmetic> GetExpensiveCosmetics(decimal threshold)
        {
            return _repository.ReadAll().Where(c => c.Price > threshold).OrderByDescending(c => c.Price).ToList();  // ← ИЗМЕНИТЬ ЭТУ СТРОКУ
        }
    }
}