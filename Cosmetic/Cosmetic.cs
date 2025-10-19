using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticApp.Model
{
    /// <summary>
    /// Представляет сущность "Косметический продукт"
    /// </summary>
    public class Cosmetic : IDomainObject
    {
        /// <summary>
        /// Уникальный идентификатор продукта
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название продукта
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Бренд продукта
        /// </summary>
        public Brand Brand { get; set; }

        /// <summary>
        /// Категория продукта (например, помада, тушь)
        /// </summary>
        public Category Category { get; set; }

        /// <summary>
        /// Цена продукта
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Срок годности продукта (в месяцах)
        /// </summary>
        public int ExpiryInMonths { get; set; }

        /// <summary>
        /// Конструктор по умолчанию, необходим для сериализации
        /// </summary>
        public Cosmetic()
        {
            Name = string.Empty;
        }

        /// <summary>
        /// Конструктор для создания нового продукта
        /// </summary>
        /// <param name="name">Название продукта</param>
        /// <param name="brand">Бренд продукта</param>
        /// <param name="category">Категория продукта</param>
        /// <param name="price">Цена продукта</param>
        /// <param name="expiryInMonths">Срок годности в месяцах</param>
        public Cosmetic(string name, Brand brand, Category category, decimal price, int expiryInMonths)
        {
            Name = name;
            Brand = brand;
            Category = category;
            Price = price;
            ExpiryInMonths = expiryInMonths;
        }

        /// <summary>
        /// Возвращает строковое представление объекта Cosmetic.
        /// </summary>
        /// <returns>Строка, содержащая основные свойства косметического продукта.</returns>
        public override string ToString()
        {
            return $"{Id}: {Name} ({Brand}) - {Category} | Цена: {Price:C} | Срок годности: {ExpiryInMonths} мес.";
        }
    }

    /// <summary>
    /// Перечисление популярных косметических брендов
    /// </summary>
    public enum Brand
    {
        Loreal,
        Maybelline,
        MAC,
        NARS,
        Fenty_Beauty,
        NYX,
        Revlon,
        Esteе_Lauder
    }

    /// <summary>
    /// Перечисление категорий косметики
    /// </summary>
    public enum Category
    {
        Помада,
        Тушь,
        Тональный_крем,
        Тени_для_век,
        Румяна,
        Хайлайтер,
        Консилер
    }
}
