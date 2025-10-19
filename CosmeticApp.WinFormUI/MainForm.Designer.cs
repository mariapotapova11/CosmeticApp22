namespace CosmeticApp.WinFormUI
{
    partial class MainForm
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
            dataGridViewCosmetics = new DataGridView();
            buttonAdd = new Button();
            buttonUpdate = new Button();
            buttonDelete = new Button();
            buttonFind = new Button();
            buttonShowByBrand = new Button();
            buttonShowExpensive = new Button();
            buttonShowAll = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCosmetics).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewCosmetics
            // 
            dataGridViewCosmetics.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCosmetics.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCosmetics.Location = new Point(12, 12);
            dataGridViewCosmetics.Name = "dataGridViewCosmetics";
            dataGridViewCosmetics.RowHeadersWidth = 51;
            dataGridViewCosmetics.Size = new Size(981, 400);
            dataGridViewCosmetics.TabIndex = 0;
            // 
            // buttonAdd
            // 
            buttonAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonAdd.Location = new Point(12, 430);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(120, 30);
            buttonAdd.TabIndex = 1;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonUpdate
            // 
            buttonUpdate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonUpdate.Location = new Point(150, 430);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(120, 30);
            buttonUpdate.TabIndex = 2;
            buttonUpdate.Text = "Обновить";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonDelete.Location = new Point(290, 430);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(120, 30);
            buttonDelete.TabIndex = 3;
            buttonDelete.Text = "Удалить";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonFind
            // 
            buttonFind.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonFind.Location = new Point(430, 430);
            buttonFind.Name = "buttonFind";
            buttonFind.Size = new Size(120, 30);
            buttonFind.TabIndex = 4;
            buttonFind.Text = "Найти по ID";
            buttonFind.UseVisualStyleBackColor = true;
            buttonFind.Click += buttonFind_Click;
            // 
            // buttonShowByBrand
            // 
            buttonShowByBrand.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonShowByBrand.Location = new Point(723, 430);
            buttonShowByBrand.Name = "buttonShowByBrand";
            buttonShowByBrand.Size = new Size(160, 30);
            buttonShowByBrand.TabIndex = 5;
            buttonShowByBrand.Text = "Показать по бренду";
            buttonShowByBrand.UseVisualStyleBackColor = true;
            buttonShowByBrand.Click += buttonShowByBrand_Click;
            // 
            // buttonShowExpensive
            // 
            buttonShowExpensive.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonShowExpensive.Location = new Point(901, 430);
            buttonShowExpensive.Name = "buttonShowExpensive";
            buttonShowExpensive.Size = new Size(120, 30);
            buttonShowExpensive.TabIndex = 6;
            buttonShowExpensive.Text = "Дорогие (>1500)";
            buttonShowExpensive.UseVisualStyleBackColor = true;
            buttonShowExpensive.Click += buttonShowExpensive_Click;
            // 
            // buttonShowAll
            // 
            buttonShowAll.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonShowAll.Location = new Point(560, 430);
            buttonShowAll.Name = "buttonShowAll";
            buttonShowAll.Size = new Size(145, 30);
            buttonShowAll.TabIndex = 7;
            buttonShowAll.Text = "Показать все";
            buttonShowAll.UseVisualStyleBackColor = true;
            buttonShowAll.Click += buttonShowAll_Click;
            // 
            // MainForm
            // 
            ClientSize = new Size(1025, 481);
            Controls.Add(buttonShowAll);
            Controls.Add(buttonShowExpensive);
            Controls.Add(buttonShowByBrand);
            Controls.Add(buttonFind);
            Controls.Add(buttonDelete);
            Controls.Add(buttonUpdate);
            Controls.Add(buttonAdd);
            Controls.Add(dataGridViewCosmetics);
            Name = "MainForm";
            Text = "Косметический Магазин - Управление Продуктами";
            ((System.ComponentModel.ISupportInitialize)dataGridViewCosmetics).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewCosmetics;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.Button buttonShowByBrand;
        private System.Windows.Forms.Button buttonShowExpensive;
        private System.Windows.Forms.Button buttonShowAll;
    }
}