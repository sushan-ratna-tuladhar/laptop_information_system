namespace LaptopInformationSystem
{
    partial class DeviceEditForm
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
            this.lblCode = new System.Windows.Forms.Label();
            this.txtCodeEdit = new System.Windows.Forms.TextBox();
            this.txtModelEdit = new System.Windows.Forms.TextBox();
            this.lblModel = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.dropdownTypeEdit = new System.Windows.Forms.ComboBox();
            this.lblPurchasedOn = new System.Windows.Forms.Label();
            this.dateTimePickerPurchasedOnEdit = new System.Windows.Forms.DateTimePicker();
            this.btnCancelEdit = new System.Windows.Forms.Button();
            this.btnSaveEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(12, 29);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(49, 17);
            this.lblCode.TabIndex = 0;
            this.lblCode.Text = "Code: ";
            // 
            // txtCodeEdit
            // 
            this.txtCodeEdit.Location = new System.Drawing.Point(126, 26);
            this.txtCodeEdit.Name = "txtCodeEdit";
            this.txtCodeEdit.Size = new System.Drawing.Size(235, 22);
            this.txtCodeEdit.TabIndex = 1;
            this.txtCodeEdit.TextChanged += new System.EventHandler(this.txtCodeEdit_TextChanged);
            // 
            // txtModelEdit
            // 
            this.txtModelEdit.Location = new System.Drawing.Point(126, 71);
            this.txtModelEdit.Name = "txtModelEdit";
            this.txtModelEdit.Size = new System.Drawing.Size(235, 22);
            this.txtModelEdit.TabIndex = 3;
            this.txtModelEdit.TextChanged += new System.EventHandler(this.txtModelEdit_TextChanged);
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Location = new System.Drawing.Point(12, 71);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(50, 17);
            this.lblModel.TabIndex = 2;
            this.lblModel.Text = "Model:";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(12, 115);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(44, 17);
            this.lblType.TabIndex = 4;
            this.lblType.Text = "Type:";
            // 
            // dropdownTypeEdit
            // 
            this.dropdownTypeEdit.FormattingEnabled = true;
            this.dropdownTypeEdit.Items.AddRange(new object[] {
            "Laptop"});
            this.dropdownTypeEdit.Location = new System.Drawing.Point(126, 112);
            this.dropdownTypeEdit.Name = "dropdownTypeEdit";
            this.dropdownTypeEdit.Size = new System.Drawing.Size(235, 24);
            this.dropdownTypeEdit.TabIndex = 5;
            // 
            // lblPurchasedOn
            // 
            this.lblPurchasedOn.AutoSize = true;
            this.lblPurchasedOn.Location = new System.Drawing.Point(12, 157);
            this.lblPurchasedOn.Name = "lblPurchasedOn";
            this.lblPurchasedOn.Size = new System.Drawing.Size(100, 17);
            this.lblPurchasedOn.TabIndex = 6;
            this.lblPurchasedOn.Text = "Purchased on:";
            // 
            // dateTimePickerPurchasedOnEdit
            // 
            this.dateTimePickerPurchasedOnEdit.Location = new System.Drawing.Point(126, 157);
            this.dateTimePickerPurchasedOnEdit.Name = "dateTimePickerPurchasedOnEdit";
            this.dateTimePickerPurchasedOnEdit.Size = new System.Drawing.Size(235, 22);
            this.dateTimePickerPurchasedOnEdit.TabIndex = 7;
            // 
            // btnCancelEdit
            // 
            this.btnCancelEdit.Location = new System.Drawing.Point(264, 212);
            this.btnCancelEdit.Name = "btnCancelEdit";
            this.btnCancelEdit.Size = new System.Drawing.Size(97, 33);
            this.btnCancelEdit.TabIndex = 8;
            this.btnCancelEdit.Text = "Cancel";
            this.btnCancelEdit.UseVisualStyleBackColor = true;
            this.btnCancelEdit.Click += new System.EventHandler(this.btnCancelEdit_Click);
            // 
            // btnSaveEdit
            // 
            this.btnSaveEdit.Location = new System.Drawing.Point(148, 212);
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
            this.ClientSize = new System.Drawing.Size(380, 319);
            this.Controls.Add(this.btnSaveEdit);
            this.Controls.Add(this.btnCancelEdit);
            this.Controls.Add(this.dateTimePickerPurchasedOnEdit);
            this.Controls.Add(this.lblPurchasedOn);
            this.Controls.Add(this.dropdownTypeEdit);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.txtModelEdit);
            this.Controls.Add(this.lblModel);
            this.Controls.Add(this.txtCodeEdit);
            this.Controls.Add(this.lblCode);
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

        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblPurchasedOn;
        private System.Windows.Forms.Button btnCancelEdit;
        private System.Windows.Forms.Button btnSaveEdit;
        public System.Windows.Forms.TextBox txtCodeEdit;
        public System.Windows.Forms.TextBox txtModelEdit;
        public System.Windows.Forms.ComboBox dropdownTypeEdit;
        public System.Windows.Forms.DateTimePicker dateTimePickerPurchasedOnEdit;
    }
}