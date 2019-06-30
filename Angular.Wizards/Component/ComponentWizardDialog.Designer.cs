namespace Angular.Wizards.Component
{
    partial class ComponentWizardDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lstApiServices = new System.Windows.Forms.CheckedListBox();
            this.lstModels = new System.Windows.Forms.CheckedListBox();
            this.lstServices = new System.Windows.Forms.CheckedListBox();
            this.lstDialogs = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select one or more API services to consume:";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(492, 333);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAdd.Location = new System.Drawing.Point(411, 333);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add Page";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(297, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(255, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Select one or more model class to utilize in this page:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(240, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Select one or more non-API services to consume:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(297, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(237, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Select one or more dialogs to create in this page:";
            // 
            // lstApiServices
            // 
            this.lstApiServices.FormattingEnabled = true;
            this.lstApiServices.Location = new System.Drawing.Point(15, 50);
            this.lstApiServices.Name = "lstApiServices";
            this.lstApiServices.Size = new System.Drawing.Size(267, 94);
            this.lstApiServices.TabIndex = 1;
            // 
            // lstModels
            // 
            this.lstModels.FormattingEnabled = true;
            this.lstModels.Location = new System.Drawing.Point(300, 50);
            this.lstModels.Name = "lstModels";
            this.lstModels.Size = new System.Drawing.Size(267, 94);
            this.lstModels.TabIndex = 11;
            // 
            // lstServices
            // 
            this.lstServices.FormattingEnabled = true;
            this.lstServices.Location = new System.Drawing.Point(15, 190);
            this.lstServices.Name = "lstServices";
            this.lstServices.Size = new System.Drawing.Size(267, 94);
            this.lstServices.TabIndex = 12;
            // 
            // lstDialogs
            // 
            this.lstDialogs.FormattingEnabled = true;
            this.lstDialogs.Location = new System.Drawing.Point(300, 190);
            this.lstDialogs.Name = "lstDialogs";
            this.lstDialogs.Size = new System.Drawing.Size(267, 94);
            this.lstDialogs.TabIndex = 13;
            // 
            // PageWizardDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(579, 368);
            this.Controls.Add(this.lstDialogs);
            this.Controls.Add(this.lstServices);
            this.Controls.Add(this.lstModels);
            this.Controls.Add(this.lstApiServices);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PageWizardDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Angular Page Component Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox lstApiServices;
        private System.Windows.Forms.CheckedListBox lstModels;
        private System.Windows.Forms.CheckedListBox lstServices;
        private System.Windows.Forms.CheckedListBox lstDialogs;
    }
}