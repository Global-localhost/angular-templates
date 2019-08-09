namespace Angular.Wizards
{
    partial class CommonOptionsDialog
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
            this.lstDialogs = new System.Windows.Forms.CheckedListBox();
            this.lstServices = new System.Windows.Forms.CheckedListBox();
            this.lstModels = new System.Windows.Forms.CheckedListBox();
            this.lstApiServices = new System.Windows.Forms.CheckedListBox();
            this.lblDialogs = new System.Windows.Forms.Label();
            this.lblServices = new System.Windows.Forms.Label();
            this.lblModels = new System.Windows.Forms.Label();
            this.lblApiServices = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstDialogs
            // 
            this.lstDialogs.CheckOnClick = true;
            this.lstDialogs.FormattingEnabled = true;
            this.lstDialogs.Location = new System.Drawing.Point(300, 166);
            this.lstDialogs.Name = "lstDialogs";
            this.lstDialogs.Size = new System.Drawing.Size(267, 94);
            this.lstDialogs.TabIndex = 21;
            // 
            // lstServices
            // 
            this.lstServices.CheckOnClick = true;
            this.lstServices.FormattingEnabled = true;
            this.lstServices.Location = new System.Drawing.Point(15, 166);
            this.lstServices.Name = "lstServices";
            this.lstServices.Size = new System.Drawing.Size(267, 94);
            this.lstServices.TabIndex = 20;
            // 
            // lstModels
            // 
            this.lstModels.CheckOnClick = true;
            this.lstModels.FormattingEnabled = true;
            this.lstModels.Location = new System.Drawing.Point(300, 26);
            this.lstModels.Name = "lstModels";
            this.lstModels.Size = new System.Drawing.Size(267, 94);
            this.lstModels.TabIndex = 19;
            // 
            // lstApiServices
            // 
            this.lstApiServices.CheckOnClick = true;
            this.lstApiServices.FormattingEnabled = true;
            this.lstApiServices.Location = new System.Drawing.Point(15, 26);
            this.lstApiServices.Name = "lstApiServices";
            this.lstApiServices.Size = new System.Drawing.Size(267, 94);
            this.lstApiServices.TabIndex = 14;
            // 
            // lblDialogs
            // 
            this.lblDialogs.AutoSize = true;
            this.lblDialogs.Location = new System.Drawing.Point(297, 150);
            this.lblDialogs.Name = "lblDialogs";
            this.lblDialogs.Size = new System.Drawing.Size(180, 13);
            this.lblDialogs.TabIndex = 18;
            this.lblDialogs.Text = "Select one or more dialogs to create:";
            // 
            // lblServices
            // 
            this.lblServices.AutoSize = true;
            this.lblServices.Location = new System.Drawing.Point(12, 150);
            this.lblServices.Name = "lblServices";
            this.lblServices.Size = new System.Drawing.Size(240, 13);
            this.lblServices.TabIndex = 17;
            this.lblServices.Text = "Select one or more non-API services to consume:";
            // 
            // lblModels
            // 
            this.lblModels.AutoSize = true;
            this.lblModels.Location = new System.Drawing.Point(297, 10);
            this.lblModels.Name = "lblModels";
            this.lblModels.Size = new System.Drawing.Size(209, 13);
            this.lblModels.TabIndex = 16;
            this.lblModels.Text = "Select one or more model classes to utilize:";
            // 
            // lblApiServices
            // 
            this.lblApiServices.AutoSize = true;
            this.lblApiServices.Location = new System.Drawing.Point(12, 9);
            this.lblApiServices.Name = "lblApiServices";
            this.lblApiServices.Size = new System.Drawing.Size(219, 13);
            this.lblApiServices.TabIndex = 15;
            this.lblApiServices.Text = "Select one or more API services to consume:";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAdd.Location = new System.Drawing.Point(411, 285);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 23;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(492, 285);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSettings.Location = new System.Drawing.Point(15, 285);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(75, 23);
            this.btnSettings.TabIndex = 24;
            this.btnSettings.Text = "Settings...";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
            // 
            // CommonOptionsDialog
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(579, 320);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lstDialogs);
            this.Controls.Add(this.lstServices);
            this.Controls.Add(this.lstModels);
            this.Controls.Add(this.lstApiServices);
            this.Controls.Add(this.lblDialogs);
            this.Controls.Add(this.lblServices);
            this.Controls.Add(this.lblModels);
            this.Controls.Add(this.lblApiServices);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CommonOptionsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox lstDialogs;
        private System.Windows.Forms.CheckedListBox lstServices;
        private System.Windows.Forms.CheckedListBox lstModels;
        private System.Windows.Forms.CheckedListBox lstApiServices;
        private System.Windows.Forms.Label lblDialogs;
        private System.Windows.Forms.Label lblServices;
        private System.Windows.Forms.Label lblModels;
        private System.Windows.Forms.Label lblApiServices;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSettings;
    }
}