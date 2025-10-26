using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CosmeticApp.Logic;
using CosmeticApp.Model;
using CosmeticApp.DataAccessLayer;

namespace CosmeticApp.WinForms
{
    public partial class MainForm : Form
    {
        private ICosmeticLogic _logic;

        public MainForm(ICosmeticLogic cosmeticLogic)
        {
            InitializeComponent();
            _logic = cosmeticLogic;
            InitializeDataGridView();
            LoadAllCosmetics();
            ApplyPinkTheme();
        }

        public MainForm() : this(new CosmeticLogic()) { }

        private void ApplyPinkTheme()
        {
            this.BackColor = Color.FromArgb(255, 253, 245, 250);
            panelHeader.BackColor = Color.FromArgb(255, 219, 112, 147);
            labelHeader.ForeColor = Color.White;

            buttonAdd.BackColor = Color.FromArgb(255, 255, 105, 180);
            buttonUpdate.BackColor = Color.FromArgb(255, 255, 128, 171);
            buttonDelete.BackColor = Color.FromArgb(255, 219, 112, 147);

            Color filterButtonColor = Color.FromArgb(255, 255, 182, 193);
            buttonFind.BackColor = filterButtonColor;
            buttonShowByBrand.BackColor = filterButtonColor;
            buttonShowExpensive.BackColor = filterButtonColor;
            buttonShowAll.BackColor = filterButtonColor;
        }

        private void InitializeDataGridView()
        {
            dataGridViewCosmetics.AutoGenerateColumns = false;
            dataGridViewCosmetics.Columns.Clear();

            dataGridViewCosmetics.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "Id", Width = 50 });
            dataGridViewCosmetics.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "��������", DataPropertyName = "Name", Width = 150 });
            dataGridViewCosmetics.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "�����", DataPropertyName = "Brand", Width = 100 });
            dataGridViewCosmetics.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "���������", DataPropertyName = "Category", Width = 120 });
            dataGridViewCosmetics.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "����", DataPropertyName = "Price", DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }, Width = 80 });
            dataGridViewCosmetics.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "���� ��������", DataPropertyName = "ExpiryInMonths", Width = 120 });

            dataGridViewCosmetics.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewCosmetics.ReadOnly = true;
        }

        private void LoadAllCosmetics()
        {
            try
            {
                var cosmetics = _logic.GetAllCosmetics().ToList();
                dataGridViewCosmetics.DataSource = cosmetics;
                UpdateStatusBar();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��������: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStatusBar()
        {
            string repoName = GetRepositoryName();
            int itemCount = dataGridViewCosmetics.Rows.Count;
            statusLabel.Text = $"�����������: {repoName} | �������: {itemCount}";
        }

        private string GetRepositoryName()
        {
            if (_logic is CosmeticLogic cosmeticLogic)
            {
                // ���������� ��������� ��� ����������� ���� �����������
                var repositoryField = typeof(CosmeticLogic).GetField("_repository",
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

                if (repositoryField != null)
                {
                    var repository = repositoryField.GetValue(cosmeticLogic);
                    return repository switch
                    {
                        EntityRepository<Cosmetic> => "Entity Framework",
                        DapperRepository<Cosmetic> => "Dapper",
                        _ => "Unknown"
                    };
                }
            }
            return "Entity Framework";
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var addForm = new AddEditForm(_logic);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadAllCosmetics();
                MessageBox.Show("������� ������� ��������!", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewCosmetics.SelectedRows.Count == 0)
            {
                MessageBox.Show("�������� ������� ��� ����������.", "����������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedCosmetic = (Cosmetic)dataGridViewCosmetics.SelectedRows[0].DataBoundItem;
            var editForm = new AddEditForm(_logic, selectedCosmetic);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadAllCosmetics();
                MessageBox.Show("������� ������� ��������!", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewCosmetics.SelectedRows.Count == 0)
            {
                MessageBox.Show("�������� ������� ��� ��������.", "����������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedCosmetic = (Cosmetic)dataGridViewCosmetics.SelectedRows[0].DataBoundItem;
            var result = MessageBox.Show($"������� '{selectedCosmetic.Name}'?", "�������������", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    _logic.Delete(selectedCosmetic.Id);
                    LoadAllCosmetics();
                    MessageBox.Show("������� ������.", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("������� ID ��������:", "����� �� ID", "");
            if (int.TryParse(input, out int id))
            {
                try
                {
                    var cosmetic = _logic.ReadById(id);
                    dataGridViewCosmetics.DataSource = new[] { cosmetic }.ToList();
                    UpdateStatusBar();
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonShowAll_Click(object sender, EventArgs e) => LoadAllCosmetics();

        private void buttonShowByBrand_Click(object sender, EventArgs e)
        {
            var brands = Enum.GetValues(typeof(Brand)).Cast<Brand>().ToList();
            string brandList = string.Join("\n", brands.Select((b, i) => $"{i + 1}. {b}"));
            string input = Microsoft.VisualBasic.Interaction.InputBox($"�������� �����:\n{brandList}", "������ �� ������", "");

            if (int.TryParse(input, out int brandIndex) && brandIndex > 0 && brandIndex <= brands.Count)
            {
                Brand selectedBrand = brands[brandIndex - 1];
                var cosmetics = _logic.GetCosmeticsByBrand(selectedBrand).ToList();
                dataGridViewCosmetics.DataSource = cosmetics;
                UpdateStatusBar();
            }
        }

        private void buttonShowExpensive_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("������� ��������� ����:", "������� ��������", "1500");
            if (decimal.TryParse(input, out decimal threshold))
            {
                var cosmetics = _logic.GetExpensiveCosmetics(threshold).ToList();
                dataGridViewCosmetics.DataSource = cosmetics;
                UpdateStatusBar();
            }
        }

        private void labelHeader_Click(object sender, EventArgs e)
        {
            // ������ ���������� ��� ������� ����� �� ���������
        }
    }
}