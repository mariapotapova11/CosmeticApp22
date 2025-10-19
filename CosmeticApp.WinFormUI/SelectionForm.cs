using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CosmeticApp.WinFormUI
{
    public partial class SelectionForm<T> : Form where T : Enum
    {
        public T SelectedItem { get; private set; }

        public SelectionForm(string title, List<T> items)
        {
            InitializeComponent(); // Убедитесь, что этот метод существует в дизайнере формы
            this.Text = title;
            listBoxItems.DataSource = items; // Убедитесь, что listBoxItems существует на форме
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            if (listBoxItems.SelectedItem != null)
            {
                SelectedItem = (T)listBoxItems.SelectedItem;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Выберите элемент из списка.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Добавьте обработчик для двойного клика по списку (опционально)
        private void listBoxItems_DoubleClick(object sender, EventArgs e)
        {
            buttonSelect_Click(sender, e);
        }

        // Добавьте обработчик для клавиши Enter (опционально)
        private void listBoxItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonSelect_Click(sender, e);
                e.Handled = true;
            }
        }
    }
}