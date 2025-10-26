using System;
using System.Windows.Forms;
using CosmeticApp.DataAccessLayer;
using CosmeticApp.Logic;
using CosmeticApp.Model;

namespace CosmeticApp.WinForms
{
    /// <summary>
    /// ������� ����� ����������, ���������� ����� �����
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// ������� ����� ����� ��� ����������
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