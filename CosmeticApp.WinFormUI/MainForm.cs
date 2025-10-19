using System;
using System.Linq;
using System.Windows.Forms;
using CosmeticApp.Logic;
using CosmeticApp.Model;

namespace CosmeticApp.WinFormUI
{
    public partial class MainForm : Form
    {
        private readonly ICosmeticLogic _logic;

        public MainForm(ICosmeticLogic logic)
        {
            InitializeComponent();
            _logic = logic;
            InitializeDataGridView();
            LoadAllCosmetics();
        }

        private void InitializeDataGridView()
        {
            dataGridViewCosmetics.AutoGenerateColumns = false;
            dataGridViewCosmetics.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "ID",
                DataPropertyName = "Id",
                ReadOnly = true
            });
            dataGridViewCosmetics.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Название",
                DataPropertyName = "Name"
            });
            dataGridViewCosmetics.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Бренд",
                DataPropertyName = "Brand"
            });
            dataGridViewCosmetics.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Категория",
                DataPropertyName = "Category"
            });
            dataGridViewCosmetics.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Цена",
                DataPropertyName = "Price",
                DefaultCellStyle = { Format = "C" }
            });
            dataGridViewCosmetics.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Срок годности (мес)",
                DataPropertyName = "ExpiryInMonths"
            });

            dataGridViewCosmetics.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewCosmetics.MultiSelect = false;
            dataGridViewCosmetics.ReadOnly = true;
            dataGridViewCosmetics.AllowUserToAddRows = false;
            dataGridViewCosmetics.AllowUserToDeleteRows = false;
        }

        private void LoadAllCosmetics()
        {
            var cosmetics = _logic.GetAllCosmetics().ToList();
            dataGridViewCosmetics.DataSource = cosmetics;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var addForm = new AddEditForm(_logic);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadAllCosmetics();
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewCosmetics.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите продукт для обновления.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedCosmetic = (Cosmetic)dataGridViewCosmetics.SelectedRows[0].DataBoundItem;
            var editForm = new AddEditForm(_logic, selectedCosmetic);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadAllCosmetics();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewCosmetics.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите продукт для удаления.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedCosmetic = (Cosmetic)dataGridViewCosmetics.SelectedRows[0].DataBoundItem;
            var result = MessageBox.Show($"Вы действительно хотите удалить продукт '{selectedCosmetic.Name}'?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    _logic.Delete(selectedCosmetic.Id);
                    LoadAllCosmetics();
                    MessageBox.Show("Продукт успешно удален.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Введите ID продукта для поиска:", "Поиск по ID", "");
            if (int.TryParse(input, out int id))
            {
                try
                {
                    var cosmetic = _logic.Read(id);
                    dataGridViewCosmetics.DataSource = new[] { cosmetic }.ToList();
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Некорректный ввод ID.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonShowAll_Click(object sender, EventArgs e)
        {
            LoadAllCosmetics();
        }

        private void buttonShowByBrand_Click(object sender, EventArgs e)
        {
            var brands = Enum.GetValues(typeof(Brand)).Cast<Brand>().ToList();
            var selectForm = new SelectionForm<Brand>("Выберите бренд:", brands);
            if (selectForm.ShowDialog() == DialogResult.OK)
            {
                Brand selectedBrand = selectForm.SelectedItem;
                var cosmetics = _logic.GetCosmeticsByBrand(selectedBrand).ToList();
                dataGridViewCosmetics.DataSource = cosmetics;
            }
        }

        private void buttonShowExpensive_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Введите пороговую цену:", "Показать дорогие продукты", "1500");
            if (decimal.TryParse(input, out decimal threshold))
            {
                var cosmetics = _logic.GetExpensiveCosmetics(threshold).ToList();
                dataGridViewCosmetics.DataSource = cosmetics;
            }
            else
            {
                MessageBox.Show("Некорректный ввод цены.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
