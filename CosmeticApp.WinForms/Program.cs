using System;
using System.Windows.Forms;
using CosmeticApp.DataAccessLayer;
using CosmeticApp.Logic;
using CosmeticApp.Model;

namespace CosmeticApp.WinForms
{
    /// <summary>
    /// Главный класс приложения, содержащий точку входа
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var repository = RepositorySelectionForm.SelectRepository();
            var mainForm = new MainForm(new CosmeticLogic(repository));

            Application.Run(mainForm);
        }
    }
}