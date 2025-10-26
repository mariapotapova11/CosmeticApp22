using System;
using System.Windows.Forms;
using CosmeticApp.DataAccessLayer;
using CosmeticApp.Model;

namespace CosmeticApp.WinForms
{
    public partial class RepositorySelectionForm : Form
    {
        public string SelectedRepository { get; private set; }

        public RepositorySelectionForm()
        {
            InitializeComponent();
        }

        private void btnEntityFramework_Click(object sender, EventArgs e)
        {
            SelectedRepository = "EntityFramework";
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnDapper_Click(object sender, EventArgs e)
        {
            SelectedRepository = "Dapper";
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public static IRepository<Cosmetic> SelectRepository()
        {
            using (var form = new RepositorySelectionForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    return form.SelectedRepository == "EntityFramework"
                        ? new EntityRepository<Cosmetic>()
                        : new DapperRepository<Cosmetic>();
                }
                return new EntityRepository<Cosmetic>();
            }
        }
    }
}