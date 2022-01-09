namespace LaptopInformationSystem
{
    partial class DeviceRemarksForm
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
            this.lblUpdateRemarks = new System.Windows.Forms.Label();
            this.txtUpdateRemarksEdit = new System.Windows.Forms.TextBox();
            this.txtRepairRemarksEdit = new System.Windows.Forms.TextBox();
            this.lblRepairRemarks = new System.Windows.Forms.Label();
            this.btnCancelEdit = new System.Windows.Forms.Button();
            this.btnSaveEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblUpdateRemarks
            // 
            this.lblUpdateRemarks.AutoSize = true;
            this.lblUpdateRemarks.Location = new System.Drawing.Point(12, 29);
            this.lblUpdateRemarks.Name = "lblUpdateRemarks";
            this.lblUpdateRemarks.Size = new System.Drawing.Size(117, 17);
            this.lblUpdateRemarks.TabIndex = 0;
            this.lblUpdateRemarks.Text = "Update remarks: ";
            // 
            // txtUpdateRemarksEdit
            // 
            this.txtUpdateRemarksEdit.Location = new System.Drawing.Point(126, 26);
            this.txtUpdateRemarksEdit.Name = "txtUpdateRemarksEdit";
            this.txtUpdateRemarksEdit.Size = new System.Drawing.Size(235, 22);
            this.txtUpdateRemarksEdit.TabIndex = 1;
            this.txtUpdateRemarksEdit.TextChanged += new System.EventHandler(this.txtCodeEdit_TextChanged);
            // 
            // txtRepairRemarksEdit
            // 
            this.txtRepairRemarksEdit.Location = new System.Drawing.Point(126, 71);
            this.txtRepairRemarksEdit.Name = "txtRepairRemarksEdit";
            this.txtRepairRemarksEdit.Size = new System.Drawing.Size(235, 22);
            this.txtRepairRemarksEdit.TabIndex = 3;
            this.txtRepairRemarksEdit.TextChanged += new System.EventHandler(this.txtModelEdit_TextChanged);
            // 
            // lblRepairRemarks
            // 
            this.lblRepairRemarks.AutoSize = true;
            this.lblRepairRemarks.Location = new System.Drawing.Point(12, 71);
            this.lblRepairRemarks.Name = "lblRepairRemarks";
            this.lblRepairRemarks.Size = new System.Drawing.Size(109, 17);
            this.lblRepairRemarks.TabIndex = 2;
            this.lblRepairRemarks.Text = "Repair remarks:";
            // 
            // btnCancelEdit
            // 
            this.btnCancelEdit.Location = new System.Drawing.Point(271, 121);
            this.btnCancelEdit.Name = "btnCancelEdit";
            this.btnCancelEdit.Size = new System.Drawing.Size(97, 33);
            this.btnCancelEdit.TabIndex = 8;
            this.btnCancelEdit.Text = "Cancel";
            this.btnCancelEdit.UseVisualStyleBackColor = true;
            this.btnCancelEdit.Click += new System.EventHandler(this.btnCancelEdit_Click);
            // 
            // btnSaveEdit
            // 
            this.btnSaveEdit.Location = new System.Drawing.Point(168, 121);
            this.btnSaveEdit.Name = "btnSaveEdit";
            this.btnSaveEdit.Size = new System.Drawing.Size(97, 33);
            this.btnSaveEdit.TabIndex = 9;
            this.btnSaveEdit.Text = "Save";
            this.btnSaveEdit.UseVisualStyleBackColor = true;
            this.btnSaveEdit.Click += new System.EventHandler(this.btnSaveEdit_Click);
            // 
            // DeviceEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 164);
            this.Controls.Add(this.btnSaveEdit);
            this.Controls.Add(this.btnCancelEdit);
            this.Controls.Add(this.txtRepairRemarksEdit);
            this.Controls.Add(this.lblRepairRemarks);
            this.Controls.Add(this.txtUpdateRemarksEdit);
            this.Controls.Add(this.lblUpdateRemarks);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DeviceEditForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit";
            this.Load += new System.EventHandler(this.DeviceEditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUpdateRemarks;
        private System.Windows.Forms.Label lblRepairRemarks;
        private System.Windows.Forms.Button btnCancelEdit;
        private System.Windows.Forms.Button btnSaveEdit;
        public System.Windows.Forms.TextBox txtUpdateRemarksEdit;
        public System.Windows.Forms.TextBox txtRepairRemarksEdit;
    }
}