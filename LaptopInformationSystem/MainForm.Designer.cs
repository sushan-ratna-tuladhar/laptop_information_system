namespace LaptopInformationSystem
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.grpLaptopInformationSystem = new System.Windows.Forms.GroupBox();
            this.btnShowDevice = new System.Windows.Forms.Button();
            this.btnAddDevice = new System.Windows.Forms.Button();
            this.lblActivivies = new System.Windows.Forms.Label();
            this.grpShowDevices = new System.Windows.Forms.GroupBox();
            this.btnPreviousPage = new System.Windows.Forms.Button();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.txtPageNo = new System.Windows.Forms.TextBox();
            this.lblPageNo = new System.Windows.Forms.Label();
            this.lblTotalValue = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnCancelGetDevices = new System.Windows.Forms.Button();
            this.btnGetDevices = new System.Windows.Forms.Button();
            this.dropdownPageSize = new System.Windows.Forms.ComboBox();
            this.lblPageSize = new System.Windows.Forms.Label();
            this.txtCodeSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.dataGridDevices = new System.Windows.Forms.DataGridView();
            this.grpAddDevice = new System.Windows.Forms.GroupBox();
            this.btnCancelSaveDevice = new System.Windows.Forms.Button();
            this.dateTimePickerPurchasedOn = new System.Windows.Forms.DateTimePicker();
            this.btnSaveDevice = new System.Windows.Forms.Button();
            this.dropdownType = new System.Windows.Forms.ComboBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.lblPurchasedOn = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblDeviceModel = new System.Windows.Forms.Label();
            this.grpLaptopInformationSystem.SuspendLayout();
            this.grpShowDevices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDevices)).BeginInit();
            this.grpAddDevice.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpLaptopInformationSystem
            // 
            this.grpLaptopInformationSystem.AutoSize = true;
            this.grpLaptopInformationSystem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpLaptopInformationSystem.Controls.Add(this.btnShowDevice);
            this.grpLaptopInformationSystem.Controls.Add(this.btnAddDevice);
            this.grpLaptopInformationSystem.Controls.Add(this.lblActivivies);
            this.grpLaptopInformationSystem.Controls.Add(this.grpShowDevices);
            this.grpLaptopInformationSystem.Controls.Add(this.grpAddDevice);
            this.grpLaptopInformationSystem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLaptopInformationSystem.Location = new System.Drawing.Point(0, 0);
            this.grpLaptopInformationSystem.Name = "grpLaptopInformationSystem";
            this.grpLaptopInformationSystem.Size = new System.Drawing.Size(1320, 701);
            this.grpLaptopInformationSystem.TabIndex = 0;
            this.grpLaptopInformationSystem.TabStop = false;
            this.grpLaptopInformationSystem.Text = "Laptop information system";
            this.grpLaptopInformationSystem.Enter += new System.EventHandler(this.grpLaptopInformationSystem_Enter);
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
            // grpShowDevices
            // 
            this.grpShowDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpShowDevices.AutoSize = true;
            this.grpShowDevices.Controls.Add(this.btnPreviousPage);
            this.grpShowDevices.Controls.Add(this.btnNextPage);
            this.grpShowDevices.Controls.Add(this.txtPageNo);
            this.grpShowDevices.Controls.Add(this.lblPageNo);
            this.grpShowDevices.Controls.Add(this.lblTotalValue);
            this.grpShowDevices.Controls.Add(this.lblTotal);
            this.grpShowDevices.Controls.Add(this.btnCancelGetDevices);
            this.grpShowDevices.Controls.Add(this.btnGetDevices);
            this.grpShowDevices.Controls.Add(this.dropdownPageSize);
            this.grpShowDevices.Controls.Add(this.lblPageSize);
            this.grpShowDevices.Controls.Add(this.txtCodeSearch);
            this.grpShowDevices.Controls.Add(this.lblSearch);
            this.grpShowDevices.Controls.Add(this.dataGridDevices);
            this.grpShowDevices.Location = new System.Drawing.Point(12, 141);
            this.grpShowDevices.Name = "grpShowDevices";
            this.grpShowDevices.Size = new System.Drawing.Size(1193, 443);
            this.grpShowDevices.TabIndex = 10;
            this.grpShowDevices.TabStop = false;
            this.grpShowDevices.Text = "Devices";
            this.grpShowDevices.Visible = false;
            // 
            // btnPreviousPage
            // 
            this.btnPreviousPage.Location = new System.Drawing.Point(604, 27);
            this.btnPreviousPage.Name = "btnPreviousPage";
            this.btnPreviousPage.Size = new System.Drawing.Size(75, 23);
            this.btnPreviousPage.TabIndex = 16;
            this.btnPreviousPage.Text = "Previous";
            this.btnPreviousPage.UseVisualStyleBackColor = true;
            this.btnPreviousPage.Click += new System.EventHandler(this.btnPreviousPage_Click);
            // 
            // btnNextPage
            // 
            this.btnNextPage.Location = new System.Drawing.Point(697, 27);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(75, 23);
            this.btnNextPage.TabIndex = 15;
            this.btnNextPage.Text = "Next";
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // txtPageNo
            // 
            this.txtPageNo.Location = new System.Drawing.Point(560, 28);
            this.txtPageNo.Name = "txtPageNo";
            this.txtPageNo.Size = new System.Drawing.Size(29, 22);
            this.txtPageNo.TabIndex = 14;
            this.txtPageNo.Text = "1";
            this.txtPageNo.TextChanged += new System.EventHandler(this.txtPageNo_TextChanged);
            this.txtPageNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPageNo_KeyPress);
            // 
            // lblPageNo
            // 
            this.lblPageNo.AutoSize = true;
            this.lblPageNo.Location = new System.Drawing.Point(505, 30);
            this.lblPageNo.Name = "lblPageNo";
            this.lblPageNo.Size = new System.Drawing.Size(49, 17);
            this.lblPageNo.TabIndex = 13;
            this.lblPageNo.Text = "Page: ";
            // 
            // lblTotalValue
            // 
            this.lblTotalValue.AutoSize = true;
            this.lblTotalValue.Location = new System.Drawing.Point(863, 30);
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.Size = new System.Drawing.Size(16, 17);
            this.lblTotalValue.TabIndex = 12;
            this.lblTotalValue.Text = "0";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(822, 30);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(48, 17);
            this.lblTotal.TabIndex = 11;
            this.lblTotal.Text = "Total: ";
            this.lblTotal.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnCancelGetDevices
            // 
            this.btnCancelGetDevices.Location = new System.Drawing.Point(1053, 23);
            this.btnCancelGetDevices.Name = "btnCancelGetDevices";
            this.btnCancelGetDevices.Size = new System.Drawing.Size(83, 33);
            this.btnCancelGetDevices.TabIndex = 9;
            this.btnCancelGetDevices.Text = "Cancel";
            this.btnCancelGetDevices.UseVisualStyleBackColor = true;
            this.btnCancelGetDevices.Click += new System.EventHandler(this.btnCancelGetDevices_Click);
            // 
            // btnGetDevices
            // 
            this.btnGetDevices.Location = new System.Drawing.Point(955, 23);
            this.btnGetDevices.Name = "btnGetDevices";
            this.btnGetDevices.Size = new System.Drawing.Size(83, 33);
            this.btnGetDevices.TabIndex = 8;
            this.btnGetDevices.Text = "Go";
            this.btnGetDevices.UseVisualStyleBackColor = true;
            this.btnGetDevices.Click += new System.EventHandler(this.btnGetDevices_Click);
            // 
            // dropdownPageSize
            // 
            this.dropdownPageSize.FormattingEnabled = true;
            this.dropdownPageSize.Items.AddRange(new object[] {
            "10",
            "20",
            "50",
            "100"});
            this.dropdownPageSize.Location = new System.Drawing.Point(406, 27);
            this.dropdownPageSize.Name = "dropdownPageSize";
            this.dropdownPageSize.Size = new System.Drawing.Size(53, 24);
            this.dropdownPageSize.TabIndex = 3;
            this.dropdownPageSize.Text = "20";
            this.dropdownPageSize.SelectedIndexChanged += new System.EventHandler(this.dropdownPageSize_SelectedIndexChanged);
            this.dropdownPageSize.TextUpdate += new System.EventHandler(this.dropdownPageSize_TextUpdate);
            this.dropdownPageSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dropdownPageSize_KeyPress);
            // 
            // lblPageSize
            // 
            this.lblPageSize.AutoSize = true;
            this.lblPageSize.Location = new System.Drawing.Point(326, 29);
            this.lblPageSize.Name = "lblPageSize";
            this.lblPageSize.Size = new System.Drawing.Size(74, 17);
            this.lblPageSize.TabIndex = 2;
            this.lblPageSize.Text = "Page size:";
            this.lblPageSize.Click += new System.EventHandler(this.lblPageSize_Click);
            // 
            // txtCodeSearch
            // 
            this.txtCodeSearch.Location = new System.Drawing.Point(63, 26);
            this.txtCodeSearch.Name = "txtCodeSearch";
            this.txtCodeSearch.Size = new System.Drawing.Size(257, 22);
            this.txtCodeSearch.TabIndex = 1;
            this.txtCodeSearch.TextChanged += new System.EventHandler(this.txtCodeSearch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(6, 27);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(61, 17);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search: ";
            // 
            // dataGridDevices
            // 
            this.dataGridDevices.AllowUserToAddRows = false;
            this.dataGridDevices.AllowUserToDeleteRows = false;
            this.dataGridDevices.AllowUserToOrderColumns = true;
            this.dataGridDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridDevices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridDevices.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDevices.Location = new System.Drawing.Point(9, 67);
            this.dataGridDevices.Name = "dataGridDevices";
            this.dataGridDevices.ReadOnly = true;
            this.dataGridDevices.RowTemplate.Height = 24;
            this.dataGridDevices.Size = new System.Drawing.Size(1159, 334);
            this.dataGridDevices.TabIndex = 10;
            this.dataGridDevices.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridDevices_CellContentClick_1);
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
            this.grpAddDevice.Location = new System.Drawing.Point(15, 141);
            this.grpAddDevice.Name = "grpAddDevice";
            this.grpAddDevice.Size = new System.Drawing.Size(1193, 446);
            this.grpAddDevice.TabIndex = 0;
            this.grpAddDevice.TabStop = false;
            this.grpAddDevice.Text = "Add Device";
            this.grpAddDevice.Visible = false;
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
            // dateTimePickerPurchasedOn
            // 
            this.dateTimePickerPurchasedOn.Location = new System.Drawing.Point(117, 135);
            this.dateTimePickerPurchasedOn.Name = "dateTimePickerPurchasedOn";
            this.dateTimePickerPurchasedOn.Size = new System.Drawing.Size(221, 22);
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
            this.dropdownType.Size = new System.Drawing.Size(221, 24);
            this.dropdownType.TabIndex = 6;
            this.dropdownType.SelectedIndexChanged += new System.EventHandler(this.dropdownLaptop_SelectedIndexChanged);
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(117, 64);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(221, 22);
            this.txtCode.TabIndex = 5;
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(117, 30);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(221, 22);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1320, 701);
            this.Controls.Add(this.grpLaptopInformationSystem);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Laptop Information System";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpLaptopInformationSystem.ResumeLayout(false);
            this.grpLaptopInformationSystem.PerformLayout();
            this.grpShowDevices.ResumeLayout(false);
            this.grpShowDevices.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDevices)).EndInit();
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
        private System.Windows.Forms.GroupBox grpShowDevices;
        private System.Windows.Forms.TextBox txtCodeSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Button btnCancelGetDevices;
        private System.Windows.Forms.Button btnGetDevices;
        private System.Windows.Forms.ComboBox dropdownPageSize;
        private System.Windows.Forms.Label lblPageSize;
        private System.Windows.Forms.GroupBox grpAddDevice;
        private System.Windows.Forms.Button btnCancelSaveDevice;
        private System.Windows.Forms.DateTimePicker dateTimePickerPurchasedOn;
        private System.Windows.Forms.Button btnSaveDevice;
        private System.Windows.Forms.ComboBox dropdownType;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label lblPurchasedOn;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblDeviceModel;
        private System.Windows.Forms.DataGridView dataGridDevices;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTotalValue;
        private System.Windows.Forms.Button btnPreviousPage;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.TextBox txtPageNo;
        private System.Windows.Forms.Label lblPageNo;
    }
}

