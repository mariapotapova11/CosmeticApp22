namespace CosmeticApp.WinFormUI
{
    partial class AddEditForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Очистка всех используемых ресурсов.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            labelName = new Label();
            labelBrand = new Label();
            labelCategory = new Label();
            labelPrice = new Label();
            labelExpiry = new Label();
            textBoxName = new TextBox();
            comboBoxBrand = new ComboBox();
            comboBoxCategory = new ComboBox();
            numericUpDownPrice = new NumericUpDown();
            numericUpDownExpiry = new NumericUpDown();
            buttonSave = new Button();
            buttonCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownExpiry).BeginInit();
            SuspendLayout();
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Font = new Font("Microsoft Sans Serif", 10F);
            labelName.Location = new Point(25, 25);
            labelName.Name = "labelName";
            labelName.Size = new Size(96, 20);
            labelName.TabIndex = 0;
            labelName.Text = "Название:";
            // 
            // labelBrand
            // 
            labelBrand.AutoSize = true;
            labelBrand.Font = new Font("Microsoft Sans Serif", 10F);
            labelBrand.Location = new Point(25, 65);
            labelBrand.Name = "labelBrand";
            labelBrand.Size = new Size(68, 20);
            labelBrand.TabIndex = 1;
            labelBrand.Text = "Бренд:";
            // 
            // labelCategory
            // 
            labelCategory.AutoSize = true;
            labelCategory.Font = new Font("Microsoft Sans Serif", 10F);
            labelCategory.Location = new Point(25, 105);
            labelCategory.Name = "labelCategory";
            labelCategory.Size = new Size(103, 20);
            labelCategory.TabIndex = 2;
            labelCategory.Text = "Категория:";
            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.Font = new Font("Microsoft Sans Serif", 10F);
            labelPrice.Location = new Point(25, 145);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(57, 20);
            labelPrice.TabIndex = 3;
            labelPrice.Text = "Цена:";
            // 
            // labelExpiry
            // 
            labelExpiry.AutoSize = true;
            labelExpiry.Font = new Font("Microsoft Sans Serif", 10F);
            labelExpiry.Location = new Point(25, 185);
            labelExpiry.Name = "labelExpiry";
            labelExpiry.Size = new Size(187, 20);
            labelExpiry.TabIndex = 4;
            labelExpiry.Text = "Срок годности (мес):";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(219, 24);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(200, 27);
            textBoxName.TabIndex = 5;
            // 
            // comboBoxBrand
            // 
            comboBoxBrand.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxBrand.FormattingEnabled = true;
            comboBoxBrand.Location = new Point(219, 64);
            comboBoxBrand.Name = "comboBoxBrand";
            comboBoxBrand.Size = new Size(200, 28);
            comboBoxBrand.TabIndex = 6;
            // 
            // comboBoxCategory
            // 
            comboBoxCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCategory.FormattingEnabled = true;
            comboBoxCategory.Location = new Point(219, 104);
            comboBoxCategory.Name = "comboBoxCategory";
            comboBoxCategory.Size = new Size(200, 28);
            comboBoxCategory.TabIndex = 7;
            // 
            // numericUpDownPrice
            // 
            numericUpDownPrice.DecimalPlaces = 2;
            numericUpDownPrice.Location = new Point(219, 144);
            numericUpDownPrice.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDownPrice.Name = "numericUpDownPrice";
            numericUpDownPrice.Size = new Size(200, 27);
            numericUpDownPrice.TabIndex = 8;
            numericUpDownPrice.ThousandsSeparator = true;
            // 
            // numericUpDownExpiry
            // 
            numericUpDownExpiry.Location = new Point(219, 184);
            numericUpDownExpiry.Maximum = new decimal(new int[] { 120, 0, 0, 0 });
            numericUpDownExpiry.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownExpiry.Name = "numericUpDownExpiry";
            numericUpDownExpiry.Size = new Size(200, 27);
            numericUpDownExpiry.TabIndex = 9;
            numericUpDownExpiry.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(219, 230);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(90, 30);
            buttonSave.TabIndex = 10;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonCancel.Location = new Point(329, 230);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(90, 30);
            buttonCancel.TabIndex = 11;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // AddEditForm
            // 
            AcceptButton = buttonSave;
            CancelButton = buttonCancel;
            ClientSize = new Size(451, 281);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(numericUpDownExpiry);
            Controls.Add(numericUpDownPrice);
            Controls.Add(comboBoxCategory);
            Controls.Add(comboBoxBrand);
            Controls.Add(textBoxName);
            Controls.Add(labelExpiry);
            Controls.Add(labelPrice);
            Controls.Add(labelCategory);
            Controls.Add(labelBrand);
            Controls.Add(labelName);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "AddEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Добавление/Редактирование Продукта";
            ((System.ComponentModel.ISupportInitialize)numericUpDownPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownExpiry).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelBrand;
        private System.Windows.Forms.Label labelCategory;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Label labelExpiry;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.ComboBox comboBoxBrand;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.NumericUpDown numericUpDownPrice;
        private System.Windows.Forms.NumericUpDown numericUpDownExpiry;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}