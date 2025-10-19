using CosmeticApp.Logic;
using CosmeticApp.Model;
using System;
using System.Linq;

namespace CosmeticApp.ConsoleUI
{
    class Program
    {
        private static readonly ICosmeticLogic _logic = new CosmeticLogic();

        static void Main(string[] args)
        {
            // Добавляем тестовые данные для демонстрации
            SeedData();

            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== КОСМЕТИЧЕСКИЙ МАГАЗИН ===");
                Console.WriteLine("1. Показать все продукты");
                Console.WriteLine("2. Добавить продукт");
                Console.WriteLine("3. Найти продукт по ID");
                Console.WriteLine("4. Обновить продукт");
                Console.WriteLine("5. Удалить продукт");
                Console.WriteLine("6. Показать продукты по бренду");
                Console.WriteLine("7. Показать дорогие продукты (> 1500 руб.)");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите опцию: ");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": ShowAllCosmetics(); break;
                    case "2": AddCosmetic(); break;
                    case "3": ReadCosmetic(); break;
                    case "4": UpdateCosmetic(); break;
                    case "5": DeleteCosmetic(); break;
                    case "6": ShowByBrand(); break;
                    case "7": ShowExpensive(); break;
                    case "0": exit = true; break;
                    default: Console.WriteLine("Неверный выбор."); break;
                }
                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
            }
        }

        private static void ShowAllCosmetics()
        {
            Console.WriteLine("\n--- Все продукты ---");
            foreach (var cosmetic in _logic.GetAllCosmetics())
            {
                Console.WriteLine(cosmetic);
            }
        }

        private static void AddCosmetic()
        {
            Console.WriteLine("\n--- Добавление нового продукта ---");
            try
            {
                Cosmetic newCosmetic = ReadCosmeticFromConsole();
                _logic.Create(newCosmetic);
                Console.WriteLine("Продукт успешно добавлен!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при добавлении: {ex.Message}");
            }
        }

        private static void ReadCosmetic()
        {
            Console.Write("\nВведите ID продукта для поиска: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                try
                {
                    var cosmetic = _logic.ReadById(id);
                    Console.WriteLine("Найден продукт: " + cosmetic);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Некорректный ID.");
            }
        }

        private static void UpdateCosmetic()
        {
            Console.Write("\nВведите ID продукта для обновления: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                try
                {
                    var existingCosmetic = _logic.ReadById(id);
                    Console.WriteLine("Текущие данные: " + existingCosmetic);
                    Console.WriteLine("Введите новые данные:");

                    Cosmetic updatedCosmetic = ReadCosmeticFromConsole();
                    updatedCosmetic.Id = id; // Сохраняем старый ID

                    _logic.Update(updatedCosmetic);
                    Console.WriteLine("Продукт успешно обновлен!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при обновлении: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Некорректный ID.");
            }
        }

        private static void DeleteCosmetic()
        {
            Console.Write("\nВведите ID продукта для удаления: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                try
                {
                    _logic.Delete(id);
                    Console.WriteLine("Продукт успешно удален!");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Некорректный ID.");
            }
        }

        private static void ShowByBrand()
        {
            Console.WriteLine("\nВыберите бренд:");
            var brands = Enum.GetValues(typeof(Brand));
            for (int i = 0; i < brands.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {brands.GetValue(i)}");
            }

            Console.Write("Введите номер бренда: ");
            if (int.TryParse(Console.ReadLine(), out int brandIndex) && brandIndex > 0 && brandIndex <= brands.Length)
            {
                Brand selectedBrand = (Brand)brands.GetValue(brandIndex - 1);
                var cosmetics = _logic.GetCosmeticsByBrand(selectedBrand);

                Console.WriteLine($"\n--- Продукты бренда {selectedBrand} ---");
                foreach (var cosmetic in cosmetics)
                {
                    Console.WriteLine(cosmetic);
                }
            }
            else
            {
                Console.WriteLine("Некорректный выбор бренда.");
            }
        }

        private static void ShowExpensive()
        {
            var expensiveCosmetics = _logic.GetExpensiveCosmetics(1500m);
            Console.WriteLine("\n--- Дорогие продукты (дороже 1500 руб.) ---");
            foreach (var cosmetic in expensiveCosmetics)
            {
                Console.WriteLine(cosmetic);
            }
        }

        // Вспомогательный метод для ввода данных с консоли
        private static Cosmetic ReadCosmeticFromConsole()
        {
            Console.Write("Введите название: ");
            string name = Console.ReadLine() ?? "";

            Console.Write("Введите цену: ");
            decimal price = decimal.Parse(Console.ReadLine() ?? "0");

            Console.Write("Введите срок годности (в месяцах): ");
            int expiry = int.Parse(Console.ReadLine() ?? "0");

            Console.WriteLine("Выберите бренд:");
            var brands = Enum.GetValues(typeof(Brand));
            for (int i = 0; i < brands.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {brands.GetValue(i)}");
            }
            int brandChoice = int.Parse(Console.ReadLine() ?? "0");
            Brand brand = (Brand)brands.GetValue(brandChoice - 1);

            Console.WriteLine("Выберите категорию:");
            var categories = Enum.GetValues(typeof(Category));
            for (int i = 0; i < categories.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {categories.GetValue(i)}");
            }
            int categoryChoice = int.Parse(Console.ReadLine() ?? "0");
            Category category = (Category)categories.GetValue(categoryChoice - 1);

            return new Cosmetic(name, brand, category, price, expiry);
        }

        // Заполнение начальными данными
        private static void SeedData()
        {
            _logic.Create(new Cosmetic("Superstay Matte Ink", Brand.Maybelline, Category.Помада, 899m, 24));
            _logic.Create(new Cosmetic("Pro Filt'r Soft Matte Foundation", Brand.Fenty_Beauty, Category.Тональный_крем, 4200m, 36));
            _logic.Create(new Cosmetic("Volume Express Mascara", Brand.Maybelline, Category.Тушь, 650m, 12));
            _logic.Create(new Cosmetic("Soft Matte Complete Concealer", Brand.NYX, Category.Консилер, 550m, 18));
        }
    }
}