using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Angular.Wizards.Page
{
    public partial class PageWizardDialog : BaseOptionsDialog
    {
        public PageWizardDialog()
        {
            InitializeComponent();
            this.Shown += PageWizardDialog_Shown;
        }

        private void PageWizardDialog_Shown(object sender, EventArgs e)
        {
            foreach (string item in ApiServices)
                lstApiServices.Items.Add(item);
            foreach (string item in Services)
                lstServices.Items.Add(item);
            foreach (string item in Models)
                lstModels.Items.Add(item);
            foreach (string item in Dialogs)
                lstDialogs.Items.Add(item);
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
