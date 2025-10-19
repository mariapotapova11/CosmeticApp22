using System;
using System.Windows.Forms;
using CosmeticApp.Logic;
using CosmeticApp.Model;

namespace CosmeticApp.WinFormUI
{
    static class Program
    {
        /// <summary>
        /// ����� ����� ��� ����������.
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
        /// ���������� ���������� �������.
        /// </summary>
        /// <param name="logic">������ ����������.</param>
        private static void SeedData(ICosmeticLogic logic)
        {
            logic.Create(new Cosmetic("Superstay Matte Ink", Brand.Maybelline, Category.������, 899m, 24));
            logic.Create(new Cosmetic("Pro Filt'r Soft Matte Foundation", Brand.Fenty_Beauty, Category.���������_����, 4200m, 36));
            logic.Create(new Cosmetic("Volume Express Mascara", Brand.Maybelline, Category.����, 650m, 12));
            logic.Create(new Cosmetic("Soft Matte Complete Concealer", Brand.NYX, Category.��������, 550m, 18));
        }
    }
}