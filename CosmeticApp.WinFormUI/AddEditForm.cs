using System;
using System.Linq;
using System.Windows.Forms;
using CosmeticApp.Logic;
using CosmeticApp.Model;

namespace CosmeticApp.WinFormUI
{
    public partial class AddEditForm : Form
    {
        private readonly ICosmeticLogic _logic;
        private readonly Cosmetic _cosmetic;
        private readonly bool _isEditMode;

        public AddEditForm(ICosmeticLogic logic, Cosmetic cosmetic = null)
        {
            InitializeComponent();
            _logic = logic;
            _cosmetic = cosmetic;
            _isEditMode = cosmetic != null;
            InitializeForm();
        }

        private void InitializeForm()
        {
            // Заполнение ComboBox для брендов
            comboBoxBrand.DataSource = Enum.GetValues(typeof(Brand)).Cast<Brand>().ToList();
            // Заполнение ComboBox для категорий
            comboBoxCategory.DataSource = Enum.GetValues(typeof(Category)).Cast<Category>().ToList();

            if (_isEditMode)
            {
                this.Text = "Редактирование Продукта";
                textBoxName.Text = _cosmetic.Name;
                numericUpDownPrice.Value = _cosmetic.Price;
                numericUpDownExpiry.Value = _cosmetic.ExpiryInMonths;
                comboBoxBrand.SelectedItem = _cosmetic.Brand;
                comboBoxCategory.SelectedItem = _cosmetic.Category;
            }
            else
            {
                this.Text = "Добавление Нового Продукта";
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text.Trim();
            decimal price = numericUpDownPrice.Value;
            int expiry = (int)numericUpDownExpiry.Value;
            Brand brand = (Brand)comboBoxBrand.SelectedItem;
            Category category = (Category)comboBoxCategory.SelectedItem;

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Название не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (_isEditMode)
                {
                    var updatedCosmetic = new Cosmetic
                    {
                        Id = _cosmetic.Id,
                        Name = name,
                        Brand = brand,
                        Category = category,
                        Price = price,
                        ExpiryInMonths = expiry
                    };
                    _logic.Update(updatedCosmetic);
                }
                else
                {
                    var newCosmetic = new Cosmetic
                    {
                        Name = name,
                        Brand = brand,
                        Category = category,
                        Price = price,
                        ExpiryInMonths = expiry
                    };
                    _logic.Create(newCosmetic);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
