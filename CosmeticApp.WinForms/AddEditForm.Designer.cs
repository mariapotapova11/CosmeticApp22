namespace CosmeticApp.WinForms
{
    partial class AddEditForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

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
            panelMain = new Panel();
            labelTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownExpiry).BeginInit();
            panelMain.SuspendLayout();
            SuspendLayout();
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelName.Location = new Point(30, 80);
            labelName.Name = "labelName";
            labelName.Size = new Size(94, 23);
            labelName.TabIndex = 0;
            labelName.Text = "Название:";
            // 
            // labelBrand
            // 
            labelBrand.AutoSize = true;
            labelBrand.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelBrand.Location = new Point(30, 130);
            labelBrand.Name = "labelBrand";
            labelBrand.Size = new Size(67, 23);
            labelBrand.TabIndex = 1;
            labelBrand.Text = "Бренд:";
            // 
            // labelCategory
            // 
            labelCategory.AutoSize = true;
            labelCategory.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelCategory.Location = new Point(30, 180);
            labelCategory.Name = "labelCategory";
            labelCategory.Size = new Size(101, 23);
            labelCategory.TabIndex = 2;
            labelCategory.Text = "Категория:";
            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelPrice.Location = new Point(30, 230);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(57, 23);
            labelPrice.TabIndex = 3;
            labelPrice.Text = "Цена:";
            // 
            // labelExpiry
            // 
            labelExpiry.AutoSize = true;
            labelExpiry.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelExpiry.Location = new Point(30, 280);
            labelExpiry.Name = "labelExpiry";
            labelExpiry.Size = new Size(184, 23);
            labelExpiry.TabIndex = 4;
            labelExpiry.Text = "Срок годности (мес):";
            // 
            // textBoxName
            // 
            textBoxName.Font = new Font("Segoe UI", 10F);
            textBoxName.Location = new Point(230, 78);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(250, 30);
            textBoxName.TabIndex = 1;
            // 
            // comboBoxBrand
            // 
            comboBoxBrand.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxBrand.Font = new Font("Segoe UI", 10F);
            comboBoxBrand.FormattingEnabled = true;
            comboBoxBrand.Location = new Point(230, 128);
            comboBoxBrand.Name = "comboBoxBrand";
            comboBoxBrand.Size = new Size(250, 31);
            comboBoxBrand.TabIndex = 2;
            // 
            // comboBoxCategory
            // 
            comboBoxCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCategory.Font = new Font("Segoe UI", 10F);
            comboBoxCategory.FormattingEnabled = true;
            comboBoxCategory.Location = new Point(230, 178);
            comboBoxCategory.Name = "comboBoxCategory";
            comboBoxCategory.Size = new Size(250, 31);
            comboBoxCategory.TabIndex = 3;
            // 
            // numericUpDownPrice
            // 
            numericUpDownPrice.DecimalPlaces = 2;
            numericUpDownPrice.Font = new Font("Segoe UI", 10F);
            numericUpDownPrice.Location = new Point(230, 228);
            numericUpDownPrice.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDownPrice.Name = "numericUpDownPrice";
            numericUpDownPrice.Size = new Size(250, 30);
            numericUpDownPrice.TabIndex = 4;
            numericUpDownPrice.ThousandsSeparator = true;
            // 
            // numericUpDownExpiry
            // 
            numericUpDownExpiry.Font = new Font("Segoe UI", 10F);
            numericUpDownExpiry.Location = new Point(230, 278);
            numericUpDownExpiry.Maximum = new decimal(new int[] { 120, 0, 0, 0 });
            numericUpDownExpiry.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownExpiry.Name = "numericUpDownExpiry";
            numericUpDownExpiry.Size = new Size(250, 30);
            numericUpDownExpiry.TabIndex = 5;
            numericUpDownExpiry.Value = new decimal(new int[] { 12, 0, 0, 0 });
            // 
            // buttonSave
            // 
            buttonSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonSave.Location = new Point(230, 330);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(120, 40);
            buttonSave.TabIndex = 6;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonCancel.Location = new Point(360, 330);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(120, 40);
            buttonCancel.TabIndex = 7;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // panelMain
            // 
            panelMain.Controls.Add(labelTitle);
            panelMain.Controls.Add(labelName);
            panelMain.Controls.Add(buttonCancel);
            panelMain.Controls.Add(labelBrand);
            panelMain.Controls.Add(buttonSave);
            panelMain.Controls.Add(labelCategory);
            panelMain.Controls.Add(numericUpDownExpiry);
            panelMain.Controls.Add(labelPrice);
            panelMain.Controls.Add(numericUpDownPrice);
            panelMain.Controls.Add(labelExpiry);
            panelMain.Controls.Add(comboBoxCategory);
            panelMain.Controls.Add(textBoxName);
            panelMain.Controls.Add(comboBoxBrand);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(532, 400);
            panelMain.TabIndex = 8;
            // 
            // labelTitle
            // 
            labelTitle.BackColor = Color.Pink;
            labelTitle.Dock = DockStyle.Top;
            labelTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(0, 0);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(532, 50);
            labelTitle.TabIndex = 8;
            labelTitle.Text = "Добавление продукта";
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AddEditForm
            // 
            AcceptButton = buttonSave;
            BackColor = Color.White;
            CancelButton = buttonCancel;
            ClientSize = new Size(532, 400);
            Controls.Add(panelMain);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Косметический продукт";
            ((System.ComponentModel.ISupportInitialize)numericUpDownPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownExpiry).EndInit();
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label labelName;
        private Label labelBrand;
        private Label labelCategory;
        private Label labelPrice;
        private Label labelExpiry;
        private TextBox textBoxName;
        private ComboBox comboBoxBrand;
        private ComboBox comboBoxCategory;
        private NumericUpDown numericUpDownPrice;
        private NumericUpDown numericUpDownExpiry;
        private Button buttonSave;
        private Button buttonCancel;
        private Panel panelMain;
        private Label labelTitle;
    }
}