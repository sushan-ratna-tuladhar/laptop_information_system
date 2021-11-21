namespace LaptopInformationSystem
{
    partial class Form1
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
            this.grpLaptopInformationSystem = new System.Windows.Forms.GroupBox();
            this.panelAddDevice = new System.Windows.Forms.Panel();
            this.grpAddDevice = new System.Windows.Forms.GroupBox();
            this.dateTimePickerPurchasedOn = new System.Windows.Forms.DateTimePicker();
            this.btnSaveDevice = new System.Windows.Forms.Button();
            this.dropdownType = new System.Windows.Forms.ComboBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.lblPurchasedOn = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblDeviceModel = new System.Windows.Forms.Label();
            this.btnShowDevice = new System.Windows.Forms.Button();
            this.btnAddDevice = new System.Windows.Forms.Button();
            this.lblActivivies = new System.Windows.Forms.Label();
            this.btnCancelSaveDevice = new System.Windows.Forms.Button();
            this.grpLaptopInformationSystem.SuspendLayout();
            this.panelAddDevice.SuspendLayout();
            this.grpAddDevice.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpLaptopInformationSystem
            // 
            this.grpLaptopInformationSystem.AutoSize = true;
            this.grpLaptopInformationSystem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpLaptopInformationSystem.Controls.Add(this.panelAddDevice);
            this.grpLaptopInformationSystem.Controls.Add(this.btnShowDevice);
            this.grpLaptopInformationSystem.Controls.Add(this.btnAddDevice);
            this.grpLaptopInformationSystem.Controls.Add(this.lblActivivies);
            this.grpLaptopInformationSystem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLaptopInformationSystem.Location = new System.Drawing.Point(0, 0);
            this.grpLaptopInformationSystem.Name = "grpLaptopInformationSystem";
            this.grpLaptopInformationSystem.Size = new System.Drawing.Size(961, 600);
            this.grpLaptopInformationSystem.TabIndex = 0;
            this.grpLaptopInformationSystem.TabStop = false;
            this.grpLaptopInformationSystem.Text = "Laptop information system";
            this.grpLaptopInformationSystem.Enter += new System.EventHandler(this.grpLaptopInformationSystem_Enter);
            // 
            // panelAddDevice
            // 
            this.panelAddDevice.Controls.Add(this.grpAddDevice);
            this.panelAddDevice.Location = new System.Drawing.Point(15, 132);
            this.panelAddDevice.Name = "panelAddDevice";
            this.panelAddDevice.Size = new System.Drawing.Size(1199, 437);
            this.panelAddDevice.TabIndex = 5;
            // 
            // grpAddDevice
            // 
            this.grpAddDevice.AutoSize = true;
            this.grpAddDevice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.grpAddDevice.Controls.Add(this.btnCancelSaveDevice);
            this.grpAddDevice.Controls.Add(this.dateTimePickerPurchasedOn);
            this.grpAddDevice.Controls.Add(this.btnSaveDevice);
            this.grpAddDevice.Controls.Add(this.dropdownType);
            this.grpAddDevice.Controls.Add(this.txtCode);
            this.grpAddDevice.Controls.Add(this.txtModel);
            this.grpAddDevice.Controls.Add(this.lblPurchasedOn);
            this.grpAddDevice.Controls.Add(this.lblType);
            this.grpAddDevice.Controls.Add(this.lblCode);
            this.grpAddDevice.Controls.Add(this.lblDeviceModel);
            this.grpAddDevice.Location = new System.Drawing.Point(3, 3);
            this.grpAddDevice.Name = "grpAddDevice";
            this.grpAddDevice.Size = new System.Drawing.Size(1193, 446);
            this.grpAddDevice.TabIndex = 0;
            this.grpAddDevice.TabStop = false;
            this.grpAddDevice.Text = "Add Device";
            this.grpAddDevice.Visible = false;
            // 
            // dateTimePickerPurchasedOn
            // 
            this.dateTimePickerPurchasedOn.Location = new System.Drawing.Point(117, 135);
            this.dateTimePickerPurchasedOn.Name = "dateTimePickerPurchasedOn";
            this.dateTimePickerPurchasedOn.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerPurchasedOn.TabIndex = 8;
            // 
            // btnSaveDevice
            // 
            this.btnSaveDevice.Location = new System.Drawing.Point(18, 392);
            this.btnSaveDevice.Name = "btnSaveDevice";
            this.btnSaveDevice.Size = new System.Drawing.Size(83, 33);
            this.btnSaveDevice.TabIndex = 7;
            this.btnSaveDevice.Text = "Save";
            this.btnSaveDevice.UseVisualStyleBackColor = true;
            this.btnSaveDevice.Click += new System.EventHandler(this.btnSaveDevice_Click);
            // 
            // dropdownType
            // 
            this.dropdownType.FormattingEnabled = true;
            this.dropdownType.Items.AddRange(new object[] {
            "Laptop"});
            this.dropdownType.Location = new System.Drawing.Point(117, 100);
            this.dropdownType.Name = "dropdownType";
            this.dropdownType.Size = new System.Drawing.Size(200, 24);
            this.dropdownType.TabIndex = 6;
            this.dropdownType.SelectedIndexChanged += new System.EventHandler(this.dropdownLaptop_SelectedIndexChanged);
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(117, 64);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(200, 22);
            this.txtCode.TabIndex = 5;
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(117, 30);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(200, 22);
            this.txtModel.TabIndex = 4;
            // 
            // lblPurchasedOn
            // 
            this.lblPurchasedOn.AutoSize = true;
            this.lblPurchasedOn.Location = new System.Drawing.Point(15, 135);
            this.lblPurchasedOn.Name = "lblPurchasedOn";
            this.lblPurchasedOn.Size = new System.Drawing.Size(100, 17);
            this.lblPurchasedOn.TabIndex = 3;
            this.lblPurchasedOn.Text = "Purchased on:";
            this.lblPurchasedOn.Click += new System.EventHandler(this.lblPurchasedOn_Click);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(15, 100);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(44, 17);
            this.lblType.TabIndex = 2;
            this.lblType.Text = "Type:";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(16, 67);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(45, 17);
            this.lblCode.TabIndex = 1;
            this.lblCode.Text = "Code:";
            this.lblCode.Click += new System.EventHandler(this.lblCode_Click);
            // 
            // lblDeviceModel
            // 
            this.lblDeviceModel.AutoSize = true;
            this.lblDeviceModel.Location = new System.Drawing.Point(15, 35);
            this.lblDeviceModel.Name = "lblDeviceModel";
            this.lblDeviceModel.Size = new System.Drawing.Size(50, 17);
            this.lblDeviceModel.TabIndex = 0;
            this.lblDeviceModel.Text = "Model:";
            // 
            // btnShowDevice
            // 
            this.btnShowDevice.AutoSize = true;
            this.btnShowDevice.Location = new System.Drawing.Point(383, 69);
            this.btnShowDevice.Name = "btnShowDevice";
            this.btnShowDevice.Size = new System.Drawing.Size(338, 36);
            this.btnShowDevice.TabIndex = 4;
            this.btnShowDevice.Text = "Show Device";
            this.btnShowDevice.UseVisualStyleBackColor = true;
            this.btnShowDevice.Click += new System.EventHandler(this.btnShowDevice_Click);
            // 
            // btnAddDevice
            // 
            this.btnAddDevice.AutoSize = true;
            this.btnAddDevice.Location = new System.Drawing.Point(15, 69);
            this.btnAddDevice.Name = "btnAddDevice";
            this.btnAddDevice.Size = new System.Drawing.Size(338, 36);
            this.btnAddDevice.TabIndex = 1;
            this.btnAddDevice.Text = "Add Device";
            this.btnAddDevice.UseVisualStyleBackColor = true;
            this.btnAddDevice.Click += new System.EventHandler(this.btnAddDevice_Click);
            // 
            // lblActivivies
            // 
            this.lblActivivies.AutoSize = true;
            this.lblActivivies.Location = new System.Drawing.Point(12, 44);
            this.lblActivivies.Name = "lblActivivies";
            this.lblActivivies.Size = new System.Drawing.Size(67, 17);
            this.lblActivivies.TabIndex = 0;
            this.lblActivivies.Text = "Activities:";
            this.lblActivivies.Click += new System.EventHandler(this.lblActivities_Click);
            // 
            // btnCancelSaveDevice
            // 
            this.btnCancelSaveDevice.Location = new System.Drawing.Point(117, 392);
            this.btnCancelSaveDevice.Name = "btnCancelSaveDevice";
            this.btnCancelSaveDevice.Size = new System.Drawing.Size(83, 33);
            this.btnCancelSaveDevice.TabIndex = 9;
            this.btnCancelSaveDevice.Text = "Cancel";
            this.btnCancelSaveDevice.UseVisualStyleBackColor = true;
            this.btnCancelSaveDevice.Click += new System.EventHandler(this.btnCancelSaveDevice_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 600);
            this.Controls.Add(this.grpLaptopInformationSystem);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpLaptopInformationSystem.ResumeLayout(false);
            this.grpLaptopInformationSystem.PerformLayout();
            this.panelAddDevice.ResumeLayout(false);
            this.panelAddDevice.PerformLayout();
            this.grpAddDevice.ResumeLayout(false);
            this.grpAddDevice.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpLaptopInformationSystem;
        private System.Windows.Forms.Label lblActivivies;
        private System.Windows.Forms.Button btnShowDevice;
        private System.Windows.Forms.Button btnAddDevice;
        private System.Windows.Forms.Panel panelAddDevice;
        private System.Windows.Forms.GroupBox grpAddDevice;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label lblPurchasedOn;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblDeviceModel;
        private System.Windows.Forms.ComboBox dropdownType;
        private System.Windows.Forms.Button btnSaveDevice;
        private System.Windows.Forms.DateTimePicker dateTimePickerPurchasedOn;
        private System.Windows.Forms.Button btnCancelSaveDevice;
    }
}

