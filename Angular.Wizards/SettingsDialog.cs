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
    public partial class SettingsDialog : Form
    {
        private enum SettingGroup
        {
            General = 0,
            ApiService,
            Component,
            MaterialDialog,
            Model,
            Page,
            Service
        }

        private readonly Utilities.Settings _settings = new Utilities.Settings();

        private readonly IList<KeyValuePair<string, string>> _stringSeperators = new List<KeyValuePair<string, string>>()
        {
            new KeyValuePair<string, string>("'", "Single-Quote (')"),
            new KeyValuePair<string, string>("\"", "Double-Quote (\")")
        };

        private readonly IList<KeyValuePair<string, string>> _stylesheetFormat = new List<KeyValuePair<string, string>>()
        {
            new KeyValuePair<string, string>("scss", "SASS" ),
            new KeyValuePair<string, string>("less", "LESS" ),
            new KeyValuePair<string, string>("css", "CSS" )
        };

        public SettingsDialog()
        {
            InitializeComponent();

            cmbStringQuote.DataSource = _stringSeperators;
            cmbStringQuote.ValueMember = "Key";
            cmbStringQuote.DisplayMember = "Value";

            cmbStylesheetFormat.DataSource = _stylesheetFormat;
            cmbStylesheetFormat.ValueMember = "Key";
            cmbStylesheetFormat.DisplayMember = "Value";
        }

        private void LstGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            SettingGroup settingGroup = (SettingGroup)lstGroup.SelectedIndex;

            pnlGeneral.Visible = false;
            pnlApiService.Visible = false;
            pnlComponent.Visible = false;
            pnlMaterialDialog.Visible = false;
            pnlModel.Visible = false;
            pnlPage.Visible = false;
            pnlService.Visible = false;

            switch (settingGroup)
            {
                case SettingGroup.General:
                    pnlGeneral.Visible = true;
                    break;
                case SettingGroup.ApiService:
                    pnlApiService.Visible = true;
                    break;
                case SettingGroup.Component:
                    pnlComponent.Visible = true;
                    break;
                case SettingGroup.MaterialDialog:
                    pnlMaterialDialog.Visible = true;
                    break;
                case SettingGroup.Model:
                    pnlModel.Visible = true;
                    break;
                case SettingGroup.Page:
                    pnlPage.Visible = true;
                    break;
                case SettingGroup.Service:
                    pnlService.Visible = true;
                    break;
            }
        }

        private void SettingsDialog_Load(object sender, EventArgs e)
        {
            pnlGeneral.Dock = DockStyle.Fill;
            pnlApiService.Dock = DockStyle.Fill;
            pnlComponent.Dock = DockStyle.Fill;
            pnlMaterialDialog.Dock = DockStyle.Fill;
            pnlModel.Dock = DockStyle.Fill;
            pnlPage.Dock = DockStyle.Fill;
            pnlService.Dock = DockStyle.Fill;

            cmbStringQuote.SelectedValue = _settings.StringDelimiter;
            txtSelectorPrefix.Text = _settings.ComponentSelectorPrefix;
            cmbStylesheetFormat.SelectedValue = _settings.StylesheetFormat.ToString().ToLower();
            chkUnitTests.Checked = _settings.IncludeUnitTests;

            lstGroup.SelectedIndex = 0;

        }
    }
}
