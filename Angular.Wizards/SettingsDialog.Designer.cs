namespace Angular.Wizards
{
    partial class SettingsDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstGroup = new System.Windows.Forms.ListBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.pnlGeneral = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbStringQuote = new System.Windows.Forms.ComboBox();
            this.txtSelectorPrefix = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbStylesheetFormat = new System.Windows.Forms.ComboBox();
            this.chkUnitTests = new System.Windows.Forms.CheckBox();
            this.pnlApiService = new System.Windows.Forms.Panel();
            this.chkApiSampleCode = new System.Windows.Forms.CheckBox();
            this.pnlComponent = new System.Windows.Forms.Panel();
            this.pnlMaterialDialog = new System.Windows.Forms.Panel();
            this.pnlModel = new System.Windows.Forms.Panel();
            this.pnlPage = new System.Windows.Forms.Panel();
            this.pnlService = new System.Windows.Forms.Panel();
            this.pnlContainer.SuspendLayout();
            this.pnlGeneral.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlApiService.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstGroup
            // 
            this.lstGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstGroup.FormattingEnabled = true;
            this.lstGroup.ItemHeight = 15;
            this.lstGroup.Items.AddRange(new object[] {
            "General",
            "API Service",
            "Component",
            "Material Dialog",
            "Model",
            "Page",
            "Service"});
            this.lstGroup.Location = new System.Drawing.Point(13, 13);
            this.lstGroup.Name = "lstGroup";
            this.lstGroup.Size = new System.Drawing.Size(143, 289);
            this.lstGroup.TabIndex = 0;
            this.lstGroup.SelectedIndexChanged += new System.EventHandler(this.LstGroup_SelectedIndexChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(444, 330);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(363, 330);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Save";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // pnlContainer
            // 
            this.pnlContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContainer.Controls.Add(this.pnlGeneral);
            this.pnlContainer.Controls.Add(this.pnlApiService);
            this.pnlContainer.Controls.Add(this.pnlComponent);
            this.pnlContainer.Controls.Add(this.pnlMaterialDialog);
            this.pnlContainer.Controls.Add(this.pnlModel);
            this.pnlContainer.Controls.Add(this.pnlPage);
            this.pnlContainer.Controls.Add(this.pnlService);
            this.pnlContainer.Location = new System.Drawing.Point(163, 13);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(356, 290);
            this.pnlContainer.TabIndex = 3;
            // 
            // pnlGeneral
            // 
            this.pnlGeneral.Controls.Add(this.tableLayoutPanel1);
            this.pnlGeneral.Location = new System.Drawing.Point(3, 3);
            this.pnlGeneral.Name = "pnlGeneral";
            this.pnlGeneral.Size = new System.Drawing.Size(179, 76);
            this.pnlGeneral.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbStringQuote, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtSelectorPrefix, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cmbStylesheetFormat, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.chkUnitTests, 1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(344, 156);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "String Quote Character:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Selector Prefix:";
            // 
            // cmbStringQuote
            // 
            this.cmbStringQuote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStringQuote.FormattingEnabled = true;
            this.cmbStringQuote.Items.AddRange(new object[] {
            "Single Quote (\')",
            "Double Quote (\")"});
            this.cmbStringQuote.Location = new System.Drawing.Point(175, 3);
            this.cmbStringQuote.Name = "cmbStringQuote";
            this.cmbStringQuote.Size = new System.Drawing.Size(166, 21);
            this.cmbStringQuote.TabIndex = 1;
            // 
            // txtSelectorPrefix
            // 
            this.txtSelectorPrefix.Location = new System.Drawing.Point(175, 42);
            this.txtSelectorPrefix.Name = "txtSelectorPrefix";
            this.txtSelectorPrefix.Size = new System.Drawing.Size(166, 20);
            this.txtSelectorPrefix.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Stylesheet Format:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Include Unit Tests";
            // 
            // cmbStylesheetFormat
            // 
            this.cmbStylesheetFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStylesheetFormat.FormattingEnabled = true;
            this.cmbStylesheetFormat.Location = new System.Drawing.Point(175, 81);
            this.cmbStylesheetFormat.Name = "cmbStylesheetFormat";
            this.cmbStylesheetFormat.Size = new System.Drawing.Size(166, 21);
            this.cmbStylesheetFormat.TabIndex = 6;
            // 
            // chkUnitTests
            // 
            this.chkUnitTests.AutoSize = true;
            this.chkUnitTests.Location = new System.Drawing.Point(175, 120);
            this.chkUnitTests.Name = "chkUnitTests";
            this.chkUnitTests.Size = new System.Drawing.Size(15, 14);
            this.chkUnitTests.TabIndex = 7;
            this.chkUnitTests.UseVisualStyleBackColor = true;
            // 
            // pnlApiService
            // 
            this.pnlApiService.Controls.Add(this.chkApiSampleCode);
            this.pnlApiService.Location = new System.Drawing.Point(188, 3);
            this.pnlApiService.Name = "pnlApiService";
            this.pnlApiService.Size = new System.Drawing.Size(165, 76);
            this.pnlApiService.TabIndex = 1;
            // 
            // chkApiSampleCode
            // 
            this.chkApiSampleCode.AutoSize = true;
            this.chkApiSampleCode.Location = new System.Drawing.Point(10, 29);
            this.chkApiSampleCode.Name = "chkApiSampleCode";
            this.chkApiSampleCode.Size = new System.Drawing.Size(127, 17);
            this.chkApiSampleCode.TabIndex = 0;
            this.chkApiSampleCode.Text = "Include Sample Code";
            this.chkApiSampleCode.UseVisualStyleBackColor = true;
            // 
            // pnlComponent
            // 
            this.pnlComponent.Location = new System.Drawing.Point(3, 85);
            this.pnlComponent.Name = "pnlComponent";
            this.pnlComponent.Size = new System.Drawing.Size(179, 59);
            this.pnlComponent.TabIndex = 1;
            // 
            // pnlMaterialDialog
            // 
            this.pnlMaterialDialog.Location = new System.Drawing.Point(188, 85);
            this.pnlMaterialDialog.Name = "pnlMaterialDialog";
            this.pnlMaterialDialog.Size = new System.Drawing.Size(165, 59);
            this.pnlMaterialDialog.TabIndex = 2;
            // 
            // pnlModel
            // 
            this.pnlModel.Location = new System.Drawing.Point(3, 150);
            this.pnlModel.Name = "pnlModel";
            this.pnlModel.Size = new System.Drawing.Size(179, 45);
            this.pnlModel.TabIndex = 2;
            // 
            // pnlPage
            // 
            this.pnlPage.Location = new System.Drawing.Point(188, 150);
            this.pnlPage.Name = "pnlPage";
            this.pnlPage.Size = new System.Drawing.Size(165, 45);
            this.pnlPage.TabIndex = 2;
            // 
            // pnlService
            // 
            this.pnlService.Location = new System.Drawing.Point(3, 201);
            this.pnlService.Name = "pnlService";
            this.pnlService.Size = new System.Drawing.Size(179, 52);
            this.pnlService.TabIndex = 2;
            // 
            // SettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(531, 365);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lstGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsDialog_Load);
            this.pnlContainer.ResumeLayout(false);
            this.pnlGeneral.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pnlApiService.ResumeLayout(false);
            this.pnlApiService.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstGroup;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Panel pnlGeneral;
        private System.Windows.Forms.Panel pnlApiService;
        private System.Windows.Forms.Panel pnlMaterialDialog;
        private System.Windows.Forms.Panel pnlModel;
        private System.Windows.Forms.Panel pnlPage;
        private System.Windows.Forms.Panel pnlService;
        private System.Windows.Forms.Panel pnlComponent;
        private System.Windows.Forms.ComboBox cmbStringQuote;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkApiSampleCode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSelectorPrefix;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbStylesheetFormat;
        private System.Windows.Forms.CheckBox chkUnitTests;
    }
}