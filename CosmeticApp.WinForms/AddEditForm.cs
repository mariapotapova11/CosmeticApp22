using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CosmeticApp.Logic;
using CosmeticApp.Model;

namespace CosmeticApp.WinForms
{
    /// <summary>
    /// Форма для добавления или редактирования косметического продукта
    /// </summary>
    public partial class AddEditForm : Form
    {
        private readonly ICosmeticLogic _logic;
        private readonly Cosmetic _cosmetic;
        private readonly bool _isEditMode;

        /// <summary>
        /// Получает созданный или отредактированный косметический продукт
        /// </summary>
        public Cosmetic Cosmetic { get; private set; }

        /// <summary>
        /// Инициализирует новый экземпляр формы AddEditForm
        /// </summary>
        /// <param name="logic">Логика работы с косметическими продуктами</param>
        /// <param name="cosmetic">Существующий продукт для редактирования (null для создания нового)</param>
        public AddEditForm(ICosmeticLogic logic, Cosmetic cosmetic = null)
        {
            InitializeComponent();
            _logic = logic;
            _cosmetic = cosmetic;
            _isEditMode = cosmetic != null;
            InitializeForm();
            ApplyPinkTheme();
        }

        /// <summary>
        /// Применяет розовую цветовую схему к форме
        /// </summary>
        private void ApplyPinkTheme()
        {
            // Розовая цветовая схема
            panelMain.BackColor = Color.FromArgb(255, 253, 245, 250);
            labelTitle.BackColor = Color.FromArgb(255, 199, 21, 133);

            // Стиль меток
            foreach (Control control in panelMain.Controls)
            {
                if (control is Label label && label != labelTitle)
                {
                    label.ForeColor = Color.FromArgb(255, 75, 0, 100);
                }
            }

            // Стиль кнопок
            buttonSave.BackColor = Color.FromArgb(255, 255, 105, 180);
            buttonSave.ForeColor = Color.White;
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.FlatAppearance.BorderSize = 0;

            buttonCancel.BackColor = Color.FromArgb(255, 219, 112, 147);
            buttonCancel.ForeColor = Color.White;
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.FlatAppearance.BorderSize = 0;

            // Стиль контролов ввода
            textBoxName.BorderStyle = BorderStyle.FixedSingle;
            comboBoxBrand.FlatStyle = FlatStyle.Flat;
            comboBoxCategory.FlatStyle = FlatStyle.Flat;
        }

        /// <summary>
        /// Инициализирует состояние формы в зависимости от режима (добавление/редактирование)
        /// </summary>
        private void InitializeForm()
        {
            comboBoxBrand.DataSource = Enum.GetValues(typeof(Brand)).Cast<Brand>().ToList();
            comboBoxCategory.DataSource = Enum.GetValues(typeof(Category)).Cast<Category>().ToList();

            if (_isEditMode)
            {
                this.Text = "Редактирование продукта";
                labelTitle.Text = "✏️ Редактирование продукта";
                textBoxName.Text = _cosmetic.Name;
                numericUpDownPrice.Value = _cosmetic.Price;
                numericUpDownExpiry.Value = _cosmetic.ExpiryInMonths;
                comboBoxBrand.SelectedItem = _cosmetic.Brand;
                comboBoxCategory.SelectedItem = _cosmetic.Category;
            }
            else
            {
                this.Text = "Добавление нового продукта";
                labelTitle.Text = "➕ Добавление нового продукта";
            }
        }

        /// <summary>
        /// Обрабатывает событие нажатия кнопки сохранения
        /// </summary>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text.Trim();
            decimal price = numericUpDownPrice.Value;
            int expiry = (int)numericUpDownExpiry.Value;
            Brand brand = (Brand)comboBoxBrand.SelectedItem;
            Category category = (Category)comboBoxCategory.SelectedItem;

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Название не может быть пустым.", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxName.Focus();
                return;
            }

            try
            {
                if (_isEditMode)
                {
                    Cosmetic = new Cosmetic(name, brand, category, price, expiry)
                    {
                        Id = _cosmetic.Id
                    };
                    _logic.Update(Cosmetic);
                }
                else
                {
                    Cosmetic = new Cosmetic(name, brand, category, price, expiry);
                    _logic.Create(Cosmetic);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обрабатывает событие нажатия кнопки отмены
        /// </summary>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}