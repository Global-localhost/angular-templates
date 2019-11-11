using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        private Utilities.Settings _settings = Utilities.Settings.LoadGlobal();

        private readonly IList<KeyValuePair<string, string>> _stringSeperators = new List<KeyValuePair<string, string>>()
        {
            new KeyValuePair<string, string>("'", "Single-Quote (')"),
            new KeyValuePair<string, string>("\"", "Double-Quote (\")")
        };

        private readonly IList<KeyValuePair<string, string>> _stylesheetFormat = new List<KeyValuePair<string, string>>()
        {
            new KeyValuePair<string, string>("Scss", "SASS" ),
            new KeyValuePair<string, string>("Less", "LESS" ),
            new KeyValuePair<string, string>("Css", "CSS" )
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
            cmbStylesheetFormat.SelectedValue = _settings.StylesheetFormat.ToString();
            chkUnitTests.Checked = _settings.IncludeUnitTests;
            chkApiSampleCode.Checked = _settings.ApiServiceSettings.IncludeSampleCode;

            lstGroup.SelectedIndex = (int)SettingGroup.General;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            // save to settings file
            _settings.StringDelimiter = cmbStringQuote.SelectedValue.ToString();
            _settings.ComponentSelectorPrefix = txtSelectorPrefix.Text;
            _settings.StylesheetFormat = (Utilities.Settings.StylesheetFormatType)Enum.Parse(typeof(Utilities.Settings.StylesheetFormatType), cmbStylesheetFormat.SelectedValue.ToString());
            _settings.IncludeUnitTests = chkUnitTests.Checked;
            _settings.ApiServiceSettings.IncludeSampleCode = chkApiSampleCode.Checked;

            _settings.SaveAsGlobal();
        }
    }
}
