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
            this.Shown += CommonOptionsDialog_Shown;
        }

        public ICollection<string> ApiServices { get; set; } = new List<string>();
        public ICollection<string> SelectedApiServices { get; set; } = new List<string>();
        public bool ShowApiServices { get; set; } = true;

        public ICollection<string> Services { get; set; } = new List<string>();
        public ICollection<string> SelectedServices { get; set; } = new List<string>();
        public bool ShowServices { get; set; } = true;

        public ICollection<string> Models { get; set; } = new List<string>();
        public ICollection<string> SelectedModels { get; set; } = new List<string>();
        public bool ShowModels { get; set; } = true;

        public ICollection<string> Dialogs { get; set; } = new List<string>();
        public ICollection<string> SelectedDialogs { get; set; } = new List<string>();
        public bool ShowDialogs { get; set; } = true;

        private void CommonOptionsDialog_Shown(object sender, EventArgs e)
        {
            if (ShowApiServices)
            {
                foreach (string item in ApiServices)
                    lstApiServices.Items.Add(item);
            }
            else
            {
                lblApiServices.Visible = false;
                lstApiServices.Visible = false;
            }

            if (ShowServices)
            {
                foreach (string item in Services)
                    lstServices.Items.Add(item);
            }
            else
            {
                lblServices.Visible = false;
                lstServices.Visible = false;
            }

            if (ShowModels)
            {
                foreach (string item in Models)
                    lstModels.Items.Add(item);
            }
            else
            {
                lblModels.Visible = false;
                lstModels.Visible = false;
            }

            if (ShowDialogs)
            {
                foreach (string item in Dialogs)
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
            foreach (var item in lstApiServices.SelectedItems)
                SelectedApiServices.Add(item.ToString());
            foreach (var item in lstServices.SelectedItems)
                SelectedServices.Add(item.ToString());
            foreach (var item in lstModels.SelectedItems)
                SelectedModels.Add(item.ToString());
            foreach (var item in lstDialogs.SelectedItems)
                SelectedDialogs.Add(item.ToString());
        }
    }
}
