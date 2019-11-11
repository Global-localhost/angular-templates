using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Angular.Wizards
{
    public partial class CommonOptionsDialog : Form
    {
        public CommonOptionsDialog()
        {
            InitializeComponent();
            lstApiServices.DisplayMember = "Name";
            lstDialogs.DisplayMember = "Name";
            lstModels.DisplayMember = "Name";
            lstServices.DisplayMember = "Name";
            this.Shown += CommonOptionsDialog_Shown;
        }

        internal ICollection<Utilities.ClassModel> ApiServices { get; set; } = new List<Utilities.ClassModel>();
        internal ICollection<Utilities.ClassModel> SelectedApiServices { get; set; } = new List<Utilities.ClassModel>();
        public bool ShowApiServices { get; set; } = true;

        internal ICollection<Utilities.ClassModel> Services { get; set; } = new List<Utilities.ClassModel>();
        internal ICollection<Utilities.ClassModel> SelectedServices { get; set; } = new List<Utilities.ClassModel>();
        public bool ShowServices { get; set; } = true;

        internal ICollection<Utilities.ClassModel> Models { get; set; } = new List<Utilities.ClassModel>();
        internal ICollection<Utilities.ClassModel> SelectedModels { get; set; } = new List<Utilities.ClassModel>();
        public bool ShowModels { get; set; } = true;

        internal ICollection<Utilities.ClassModel> Dialogs { get; set; } = new List<Utilities.ClassModel>();
        internal ICollection<Utilities.ClassModel> SelectedDialogs { get; set; } = new List<Utilities.ClassModel>();
        public bool ShowDialogs { get; set; } = true;

        internal bool ReloadSettings { get; set; } = false;

        private void CommonOptionsDialog_Shown(object sender, EventArgs e)
        {
            if (ShowApiServices)
            {
                foreach (Utilities.ClassModel item in ApiServices)
                    lstApiServices.Items.Add(item);
            }
            else
            {
                lblApiServices.Visible = false;
                lstApiServices.Visible = false;
            }

            if (ShowServices)
            {
                foreach (Utilities.ClassModel item in Services)
                    lstServices.Items.Add(item);
            }
            else
            {
                lblServices.Visible = false;
                lstServices.Visible = false;
            }

            if (ShowModels)
            {
                foreach (Utilities.ClassModel item in Models)
                    lstModels.Items.Add(item);
            }
            else
            {
                lblModels.Visible = false;
                lstModels.Visible = false;
            }

            if (ShowDialogs)
            {
                foreach (Utilities.ClassModel item in Dialogs)
                    lstDialogs.Items.Add(item);
            }
            else
            {
                lblDialogs.Visible = false;
                lstDialogs.Visible = false;
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            foreach (var item in lstApiServices.CheckedItems)
                SelectedApiServices.Add(item as Utilities.ClassModel);
            foreach (var item in lstServices.CheckedItems)
                SelectedServices.Add(item as Utilities.ClassModel);
            foreach (var item in lstModels.CheckedItems)
                SelectedModels.Add(item as Utilities.ClassModel);
            foreach (var item in lstDialogs.CheckedItems)
                SelectedDialogs.Add(item as Utilities.ClassModel);
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            SettingsDialog settingsDialog = new SettingsDialog();
            DialogResult dialogResult = settingsDialog.ShowDialog(this);
            if(dialogResult == DialogResult.OK)
            {
                // reload the possible items, perhaps close this dialog with a retry result?
                ReloadSettings = true;
            }

            settingsDialog.Close();
        }
    }
}
