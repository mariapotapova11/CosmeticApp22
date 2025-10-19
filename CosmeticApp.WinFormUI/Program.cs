using System;
using System.Windows.Forms;
using CosmeticApp.Logic;
using CosmeticApp.Model;

namespace CosmeticApp.WinFormUI
{
    static class Program
    {
        /// <summary>
        /// Точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ICosmeticLogic logic = new CosmeticLogic();
            SeedData(logic);
            Application.Run(new MainForm(logic));
        }

        /// <summary>
        /// Заполнение начальными данными.
        /// </summary>
        /// <param name="logic">Логика приложения.</param>
        private static void SeedData(ICosmeticLogic logic)
        {
            logic.Create(new Cosmetic("Superstay Matte Ink", Brand.Maybelline, Category.Помада, 899m, 24));
            logic.Create(new Cosmetic("Pro Filt'r Soft Matte Foundation", Brand.Fenty_Beauty, Category.Тональный_крем, 4200m, 36));
            logic.Create(new Cosmetic("Volume Express Mascara", Brand.Maybelline, Category.Тушь, 650m, 12));
            logic.Create(new Cosmetic("Soft Matte Complete Concealer", Brand.NYX, Category.Консилер, 550m, 18));
        }
    }
}