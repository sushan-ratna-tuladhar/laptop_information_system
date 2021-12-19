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
            this.btnAddModel = new System.Windows.Forms.Button();
            this.btnAddBrand = new System.Windows.Forms.Button();
            this.btnShowDevice = new System.Windows.Forms.Button();
            this.btnAddDevice = new System.Windows.Forms.Button();
            this.lblActivivies = new System.Windows.Forms.Label();
            this.grpAddComponents = new System.Windows.Forms.GroupBox();
            this.dataGridCommon = new System.Windows.Forms.DataGridView();
            this.dropdownAddModelBrand = new System.Windows.Forms.ComboBox();
            this.lblAddModelBrand = new System.Windows.Forms.Label();
            this.txtAddBrandName = new System.Windows.Forms.TextBox();
            this.lblAddBrandModelName = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtAddModelName = new System.Windows.Forms.TextBox();
            this.grpShowDevices = new System.Windows.Forms.GroupBox();
            this.dropdownGetDevicesModel = new System.Windows.Forms.ComboBox();
            this.dropdownGetDevicesBrand = new System.Windows.Forms.ComboBox();
            this.lblModel = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.lblLoading = new System.Windows.Forms.Label();
            this.grpLaptopInformationSystem.SuspendLayout();
            this.grpAddComponents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCommon)).BeginInit();
            this.grpShowDevices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDevices)).BeginInit();
            this.SuspendLayout();
            // 
            // grpLaptopInformationSystem
            // 
            this.grpLaptopInformationSystem.AutoSize = true;
            this.grpLaptopInformationSystem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpLaptopInformationSystem.Controls.Add(this.lblLoading);
            this.grpLaptopInformationSystem.Controls.Add(this.btnReport);
            this.grpLaptopInformationSystem.Controls.Add(this.btnAddModel);
            this.grpLaptopInformationSystem.Controls.Add(this.btnAddBrand);
            this.grpLaptopInformationSystem.Controls.Add(this.btnShowDevice);
            this.grpLaptopInformationSystem.Controls.Add(this.btnAddDevice);
            this.grpLaptopInformationSystem.Controls.Add(this.lblActivivies);
            this.grpLaptopInformationSystem.Controls.Add(this.grpAddComponents);
            this.grpLaptopInformationSystem.Controls.Add(this.grpShowDevices);
            this.grpLaptopInformationSystem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLaptopInformationSystem.Location = new System.Drawing.Point(0, 0);
            this.grpLaptopInformationSystem.Name = "grpLaptopInformationSystem";
            this.grpLaptopInformationSystem.Size = new System.Drawing.Size(1320, 701);
            this.grpLaptopInformationSystem.TabIndex = 0;
            this.grpLaptopInformationSystem.TabStop = false;
            this.grpLaptopInformationSystem.Text = "Laptop information system";
            this.grpLaptopInformationSystem.Enter += new System.EventHandler(this.grpLaptopInformationSystem_Enter);
            // 
            // btnAddModel
            // 
            this.btnAddModel.AutoSize = true;
            this.btnAddModel.Location = new System.Drawing.Point(674, 69);
            this.btnAddModel.Name = "btnAddModel";
            this.btnAddModel.Size = new System.Drawing.Size(200, 36);
            this.btnAddModel.TabIndex = 12;
            this.btnAddModel.Text = "Add Model";
            this.btnAddModel.UseVisualStyleBackColor = true;
            this.btnAddModel.Click += new System.EventHandler(this.btnAddModel_Click);
            // 
            // btnAddBrand
            // 
            this.btnAddBrand.AutoSize = true;
            this.btnAddBrand.Location = new System.Drawing.Point(454, 69);
            this.btnAddBrand.Name = "btnAddBrand";
            this.btnAddBrand.Size = new System.Drawing.Size(200, 36);
            this.btnAddBrand.TabIndex = 11;
            this.btnAddBrand.Text = "Add Brand";
            this.btnAddBrand.UseVisualStyleBackColor = true;
            this.btnAddBrand.Click += new System.EventHandler(this.btnAddBrand_Click);
            // 
            // btnShowDevice
            // 
            this.btnShowDevice.AutoSize = true;
            this.btnShowDevice.Location = new System.Drawing.Point(236, 69);
            this.btnShowDevice.Name = "btnShowDevice";
            this.btnShowDevice.Size = new System.Drawing.Size(200, 36);
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
            this.btnAddDevice.Size = new System.Drawing.Size(200, 36);
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
            // grpAddComponents
            // 
            this.grpAddComponents.AutoSize = true;
            this.grpAddComponents.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.grpAddComponents.Controls.Add(this.dropdownAddModelBrand);
            this.grpAddComponents.Controls.Add(this.lblAddModelBrand);
            this.grpAddComponents.Controls.Add(this.txtAddBrandName);
            this.grpAddComponents.Controls.Add(this.lblAddBrandModelName);
            this.grpAddComponents.Controls.Add(this.btnCancel);
            this.grpAddComponents.Controls.Add(this.btnSave);
            this.grpAddComponents.Controls.Add(this.txtAddModelName);
            this.grpAddComponents.Controls.Add(this.dataGridCommon);
            this.grpAddComponents.Location = new System.Drawing.Point(12, 141);
            this.grpAddComponents.Name = "grpAddComponents";
            this.grpAddComponents.Size = new System.Drawing.Size(1198, 446);
            this.grpAddComponents.TabIndex = 0;
            this.grpAddComponents.TabStop = false;
            this.grpAddComponents.Text = "Add Device";
            this.grpAddComponents.Visible = false;
            // 
            // dataGridCommon
            // 
            this.dataGridCommon.AllowUserToAddRows = false;
            this.dataGridCommon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCommon.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridCommon.Location = new System.Drawing.Point(18, 47);
            this.dataGridCommon.Name = "dataGridCommon";
            this.dataGridCommon.RowTemplate.Height = 24;
            this.dataGridCommon.Size = new System.Drawing.Size(1155, 340);
            this.dataGridCommon.TabIndex = 15;
            this.dataGridCommon.Visible = false;
            this.dataGridCommon.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridAddDevices_CellContentClick);
            // 
            // dropdownAddModelBrand
            // 
            this.dropdownAddModelBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dropdownAddModelBrand.FormattingEnabled = true;
            this.dropdownAddModelBrand.Location = new System.Drawing.Point(66, 86);
            this.dropdownAddModelBrand.Name = "dropdownAddModelBrand";
            this.dropdownAddModelBrand.Size = new System.Drawing.Size(121, 24);
            this.dropdownAddModelBrand.TabIndex = 14;
            this.dropdownAddModelBrand.Visible = false;
            // 
            // lblAddModelBrand
            // 
            this.lblAddModelBrand.AutoSize = true;
            this.lblAddModelBrand.Location = new System.Drawing.Point(11, 89);
            this.lblAddModelBrand.Name = "lblAddModelBrand";
            this.lblAddModelBrand.Size = new System.Drawing.Size(50, 17);
            this.lblAddModelBrand.TabIndex = 13;
            this.lblAddModelBrand.Text = "Brand:";
            this.lblAddModelBrand.Visible = false;
            // 
            // txtAddBrandName
            // 
            this.txtAddBrandName.Location = new System.Drawing.Point(66, 44);
            this.txtAddBrandName.Name = "txtAddBrandName";
            this.txtAddBrandName.Size = new System.Drawing.Size(121, 22);
            this.txtAddBrandName.TabIndex = 11;
            this.txtAddBrandName.Visible = false;
            // 
            // lblAddBrandModelName
            // 
            this.lblAddBrandModelName.AutoSize = true;
            this.lblAddBrandModelName.Location = new System.Drawing.Point(11, 47);
            this.lblAddBrandModelName.Name = "lblAddBrandModelName";
            this.lblAddBrandModelName.Size = new System.Drawing.Size(49, 17);
            this.lblAddBrandModelName.TabIndex = 10;
            this.lblAddBrandModelName.Text = "Name:";
            this.lblAddBrandModelName.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(117, 392);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 33);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancelSaveDevice_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(18, 392);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 33);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtAddModelName
            // 
            this.txtAddModelName.Location = new System.Drawing.Point(66, 44);
            this.txtAddModelName.Name = "txtAddModelName";
            this.txtAddModelName.Size = new System.Drawing.Size(121, 22);
            this.txtAddModelName.TabIndex = 12;
            this.txtAddModelName.Visible = false;
            // 
            // grpShowDevices
            // 
            this.grpShowDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpShowDevices.AutoSize = true;
            this.grpShowDevices.Controls.Add(this.button1);
            this.grpShowDevices.Controls.Add(this.dropdownGetDevicesModel);
            this.grpShowDevices.Controls.Add(this.dropdownGetDevicesBrand);
            this.grpShowDevices.Controls.Add(this.lblModel);
            this.grpShowDevices.Controls.Add(this.lblBrand);
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
            this.grpShowDevices.Size = new System.Drawing.Size(1201, 2339);
            this.grpShowDevices.TabIndex = 10;
            this.grpShowDevices.TabStop = false;
            this.grpShowDevices.Text = "Devices";
            this.grpShowDevices.Visible = false;
            // 
            // dropdownGetDevicesModel
            // 
            this.dropdownGetDevicesModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dropdownGetDevicesModel.FormattingEnabled = true;
            this.dropdownGetDevicesModel.Location = new System.Drawing.Point(758, 30);
            this.dropdownGetDevicesModel.Name = "dropdownGetDevicesModel";
            this.dropdownGetDevicesModel.Size = new System.Drawing.Size(132, 24);
            this.dropdownGetDevicesModel.TabIndex = 20;
            // 
            // dropdownGetDevicesBrand
            // 
            this.dropdownGetDevicesBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dropdownGetDevicesBrand.FormattingEnabled = true;
            this.dropdownGetDevicesBrand.Location = new System.Drawing.Point(532, 30);
            this.dropdownGetDevicesBrand.Name = "dropdownGetDevicesBrand";
            this.dropdownGetDevicesBrand.Size = new System.Drawing.Size(121, 24);
            this.dropdownGetDevicesBrand.TabIndex = 19;
            this.dropdownGetDevicesBrand.SelectionChangeCommitted += new System.EventHandler(this.dropdownGetDevicesBrand_SelectedChangeCommitted);
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Location = new System.Drawing.Point(702, 33);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(50, 17);
            this.lblModel.TabIndex = 18;
            this.lblModel.Text = "Model:";
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Location = new System.Drawing.Point(480, 33);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(50, 17);
            this.lblBrand.TabIndex = 17;
            this.lblBrand.Text = "Brand:";
            // 
            // btnPreviousPage
            // 
            this.btnPreviousPage.AutoSize = true;
            this.btnPreviousPage.Location = new System.Drawing.Point(384, 449);
            this.btnPreviousPage.Name = "btnPreviousPage";
            this.btnPreviousPage.Size = new System.Drawing.Size(75, 27);
            this.btnPreviousPage.TabIndex = 16;
            this.btnPreviousPage.Text = "Previous";
            this.btnPreviousPage.UseVisualStyleBackColor = true;
            this.btnPreviousPage.Click += new System.EventHandler(this.btnPreviousPage_Click);
            // 
            // btnNextPage
            // 
            this.btnNextPage.AutoSize = true;
            this.btnNextPage.Location = new System.Drawing.Point(578, 449);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(75, 27);
            this.btnNextPage.TabIndex = 15;
            this.btnNextPage.Text = "Next";
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // txtPageNo
            // 
            this.txtPageNo.Location = new System.Drawing.Point(521, 449);
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
            this.lblPageNo.Location = new System.Drawing.Point(477, 449);
            this.lblPageNo.Name = "lblPageNo";
            this.lblPageNo.Size = new System.Drawing.Size(49, 17);
            this.lblPageNo.TabIndex = 13;
            this.lblPageNo.Text = "Page: ";
            // 
            // lblTotalValue
            // 
            this.lblTotalValue.AutoSize = true;
            this.lblTotalValue.Location = new System.Drawing.Point(736, 449);
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.Size = new System.Drawing.Size(16, 17);
            this.lblTotalValue.TabIndex = 12;
            this.lblTotalValue.Text = "0";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(693, 449);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(48, 17);
            this.lblTotal.TabIndex = 11;
            this.lblTotal.Text = "Total: ";
            this.lblTotal.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnCancelGetDevices
            // 
            this.btnCancelGetDevices.Location = new System.Drawing.Point(1053, 25);
            this.btnCancelGetDevices.Name = "btnCancelGetDevices";
            this.btnCancelGetDevices.Size = new System.Drawing.Size(83, 33);
            this.btnCancelGetDevices.TabIndex = 9;
            this.btnCancelGetDevices.Text = "Cancel";
            this.btnCancelGetDevices.UseVisualStyleBackColor = true;
            this.btnCancelGetDevices.Click += new System.EventHandler(this.btnCancelGetDevices_Click);
            // 
            // btnGetDevices
            // 
            this.btnGetDevices.Location = new System.Drawing.Point(955, 25);
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
            this.dropdownPageSize.Location = new System.Drawing.Point(406, 30);
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
            this.lblPageSize.Location = new System.Drawing.Point(326, 33);
            this.lblPageSize.Name = "lblPageSize";
            this.lblPageSize.Size = new System.Drawing.Size(74, 17);
            this.lblPageSize.TabIndex = 2;
            this.lblPageSize.Text = "Page size:";
            this.lblPageSize.Click += new System.EventHandler(this.lblPageSize_Click);
            // 
            // txtCodeSearch
            // 
            this.txtCodeSearch.Location = new System.Drawing.Point(63, 30);
            this.txtCodeSearch.Name = "txtCodeSearch";
            this.txtCodeSearch.Size = new System.Drawing.Size(257, 22);
            this.txtCodeSearch.TabIndex = 1;
            this.txtCodeSearch.TextChanged += new System.EventHandler(this.txtCodeSearch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(6, 33);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(61, 17);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search: ";
            this.lblSearch.Click += new System.EventHandler(this.lblSearch_Click);
            // 
            // dataGridDevices
            // 
            this.dataGridDevices.AllowUserToAddRows = false;
            this.dataGridDevices.AllowUserToDeleteRows = false;
            this.dataGridDevices.AllowUserToOrderColumns = true;
            this.dataGridDevices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridDevices.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDevices.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridDevices.Location = new System.Drawing.Point(9, 67);
            this.dataGridDevices.Name = "dataGridDevices";
            this.dataGridDevices.RowTemplate.Height = 24;
            this.dataGridDevices.Size = new System.Drawing.Size(1164, 346);
            this.dataGridDevices.TabIndex = 10;
            this.dataGridDevices.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridDevices_CellContentClick_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(559, 1153);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 33);
            this.button1.TabIndex = 21;
            this.button1.Text = "Go";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnReport
            // 
            this.btnReport.AutoSize = true;
            this.btnReport.Location = new System.Drawing.Point(896, 69);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(200, 36);
            this.btnReport.TabIndex = 17;
            this.btnReport.Text = "Stock report";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // lblLoading
            // 
            this.lblLoading.AutoSize = true;
            this.lblLoading.Location = new System.Drawing.Point(541, 18);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(71, 17);
            this.lblLoading.TabIndex = 18;
            this.lblLoading.Text = "Loading...";
            this.lblLoading.Visible = false;
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
            this.grpAddComponents.ResumeLayout(false);
            this.grpAddComponents.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCommon)).EndInit();
            this.grpShowDevices.ResumeLayout(false);
            this.grpShowDevices.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDevices)).EndInit();
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
        private System.Windows.Forms.GroupBox grpAddComponents;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dataGridDevices;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTotalValue;
        private System.Windows.Forms.Button btnPreviousPage;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.TextBox txtPageNo;
        private System.Windows.Forms.Label lblPageNo;
        private System.Windows.Forms.Button btnAddModel;
        private System.Windows.Forms.Button btnAddBrand;
        private System.Windows.Forms.TextBox txtAddBrandName;
        private System.Windows.Forms.Label lblAddBrandModelName;
        private System.Windows.Forms.TextBox txtAddModelName;
        private System.Windows.Forms.Label lblAddModelBrand;
        private System.Windows.Forms.ComboBox dropdownAddModelBrand;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.ComboBox dropdownGetDevicesModel;
        private System.Windows.Forms.ComboBox dropdownGetDevicesBrand;
        private System.Windows.Forms.DataGridView dataGridCommon;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblLoading;
    }
}

