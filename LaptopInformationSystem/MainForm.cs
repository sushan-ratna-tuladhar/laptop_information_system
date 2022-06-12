using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaptopInformationSystem
{
    public partial class MainForm : Form
    {
        private Helpers.DbHelper db = new Helpers.DbHelper();
        private DataTable devices;
        private DataTable brands;
        private DataTable models;
        private DataTable report;
        private DataTable buyers;
        public DateTimePicker newDateTime;
        private DeviceRemarksForm deviceRemarksForm;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread Initialize = new Thread(delegate () {

                this.Initialize();

                // Change the status of the buttons inside the TypingThread
                // This won't throw an exception anymore !
                if (this.btnShowDevice.InvokeRequired)
                {
                    this.btnShowDevice.Invoke(new MethodInvoker(delegate
                    {
                        if(this.btnShowDevice.Enabled == false)
                        {
                            this.btnShowDevice.Enabled = true;
                            this.btnAddDevice.Enabled = true;
                            this.btnAddBrand.Enabled = true;
                            this.btnAddModel.Enabled = true;
                            this.btnSoldOut.Enabled = true;
                            if (dataGridCommon.ReadOnly == false)
                            {
                                dataGridCommon.ReadOnly = true;
                            }

                            grpAddComponents.Show();
                            grpAddComponents.Text = "Report";

                            this.dataGridCommon.Columns.Clear();
                            this.dataGridCommon.DataSource = this.report;
                            if (!dataGridCommon.Visible)
                            {
                                dataGridCommon.Show();
                            }
                            this.dataGridCommon.Columns["No."].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                            this.dataGridCommon.Columns["Brand"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                            this.dataGridCommon.Columns["Model"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            this.dataGridCommon.Columns["Device count"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;


                            this.btnSave.Hide();
                            this.btnCancel.Hide();
                            this.btnModels.Hide();
                            this.checkBoxShowAllStock.Show();

                            this.lblLoading.Hide();
                        }
                    }));
                }
            });

            this.btnShowDevice.Enabled = false;
            this.btnAddDevice.Enabled = false;
            this.btnAddBrand.Enabled = false;
            this.btnAddModel.Enabled = false;
            this.btnReport.Enabled = false;
            this.btnSoldOut.Enabled = false;
            this.lblLoading.Show();

            Initialize.Start();

        }

        private void btnShowDevice_Click(object sender, EventArgs e)
        {
            dataGridCommon.Show();
            txtAddBrandName.Hide();
            lblAddBrandModelName.Hide();
            lblAddModelBrand.Hide();
            dropdownAddModelBrand.Hide();
            txtAddModelName.Hide();
            dataGridCommon.Hide();
            this.btnModels.Hide();
            this.checkBoxShowAllStock.Hide();

            grpAddComponents.Hide();
            btnSoldOutSave.Hide();
            grpShowDevices.Show();

            lblBrand.Show();
            dropdownGetDevicesBrand.Show();
            lblModel.Show();
            dropdownGetDevicesModel.Show();
            btnGetDevices.Show();
            lblPageSize.Show();
            dropdownPageSize.Show();
            lblSearch.Show();
            txtCodeSearch.Show();
            lblPageSize.Show();
            dropdownPageSize.Show();
            btnNextPage.Show();
            btnPreviousPage.Show();
            lblPageNo.Show();
            txtPageNo.Show();

            btnSoldOutSave.Hide();
            lblSoldTo.Hide();
            dropDownSoldTo.Hide();

            lblPurchasedOn.Show();
            dateTimePickerPurchasedOn.Show();

            btnShowDevice.Enabled = false;

            if (btnAddModel.Enabled == false)
            {
                btnAddModel.Enabled = true;
            }
            if (btnAddDevice.Enabled == false)
            {
                btnAddDevice.Enabled = true;
            }
            if (btnAddBrand.Enabled == false)
            {
                btnAddBrand.Enabled = true;
            }
            if (btnReport.Enabled == false)
            {
                btnReport.Enabled = true;
            }
            if (btnSoldOut.Enabled == false)
            {
                btnSoldOut.Enabled = true;
            }

            try
            {
                dropdownGetDevicesBrand.DisplayMember = "Brand";
                dropdownGetDevicesBrand.ValueMember = "ID";
                dropdownGetDevicesBrand.DataSource = this.brands;
                dropdownGetDevicesBrand.SelectedItem = null;

                this.txtCodeSearch.Text = "";
                this.txtPageNo.Text = "1";
                this.dropdownPageSize.Text = "20";
                this.dateTimePickerOuter.Value = DateTime.Parse("2020-01-01");
                this.dateTimePickerPurchasedOn.Value = DateTime.Parse("2020-01-01");

                this.showData(1, 20, "", 0, "", null, null);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error on GetDevices : " + ex.Message + ", stack: " + ex.StackTrace);
                MessageBox.Show("Something went wrong", "Notice", MessageBoxButtons.OK);
            }

            
        }

        private void btnAddDevice_Click(object sender, EventArgs e)
        {
            grpShowDevices.Hide();
            dataGridCommon.Show();
            txtAddBrandName.Hide();
            lblAddBrandModelName.Hide();
            lblAddModelBrand.Hide();
            dropdownAddModelBrand.Hide();
            txtAddModelName.Hide();
            this.btnModels.Hide();
            this.checkBoxShowAllStock.Hide();

            grpAddComponents.Show();
            grpAddComponents.Text = "Add Devices";
            btnAddDevice.Enabled = false;

            if (btnAddModel.Enabled == false)
            {
                btnAddModel.Enabled = true;
            }
            if (btnShowDevice.Enabled == false)
            {
                btnShowDevice.Enabled = true;
            }
            if (btnAddBrand.Enabled == false)
            {
                btnAddBrand.Enabled = true;
            }
            if (btnReport.Enabled == false)
            {
                btnReport.Enabled = true;
            }
            if (dataGridCommon.ReadOnly == false)
            {
                dataGridCommon.ReadOnly = true;
            }
            if (btnSoldOut.Enabled == false)
            {
                btnSoldOut.Enabled = true;
            }

            this.btnSave.Show();
            this.btnCancel.Show();
            
            this.dataGridCommon.Columns.Clear();
            dataGridCommon.DataSource = null;

            DataGridViewComboBoxColumn modelsComboBox = new DataGridViewComboBoxColumn();
            {
                modelsComboBox.DataSource = this.db.GetModels(0);
                modelsComboBox.Name = "Model";
                modelsComboBox.DisplayMember = "Model";
                modelsComboBox.ValueMember = "ID";
                modelsComboBox.ValueType = typeof(string);
                dataGridCommon.Columns.Add(modelsComboBox);
            }

            this.dataGridCommon.Columns.Add("SN", "S/N");
            this.dataGridCommon.Columns["SN"].ValueType = typeof(string);
            this.dataGridCommon.Columns.Add("Type", "Type");
            this.dataGridCommon.Columns["Type"].ValueType = typeof(string);
            this.dataGridCommon.Columns.Add("PurchasedFrom", "Purchased from");
            this.dataGridCommon.Columns["PurchasedFrom"].ValueType = typeof(string);

            CalendarColumn purchasedOn = new CalendarColumn();
            {
                purchasedOn.Name = "Purchased on";
                purchasedOn.ValueType = typeof(string);
                dataGridCommon.Columns.Add(purchasedOn);
            }

            this.dataGridCommon.Columns.Add("InvoiceNumber", "Invoice number");
            this.dataGridCommon.Columns["InvoiceNumber"].ValueType = typeof(string);
            this.dataGridCommon.Columns.Add("SoldTo", "Sold to");
            this.dataGridCommon.Columns["SoldTo"].ValueType = typeof(string);

            CalendarColumn soldOn = new CalendarColumn();
            {
                soldOn.Name = "Sold on";
                soldOn.ValueType = typeof(string);
                dataGridCommon.Columns.Add(soldOn);
            }

            DataGridViewButtonColumn newDevice = new DataGridViewButtonColumn();
            {
                newDevice.Name = "btnAddDeviceNew";
                newDevice.HeaderText = "Add";
                newDevice.Text = "+";
                newDevice.UseColumnTextForButtonValue = true;
                newDevice.DefaultCellStyle.NullValue = "+";
                newDevice.ValueType = typeof(string);
                this.dataGridCommon.Columns.Add(newDevice);
            }

            DataGridViewButtonColumn removeDevice = new DataGridViewButtonColumn();
            {
                removeDevice.Name = "btnRemoveDeviceNew";
                removeDevice.HeaderText = "Remove";
                removeDevice.Text = "-";
                removeDevice.UseColumnTextForButtonValue = true;
                removeDevice.DefaultCellStyle.NullValue = "-";
                removeDevice.ValueType = typeof(string);
                this.dataGridCommon.Columns.Add(removeDevice);
            }

            this.dataGridCommon.Columns["Model"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridCommon.Columns["SN"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridCommon.Columns["Type"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridCommon.Columns["PurchasedFrom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridCommon.Columns["Purchased on"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridCommon.Columns["InvoiceNumber"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridCommon.Columns["SoldTo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridCommon.Columns["Sold on"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridCommon.Columns["btnAddDeviceNew"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridCommon.Columns["btnRemoveDeviceNew"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            if (dataGridCommon.ReadOnly == true)
            {
                dataGridCommon.ReadOnly = false;
            }

            this.dataGridCommon.Rows.Add();

        }

        private void lblActivities_Click(object sender, EventArgs e)
        {

        }

        private void grpLaptopInformationSystem_Enter(object sender, EventArgs e)
        {

        }

        private void lblCode_Click(object sender, EventArgs e)
        {

        }

        private void dropdownLaptop_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelSaveDevice_Click(object sender, EventArgs e)
        {
            grpAddComponents.Hide();
            if(btnAddDevice.Enabled == false)
            {
                btnAddDevice.Enabled = true;
            }
        }

        private void btnSaveDevice_Click(object sender, EventArgs e)
        {

        }

        private void lblPurchasedOn_Click(object sender, EventArgs e)
        {

        }

        private void panelshowDevices_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCancelGetDevices_Click(object sender, EventArgs e)
        {
            grpShowDevices.Hide();
            if(btnShowDevice.Enabled == false)
            {
                btnShowDevice.Enabled = true;
            }
        }

        private void dropdownPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtPageNo.Text = "1";
            int value;
            if (int.TryParse(dropdownPageSize.Text, out value))
            {
                if (value < 1)
                    dropdownPageSize.Text = "1";
            }
        }

        private void dropdownPageSize_TextUpdate(object sender, EventArgs e)
        {
            this.txtPageNo.Text = "1";
            int value;
            if (int.TryParse(dropdownPageSize.Text, out value))
            {
                if (value < 1)
                    dropdownPageSize.Text = "1";
            }
        }

        private void btnGetDevices_Click(object sender, EventArgs e)
        {
            try
            {
                string search = this.txtCodeSearch.Text.Trim();

                int pageNumber = 1;
                int pageSize = Convert.ToInt32(dropdownPageSize.Text.Trim());
                int modelId = Convert.ToInt32(dropdownGetDevicesModel.SelectedValue);

                DateTime? soldOnDate = null, purchasedOnDate = null;

                if (this.dateTimePickerOuter.Value != DateTime.Parse("1990-01-01"))
                {
                    soldOnDate = this.dateTimePickerOuter.Value;
                }

                if (this.dateTimePickerPurchasedOn.Value != DateTime.Parse("1990-01-01"))
                {
                    purchasedOnDate = this.dateTimePickerPurchasedOn.Value;
                }

                this.showData(pageNumber, pageSize, search, modelId, "", soldOnDate, purchasedOnDate);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error on GetDevices : " + ex.Message + ", stack: " + ex.StackTrace);
                MessageBox.Show("Something went wrong", "Notice", MessageBoxButtons.OK);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.btnNextPage.Enabled == false)
                {
                    this.btnNextPage.Enabled = true;
                }

                int pageNumber = Convert.ToInt32(txtPageNo.Text.Trim());
                int pageSize = Convert.ToInt32(dropdownPageSize.Text.Trim());
                string search = this.txtCodeSearch.Text.Trim();
                DateTime? soldOnDate = this.dateTimePickerOuter.Value, purchasedOnDate = this.dateTimePickerPurchasedOn.Value;
                int modelId = Convert.ToInt32(dropdownGetDevicesModel.SelectedValue);

                this.showData(pageNumber, pageSize, search, modelId, "previousPage", soldOnDate, purchasedOnDate);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error on GetDevices/PreviousPage : " + ex.Message + ", stack: " + ex.StackTrace);
                MessageBox.Show("Something went wrong", "Notice", MessageBoxButtons.OK);
            }
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.btnPreviousPage.Enabled == false)
                {
                    this.btnPreviousPage.Enabled = true;
                }

                int pageNumber = Convert.ToInt32(txtPageNo.Text.Trim());
                int pageSize = Convert.ToInt32(dropdownPageSize.Text.Trim());
                string search = this.txtCodeSearch.Text.Trim();
                DateTime? soldOnDate = this.dateTimePickerOuter.Value, purchasedOnDate = this.dateTimePickerPurchasedOn.Value;
                int modelId = Convert.ToInt32(dropdownGetDevicesModel.SelectedValue);

                this.showData(pageNumber, pageSize, search, modelId, "nextPage", soldOnDate, purchasedOnDate);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error on GetDevices/NextPage : " + ex.Message + ", stack: " + ex.StackTrace);
                MessageBox.Show("Something went wrong", "Notice", MessageBoxButtons.OK);
            }
        }

        private void dataGridDevices_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // when save button is clicked
            if (this.dataGridDevices.Columns[e.ColumnIndex].Name == "btnSave")
            {
                int id = Convert.ToInt32(dataGridDevices.Rows[e.RowIndex].Cells["ID"].Value);
                int modelId = Convert.ToInt32(dataGridDevices.Rows[e.RowIndex].Cells["ModelId"].Value);
                string serialNo = dataGridDevices.Rows[e.RowIndex].Cells["S/N"].Value != null ? dataGridDevices.Rows[e.RowIndex].Cells["S/N"].Value.ToString() : "";
                string type = dataGridDevices.Rows[e.RowIndex].Cells["Type"].Value != null ? dataGridDevices.Rows[e.RowIndex].Cells["Type"].Value.ToString() : "";
                string purchasedFrom = dataGridDevices.Rows[e.RowIndex].Cells["Purchased from"].Value != null ? dataGridDevices.Rows[e.RowIndex].Cells["Purchased from"].Value.ToString() : "";
                string purchasedOn = dataGridDevices.Rows[e.RowIndex].Cells["Purchased on"].Value != null ? dataGridDevices.Rows[e.RowIndex].Cells["Purchased on"].Value.ToString() : null;
                if (purchasedOn != null)
                {
                    try
                    {
                        purchasedOn = DateTime.Parse(purchasedOn).ToString("yyyy-MM-dd");
                    }
                    catch
                    {
                        purchasedOn = null;
                    }
                }
                string invoiceNumber = dataGridDevices.Rows[e.RowIndex].Cells["Invoice number"].Value != null ? dataGridDevices.Rows[e.RowIndex].Cells["Invoice number"].Value.ToString() : "";
                string soldTo = dataGridDevices.Rows[e.RowIndex].Cells["Sold to"].Value != null ? dataGridDevices.Rows[e.RowIndex].Cells["Sold to"].Value.ToString() : "";
                string soldOn = dataGridDevices.Rows[e.RowIndex].Cells["Sold on"].Value != null ? dataGridDevices.Rows[e.RowIndex].Cells["Sold on"].Value.ToString() : null;
                if (soldOn != null)
                {
                    try
                    {
                        soldOn = DateTime.Parse(soldOn).ToString("yyyy-MM-dd");
                    }
                    catch
                    {
                        soldOn = null;
                    }
                }
                string updateRemarks = dataGridDevices.Rows[e.RowIndex].Cells["UpdateRemarks"].Value != null ? dataGridDevices.Rows[e.RowIndex].Cells["UpdateRemarks"].Value.ToString() : null;
                string repairRemarks = dataGridDevices.Rows[e.RowIndex].Cells["RepairRemarks"].Value != null ? dataGridDevices.Rows[e.RowIndex].Cells["RepairRemarks"].Value.ToString() : null;


                string result = this.db.UpdateDevice(id, serialNo, modelId, type, purchasedOn, purchasedFrom, soldOn, soldTo, invoiceNumber, updateRemarks, repairRemarks);

                DialogResult dialogResult = MessageBox.Show(result, "Update", MessageBoxButtons.OK);
            }

            //when delete button is clicked
            if (this.dataGridDevices.Columns[e.ColumnIndex].Name == "btnDelete")
            {
                string serialNo = dataGridDevices.Rows[e.RowIndex].Cells["S/N"].Value != null ? dataGridDevices.Rows[e.RowIndex].Cells["S/N"].Value.ToString() : "";

                DialogResult dialogResult = MessageBox.Show("Delete device " + serialNo + "?", "Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string result = this.db.DeleteDevice(serialNo);
                }

                DateTime? soldOnDate = this.dateTimePickerOuter.Value, purchasedOnDate = this.dateTimePickerPurchasedOn.Value;
                int pageNumber = Convert.ToInt32(txtPageNo.Text.Trim());
                int pageSize = Convert.ToInt32(dropdownPageSize.Text.Trim());
                string search = this.txtCodeSearch.Text.Trim();
                int modelId = Convert.ToInt32(dropdownGetDevicesModel.SelectedValue);

                this.showData(pageNumber, pageSize, search, modelId, "", soldOnDate, purchasedOnDate);
            }

            //when remarks button is clicked
            if (this.dataGridDevices.Columns[e.ColumnIndex].Name == "btnRemarks")
            {
                // display on the new form.
                int id = Convert.ToInt32(dataGridDevices.Rows[e.RowIndex].Cells["ID"].Value);
                string updateRemarks = Convert.ToString(dataGridDevices.Rows[e.RowIndex].Cells["UpdateRemarks"].Value);
                string repairRemarks = Convert.ToString(dataGridDevices.Rows[e.RowIndex].Cells["RepairRemarks"].Value);

                this.deviceRemarksForm = new DeviceRemarksForm(updateRemarks, repairRemarks);
                EventArgs args = new EventArgs();

                deviceRemarksForm.onBtnSaveClick += (_sender, _e) => remarks_onBtnSaveClick(sender, e, id);

                deviceRemarksForm.ShowDialog();
            }

            //for soldout
            if (this.dataGridDevices.Columns[e.ColumnIndex].Name == "btnAddDeviceNew")
            {
                int count = this.dataGridDevices.Rows.Count - 1;
                this.dataGridDevices.Rows.Add("");
            }

            //for soldout
            if (this.dataGridDevices.Columns[e.ColumnIndex].Name == "btnRemoveDeviceNew")
            {
                if (dataGridDevices.Rows.Count > 1)
                {
                    this.dataGridDevices.Rows.RemoveAt(dataGridDevices.CurrentRow.Index);
                }
            }
        }

        private void dataGridAddDevices_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataGridCommon.Columns[e.ColumnIndex].Name == "btnAddDeviceNew")
            {
                int count = this.dataGridCommon.Rows.Count - 1;
                this.dataGridCommon.Rows.Add(
                    dataGridCommon.Rows[count].Cells[0].Value,
                    "",
                    dataGridCommon.Rows[count].Cells[2].Value,
                    dataGridCommon.Rows[count].Cells[3].Value,
                    dataGridCommon.Rows[count].Cells[4].Value,
                    dataGridCommon.Rows[count].Cells[5].Value,
                    "",
                    "",
                    "",
                    ""
                );
            }

            //when delete button is clicked
            if (this.dataGridCommon.Columns[e.ColumnIndex].Name == "btnRemoveDeviceNew")
            {
                if(dataGridCommon.Rows.Count > 1)
                {
                    this.dataGridCommon.Rows.RemoveAt(dataGridCommon.CurrentRow.Index);
                }
            }

            //when delete model button is clicked
            if (this.dataGridCommon.Columns[e.ColumnIndex].Name == "btnModelDelete")
            {
                string model = dataGridCommon.Rows[e.RowIndex].Cells["Model"].Value != null ? dataGridCommon.Rows[e.RowIndex].Cells["Model"].Value.ToString() : "";
                int modelId = Convert.ToInt32(dataGridCommon.Rows[e.RowIndex].Cells["ID"].Value);
                int deviceCount = Convert.ToInt32(this.db.GetTotalDevices("", modelId, null, null));

                DialogResult dialogResult = MessageBox.Show(model + " has " + deviceCount + " devices, are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string result = this.db.DeleteModel(modelId);
                    DialogResult dialogResultDeleted = MessageBox.Show(result, "Notice", MessageBoxButtons.OK);

                    if (dialogResultDeleted == DialogResult.OK)
                    {
                        this.dataGridCommon.Columns.Clear();
                        this.dataGridCommon.DataSource = this.db.GetModels(0, false);

                        this.dataGridCommon.Columns["No."].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        this.dataGridCommon.Columns["Model"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        this.dataGridCommon.Columns["ID"].Visible = false;

                        DataGridViewButtonColumn button = new DataGridViewButtonColumn();
                        {
                            button.Name = "btnModelDelete";
                            button.HeaderText = "";
                            button.Text = "Delete";
                            button.UseColumnTextForButtonValue = true;
                            this.dataGridCommon.Columns.Add(button);
                        }

                        if (!dataGridCommon.Visible)
                        {
                            dataGridCommon.Show();
                        }
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                }
            }

        }

        private void txtCodeSearch_TextChanged(object sender, EventArgs e)
        {
            this.txtPageNo.Text = "1";
        }

        private void lblPageSize_Click(object sender, EventArgs e)
        {

        }

        private void dropdownPageSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPageNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void txtPageNo_TextChanged(object sender, EventArgs e)
        {
            int value;
            int maxPage = 0;
            int total = Convert.ToInt32(lblTotalValue.Text);
            int pageSize = Convert.ToInt32(dropdownPageSize.Text);

            if(total % pageSize == 0)
            {
                maxPage = (total / pageSize);
            } else
            {
                maxPage = (total / pageSize) + 1;
            }
            
            if (int.TryParse(txtPageNo.Text, out value))
            {
                if (value > maxPage)
                    txtPageNo.Text = Convert.ToString(maxPage);
                else if (value < 1)
                    txtPageNo.Text = "1";
            }
        }

        private void btnAddBrand_Click(object sender, EventArgs e)
        {
            grpShowDevices.Hide();
            txtAddModelName.Hide();
            lblAddModelBrand.Hide();
            dropdownAddModelBrand.Hide();
            dataGridCommon.Hide();
            lblAddBrandModelName.Show();
            this.btnSave.Show();
            this.btnCancel.Show();
            this.btnModels.Hide();
            this.checkBoxShowAllStock.Hide();

            grpAddComponents.Show();
            lblAddBrandModelName.Show();
            txtAddBrandName.Show();

            grpAddComponents.Text = "Add Brand";
            btnAddBrand.Enabled = false;

            if (btnShowDevice.Enabled == false)
            {
                btnShowDevice.Enabled = true;
            }
            if (btnAddDevice.Enabled == false)
            {
                btnAddDevice.Enabled = true;
            }
            if (btnAddModel.Enabled == false)
            {
                btnAddModel.Enabled = true;
            }
            if (btnReport.Enabled == false)
            {
                btnReport.Enabled = true;
            }
            if (btnSoldOut.Enabled == false)
            {
                btnSoldOut.Enabled = true;
            }
        }

        private void btnAddModel_Click(object sender, EventArgs e)
        {
            grpShowDevices.Hide();
            txtAddBrandName.Hide();
            dataGridCommon.Hide();
            lblAddBrandModelName.Show();
            btnReport.Enabled = true;
            this.btnSave.Show();
            this.btnCancel.Show();
            this.btnModels.Show();
            this.checkBoxShowAllStock.Hide();

            grpAddComponents.Show();
            lblAddBrandModelName.Show();
            txtAddModelName.Show();
            lblAddModelBrand.Show();
            
            grpAddComponents.Text = "Add Model";
            btnAddModel.Enabled = false;

            DataTable brands = this.brands;

            dropdownAddModelBrand.DisplayMember = "Brand";
            dropdownAddModelBrand.ValueMember = "ID";
            dropdownAddModelBrand.DataSource = brands;

            dropdownAddModelBrand.Show();

            if (btnShowDevice.Enabled == false)
            {
                btnShowDevice.Enabled = true;
            }
            if (btnAddDevice.Enabled == false)
            {
                btnAddDevice.Enabled = true;
            }
            if (btnAddBrand.Enabled == false)
            {
                btnAddBrand.Enabled = true;
            }
            if (btnSoldOut.Enabled == false)
            {
                btnSoldOut.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(lblAddModelBrand.Visible)
            {
                string modelName = txtAddModelName.Text.Trim();
                int brandId = Convert.ToInt32(dropdownAddModelBrand.SelectedValue);
                string result = this.db.AddModel(modelName, brandId);

                MessageBox.Show(result, "Model Added", MessageBoxButtons.OK);

                Thread LoadModels = new Thread(delegate () {
                    this.models = this.db.GetModels(0);
                });

                LoadModels.Start();

            } else if(txtAddBrandName.Visible)
            {
                string brandName = txtAddBrandName.Text.Trim();
                string result = this.db.AddBrand(brandName);

                MessageBox.Show(result, "Brand Added", MessageBoxButtons.OK);

                Thread LoadBrands = new Thread(delegate () {
                    this.brands = this.db.GetBrands();
                });

                LoadBrands.Start();
            } else if(dataGridCommon.Visible)
            {
                DataTable newDevices = new DataTable();
                //Adding the Columns.
                foreach (DataGridViewColumn column in dataGridCommon.Columns)
                {
                    newDevices.Columns.Add(column.HeaderText, column.ValueType);
                }

                //Adding the Rows.
                foreach (DataGridViewRow row in dataGridCommon.Rows)
                {
                    newDevices.Rows.Add();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if(cell.ValueType == typeof(DateTime))
                        {
                            try
                            {
                                newDevices.Rows[newDevices.Rows.Count - 1][cell.ColumnIndex] = cell.Value != null ? cell.Value.ToString() : "";
                            }
                            catch
                            {
                                newDevices.Rows[newDevices.Rows.Count - 1][cell.ColumnIndex] = "";
                            }
                        } else
                        {
                            newDevices.Rows[newDevices.Rows.Count - 1][cell.ColumnIndex] = cell.Value != null ? cell.Value.ToString() : "";
                        }
                    }
                }

                DataRow[] filteredDevices = newDevices.Select("[S/N] <> '' AND Model <> ''");
                DataTable filteredDevicesTable = filteredDevices.CopyToDataTable();

                string result = this.db.AddDevices(filteredDevicesTable);

                MessageBox.Show(result, "Devices Added", MessageBoxButtons.OK);
            }
        }

        private void dropdownGetDevicesBrand_SelectedChangeCommitted(object sender, EventArgs e)
        {
            int brandId = Convert.ToInt32(dropdownGetDevicesBrand.SelectedValue);

            DataTable models = this.db.GetModels(brandId);

            dropdownGetDevicesModel.DataSource = models;
            dropdownGetDevicesModel.DisplayMember = "Model";
            dropdownGetDevicesModel.ValueMember = "ID";
        }

        void showData(int pageNumber, int pageSize, string search, int modelId, string type, DateTime? soldOnDate, DateTime? purchasedOnDate)
        {
            this.dataGridDevices.Columns.Clear();

            int total = Convert.ToInt32(this.db.GetTotalDevices(search, modelId, soldOnDate, purchasedOnDate));
            int remainingPages = 0;

            int maxPage = 0;

            if (total % pageSize == 0)
            {
                maxPage = (total / pageSize);
            }
            else
            {
                maxPage = (total / pageSize) + 1;
            }

            if (remainingPages > -1)
            {
                if (type == "nextPage")
                {
                    pageNumber = pageNumber + 1;
                }

            }

            if (pageNumber < 1)
            {
                pageNumber = 1;
            }
            else
            {
                if (type == "previousPage")
                {
                    pageNumber = pageNumber - 1;
                }
            }

            if (pageNumber == maxPage || maxPage < 1)
            {
                this.btnNextPage.Enabled = false;
            }
            else
            {
                this.btnNextPage.Enabled = true;
            }

            if (pageNumber == 1)
            {
                this.btnPreviousPage.Enabled = false;
            }
            else
            {
                this.btnPreviousPage.Enabled = true;
            }

            txtPageNo.Text = Convert.ToString(pageNumber);

            this.devices = this.db.GetDevices(search, modelId, pageNumber, pageSize, "", "", soldOnDate, purchasedOnDate);

            this.dataGridDevices.DataSource = this.devices;

            this.dataGridDevices.Columns["No."].ReadOnly = true;
            this.dataGridDevices.Columns["Brand"].ReadOnly = true;

            DataGridViewComboBoxColumn modelsComboBox = new DataGridViewComboBoxColumn();
            {
                modelsComboBox.DataSource = this.models;
                modelsComboBox.Name = "Model";
                modelsComboBox.DisplayMember = "Model";
                modelsComboBox.ValueMember = "ID";
                this.dataGridDevices.Columns["ModelName"].Visible = false;
                this.dataGridDevices.Columns.Insert(4, modelsComboBox);

                foreach (DataGridViewRow row in this.dataGridDevices.Rows)
                {
                    row.Cells["Model"].Value = row.Cells["ModelId"].Value;
                }
            }

            CalendarColumn purchasedOn = new CalendarColumn();
            {
                purchasedOn.Name = "Purchased on";
                this.dataGridDevices.Columns.Insert(10, purchasedOn);
                this.dataGridDevices.Columns["PurchasedOn"].Visible = false;

                foreach (DataGridViewRow row in this.dataGridDevices.Rows)
                {
                    try
                    {
                        row.Cells["Purchased on"].Value = DateTime.ParseExact(row.Cells["PurchasedOn"].Value.ToString(), "dd/MM/yyyy", null);
                    } catch
                    {
                        row.Cells["Purchased on"].Value = null;
                    }
                }
            }

            CalendarColumn soldOn = new CalendarColumn();
            {
                soldOn.Name = "Sold on";
                this.dataGridDevices.Columns.Insert(14, soldOn);
                this.dataGridDevices.Columns["SoldOn"].Visible = false;

                foreach (DataGridViewRow row in this.dataGridDevices.Rows)
                {
                    try
                    {
                        row.Cells["Sold on"].Value = DateTime.ParseExact(row.Cells["SoldOn"].Value.ToString(), "dd/MM/yyyy", null);
                    }
                    catch
                    {
                        row.Cells["Sold on"].Value = null;
                    }
                }
            }

            DataGridViewButtonColumn button = new DataGridViewButtonColumn();
            {
                button.Name = "btnRemarks";
                button.HeaderText = "";
                button.Text = "Remarks";
                button.UseColumnTextForButtonValue = true;
                this.dataGridDevices.Columns.Add(button);
            }

            DataGridViewButtonColumn button2 = new DataGridViewButtonColumn();
            {
                button2.Name = "btnSave";
                button2.HeaderText = "";
                button2.Text = "Save";
                button2.UseColumnTextForButtonValue = true;
                this.dataGridDevices.Columns.Add(button2);
            }

            DataGridViewButtonColumn button3 = new DataGridViewButtonColumn();
            {
                button3.Name = "btnDelete";
                button3.HeaderText = "";
                button3.Text = "Delete";
                button3.UseColumnTextForButtonValue = true;
                this.dataGridDevices.Columns.Add(button3);
            }

            this.dataGridDevices.Columns["ID"].Visible = false;
            this.dataGridDevices.Columns["BrandId"].Visible = false;
            this.dataGridDevices.Columns["ModelId"].Visible = false;
            this.dataGridDevices.Columns["BuyerId"].Visible = false;
            this.dataGridDevices.Columns["UpdateRemarks"].HeaderText = "Update remarks";
            this.dataGridDevices.Columns["RepairRemarks"].HeaderText = "Repair remarks";
            this.dataGridDevices.Columns["UpdateRemarks"].Visible = false;
            this.dataGridDevices.Columns["RepairRemarks"].Visible = false;

            this.lblTotalValue.Text = Convert.ToString(total);
            this.dataGridDevices.Show();
        }

        private void lblSearch_Click(object sender, EventArgs e)
        {

        }

        private void Initialize()
        {
            this.db.UpdateAccessedDate();
            this.brands = this.db.GetBrands();
            this.models = this.db.GetModels(0);
            this.report = this.db.GetReport();
            this.buyers = this.db.GetBuyers();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            this.showReport();
        }

        private void btnSoldOut_Click(object sender, EventArgs e)
        {
            txtAddBrandName.Hide();
            lblAddBrandModelName.Hide();
            lblAddModelBrand.Hide();
            dropdownAddModelBrand.Hide();
            txtAddModelName.Hide();
            dataGridCommon.Hide();
            this.checkBoxShowAllStock.Hide();

            grpAddComponents.Hide();
            this.btnModels.Hide();
            grpShowDevices.Show();
            btnSoldOut.Enabled = false;

            if (btnAddModel.Enabled == false)
            {
                btnAddModel.Enabled = true;
            }
            if (btnAddDevice.Enabled == false)
            {
                btnAddDevice.Enabled = true;
            }
            if (btnAddBrand.Enabled == false)
            {
                btnAddBrand.Enabled = true;
            }
            if (btnReport.Enabled == false)
            {
                btnReport.Enabled = true;
            }
            if (btnShowDevice.Enabled == false)
            {
                btnShowDevice.Enabled = true;
            }

            btnSoldOutSave.Enabled = true;

            this.dataGridDevices.Columns.Clear();
            this.dataGridDevices.DataSource = null;

            lblBrand.Hide();
            dropdownGetDevicesBrand.Hide();
            lblModel.Hide();
            dropdownGetDevicesModel.Hide();
            btnGetDevices.Hide();
            lblPageSize.Hide();
            dropdownPageSize.Hide();
            lblSearch.Hide();
            txtCodeSearch.Hide();
            lblPageSize.Hide();
            dropdownPageSize.Hide();
            btnNextPage.Hide();
            btnPreviousPage.Hide();
            lblPageNo.Hide();
            txtPageNo.Hide();

            btnSoldOutSave.Show();
            lblSoldTo.Show();
            dropDownSoldTo.Show();
            lblSoldOn.Show();
            dateTimePickerOuter.Show();

            lblPurchasedOn.Hide();
            dateTimePickerPurchasedOn.Hide();

            this.dataGridDevices.Columns.Add("SN", "S/N");
            this.dataGridDevices.Columns["SN"].ValueType = typeof(string);
            this.dateTimePickerOuter.Value = DateTime.Now;
            this.dateTimePickerPurchasedOn.Value = DateTime.Now;
            dropDownSoldTo.DisplayMember = "Buyer";
            dropDownSoldTo.ValueMember = "ID";
            dropDownSoldTo.DataSource = this.buyers;
            dropDownSoldTo.SelectedItem = null;

            DataGridViewButtonColumn newDevice = new DataGridViewButtonColumn();
            {
                newDevice.Name = "btnAddDeviceNew";
                newDevice.HeaderText = "Add";
                newDevice.Text = "+";
                newDevice.UseColumnTextForButtonValue = true;
                newDevice.DefaultCellStyle.NullValue = "+";
                newDevice.ValueType = typeof(string);
                this.dataGridDevices.Columns.Add(newDevice);
            }

            DataGridViewButtonColumn removeDevice = new DataGridViewButtonColumn();
            {
                removeDevice.Name = "btnRemoveDeviceNew";
                removeDevice.HeaderText = "Remove";
                removeDevice.Text = "-";
                removeDevice.UseColumnTextForButtonValue = true;
                removeDevice.DefaultCellStyle.NullValue = "-";
                removeDevice.ValueType = typeof(string);
                this.dataGridDevices.Columns.Add(removeDevice);
            }

            this.dataGridDevices.Columns["SN"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridDevices.Columns["btnAddDeviceNew"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridDevices.Columns["btnRemoveDeviceNew"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridDevices.Rows.Add();

        }

        private void btnSoldOutSave_Click(object sender, EventArgs e)
        {
            try
            {
                string soldTo = dropDownSoldTo.Text;
                string soldOn = dateTimePickerOuter.Value.ToString();

                DataTable soldDevices = new DataTable();
                //Adding the Columns.
                foreach (DataGridViewColumn column in dataGridDevices.Columns)
                {
                    soldDevices.Columns.Add(column.HeaderText, column.ValueType);
                }

                //Adding the Rows.
                foreach (DataGridViewRow row in dataGridDevices.Rows)
                {
                    soldDevices.Rows.Add();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.ValueType == typeof(DateTime))
                        {
                            try
                            {
                                soldDevices.Rows[soldDevices.Rows.Count - 1][cell.ColumnIndex] = cell.Value != null ? cell.Value.ToString() : "";
                            }
                            catch
                            {
                                soldDevices.Rows[soldDevices.Rows.Count - 1][cell.ColumnIndex] = "";
                            }
                        }
                        else
                        {
                            soldDevices.Rows[soldDevices.Rows.Count - 1][cell.ColumnIndex] = cell.Value != null ? cell.Value.ToString() : "";
                        }
                    }
                }

                DataRow[] filteredDevices = soldDevices.Select("[S/N] <> ''");
                DataTable filteredDevicesTable = filteredDevices.CopyToDataTable();

                string result = this.db.UpdateSoldDevices(filteredDevicesTable, soldTo, soldOn);

                MessageBox.Show(result, "Devices Sold", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error on UpdateSoldDevices: " + ex.Message + ", stack: " + ex.StackTrace);
                MessageBox.Show("Something went wrong", "Notice", MessageBoxButtons.OK);
            }
        }

        void remarks_onBtnSaveClick(object sender, EventArgs e, int id)
        {
            try
            {
                string repairRemarks = deviceRemarksForm.txtRepairRemarksEdit.Text.Trim();
                string updateRemarks = deviceRemarksForm.txtUpdateRemarksEdit.Text.Trim();

                string result = this.db.UpdateDeviceRemarks(id, updateRemarks, repairRemarks);
                DialogResult dialogResultUpdated = MessageBox.Show(result, "Notice", MessageBoxButtons.OK);

                if (dialogResultUpdated == DialogResult.OK)
                    if (dialogResultUpdated == DialogResult.OK)
                    {
                        this.deviceRemarksForm.Close();
                        int pageNo = 1;
                        int.TryParse(this.txtPageNo.Text, out pageNo);
                        int pageSize = 20;
                        int.TryParse(this.dropdownPageSize.Text, out pageSize);
                        int modelId = 0;
                        int.TryParse(this.dropdownGetDevicesModel.ValueMember, out modelId);

                        this.showData(pageNo, pageSize, this.txtCodeSearch.Text, modelId, "", this.dateTimePickerOuter.Value, this.dateTimePickerPurchasedOn.Value);
                    }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error on EditDeviceRemarks: " + ex.Message + ", stack: " + ex.StackTrace);
                MessageBox.Show("Something went wrong", "Notice", MessageBoxButtons.OK);
            }
        }

        private void dateTimePickerSoldOn_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void grpShowDevices_Enter(object sender, EventArgs e)
        {

        }

        private void dropdownGetDevicesModel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnModels_Click(object sender, EventArgs e)
        {
            grpShowDevices.Hide();
            txtAddBrandName.Hide();
            //dataGridCommon.Show();
            lblAddBrandModelName.Show();
            btnReport.Enabled = true;
            this.btnSave.Hide();
            this.btnCancel.Hide();

            grpAddComponents.Show();
            lblAddBrandModelName.Hide();
            txtAddModelName.Hide();
            lblAddModelBrand.Hide();
            this.btnModels.Hide();

            grpAddComponents.Text = "Add Model";
            btnAddModel.Enabled = true;

            dropdownAddModelBrand.Hide();

            if (btnShowDevice.Enabled == false)
            {
                btnShowDevice.Enabled = true;
            }
            if (btnAddDevice.Enabled == false)
            {
                btnAddDevice.Enabled = true;
            }
            if (btnAddBrand.Enabled == false)
            {
                btnAddBrand.Enabled = true;
            }
            if (btnSoldOut.Enabled == false)
            {
                btnSoldOut.Enabled = true;
            }

            if (dataGridCommon.ReadOnly == false)
            {
                dataGridCommon.ReadOnly = true;
            }

            this.dataGridCommon.Columns.Clear();
            this.dataGridCommon.DataSource = this.db.GetModels(0,false);

            this.dataGridCommon.Columns["No."].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridCommon.Columns["Model"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridCommon.Columns["ID"].Visible = false;

            DataGridViewButtonColumn button = new DataGridViewButtonColumn();
            {
                button.Name = "btnModelDelete";
                button.HeaderText = "";
                button.Text = "Delete";
                button.UseColumnTextForButtonValue = true;
                this.dataGridCommon.Columns.Add(button);
            }
            
            if (!dataGridCommon.Visible)
            {
                dataGridCommon.Show();
            }
        }

        private void dateTimePickerOuter_MouseDown(object sender, MouseEventArgs e)
        {
            //this.dateTimePickerOuter.Value = DateTime.Now;
        }

        private void checkBoxShowAllStock_CheckedChanged(object sender, EventArgs e)
        {
            this.showReport(this.checkBoxShowAllStock.Checked);
        }

        private void showReport(bool showAllStock = false)
        {
            if (btnReport.Enabled == true)
            {
                btnReport.Enabled = false;
            }
            if (btnAddModel.Enabled == false)
            {
                btnAddModel.Enabled = true;
            }
            if (btnShowDevice.Enabled == false)
            {
                btnShowDevice.Enabled = true;
            }
            if (btnAddBrand.Enabled == false)
            {
                btnAddBrand.Enabled = true;
            }
            if (btnAddDevice.Enabled == false)
            {
                btnAddDevice.Enabled = true;
            }
            if (btnSoldOut.Enabled == false)
            {
                btnSoldOut.Enabled = true;
            }

            if (dataGridCommon.ReadOnly == false)
            {
                dataGridCommon.ReadOnly = true;
            }

            grpShowDevices.Hide();
            dataGridCommon.Show();
            txtAddBrandName.Hide();
            lblAddBrandModelName.Hide();
            lblAddModelBrand.Hide();
            dropdownAddModelBrand.Hide();
            txtAddModelName.Hide();
            this.btnSave.Hide();
            this.btnCancel.Hide();
            this.btnModels.Hide();
            this.checkBoxShowAllStock.Show();

            grpAddComponents.Show();
            grpAddComponents.Text = "Report";

            this.report = this.db.GetReport(showAllStock);
            this.dataGridCommon.Columns.Clear();
            this.dataGridCommon.DataSource = this.report;

            this.dataGridCommon.Columns["No."].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridCommon.Columns["Brand"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridCommon.Columns["Model"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridCommon.Columns["Device count"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            //this.dataGridCommon.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            if (!dataGridCommon.Visible)
            {
                dataGridCommon.Show();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
