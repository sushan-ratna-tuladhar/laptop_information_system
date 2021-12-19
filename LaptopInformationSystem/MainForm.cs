using System;
using System.Data;
using System.Drawing;
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
        public DateTimePicker newDateTime;

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
                            Cursor.Current = Cursors.WaitCursor;

                            this.btnShowDevice.Enabled = true;
                            this.btnAddDevice.Enabled = true;
                            this.btnAddBrand.Enabled = true;
                            this.btnAddModel.Enabled = true;
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
                            this.dataGridCommon.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                            this.dataGridCommon.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            this.dataGridCommon.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            this.dataGridCommon.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                            this.btnSave.Hide();
                            this.btnCancel.Hide();

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
            this.lblLoading.Show();

            Initialize.Start();

        }

        private void btnShowDevice_Click(object sender, EventArgs e)
        {
            if (grpShowDevices.Visible)
            {
                grpShowDevices.Hide();
            }
            if (!dataGridCommon.Visible)
            {
                dataGridCommon.Show();
            }
            if (txtAddBrandName.Visible)
            {
                txtAddBrandName.Hide();
            }
            if (lblAddBrandModelName.Visible)
            {
                lblAddBrandModelName.Hide();
            }
            if (lblAddModelBrand.Visible)
            {
                lblAddModelBrand.Hide();
            }
            if (dropdownAddModelBrand.Visible)
            {
                dropdownAddModelBrand.Hide();
            }
            if (txtAddModelName.Visible)
            {
                txtAddModelName.Hide();
            }
            if (dataGridCommon.Visible)
            {
                dataGridCommon.Hide();
            }

            if (grpAddComponents.Visible)
            {
                grpAddComponents.Hide();
            }
            grpShowDevices.Show();
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

            try
            {
                dropdownGetDevicesBrand.DisplayMember = "Brand";
                dropdownGetDevicesBrand.ValueMember = "ID";
                dropdownGetDevicesBrand.DataSource = this.brands;
                dropdownGetDevicesBrand.SelectedItem = null;

                this.txtCodeSearch.Text = "";
                this.txtPageNo.Text = "1";
                this.dropdownPageSize.Text = "20";

                this.showData(1, 20, "", 0, "");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error on GetDevices : " + ex.Message + ", stack: " + ex.StackTrace);
                MessageBox.Show("Something went wrong", "Notice", MessageBoxButtons.OK);
            }

            
        }

        private void btnAddDevice_Click(object sender, EventArgs e)
        {
            if(grpShowDevices.Visible)
            {
                grpShowDevices.Hide();
            }
            if(!dataGridCommon.Visible)
            {
                dataGridCommon.Show();
            }
            if (txtAddBrandName.Visible)
            {
                txtAddBrandName.Hide();
            }
            if (lblAddBrandModelName.Visible)
            {
                lblAddBrandModelName.Hide();
            }
            if (lblAddModelBrand.Visible)
            {
                lblAddModelBrand.Hide();
            }
            if (dropdownAddModelBrand.Visible)
            {
                dropdownAddModelBrand.Hide();
            }
            if (txtAddModelName.Visible)
            {
                txtAddModelName.Hide();
            }

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

            if(!this.btnSave.Visible)
            {
                this.btnSave.Show();
            }
            if(!this.btnCancel.Visible)
            {
                this.btnCancel.Show();
            }

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
                soldOn.ValueType = typeof(DateTime);
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

            this.dataGridCommon.Columns["Model"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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
                int pageNumber = 1;
                int pageSize = Convert.ToInt32(dropdownPageSize.Text.Trim());
                string search = this.txtCodeSearch.Text.Trim();
                int modelId = Convert.ToInt32(dropdownGetDevicesModel.SelectedValue);

                this.showData(pageNumber, pageSize, search, modelId, "");
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
                int modelId = Convert.ToInt32(dropdownGetDevicesModel.SelectedValue);

                this.showData(pageNumber, pageSize, search, modelId, "previousPage");
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
                int modelId = Convert.ToInt32(dropdownGetDevicesModel.SelectedValue);

                this.showData(pageNumber, pageSize, search, modelId, "nextPage");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error on GetDevices/NextPage : " + ex.Message + ", stack: " + ex.StackTrace);
                MessageBox.Show("Something went wrong", "Notice", MessageBoxButtons.OK);
            }
        }

        private void dataGridDevices_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dataGridDevices.Rows[e.RowIndex].Cells["ID"].Value);
            int modelId = Convert.ToInt32(dataGridDevices.Rows[e.RowIndex].Cells["ModelId"].Value);
            string serialNo = dataGridDevices.Rows[e.RowIndex].Cells["S/N"].Value != null ? dataGridDevices.Rows[e.RowIndex].Cells["S/N"].Value.ToString() : "";
            string type = dataGridDevices.Rows[e.RowIndex].Cells["Type"].Value != null ? dataGridDevices.Rows[e.RowIndex].Cells["Type"].Value.ToString() : "";
            string purchasedFrom = dataGridDevices.Rows[e.RowIndex].Cells["Purchased from"].Value != null ? dataGridDevices.Rows[e.RowIndex].Cells["Purchased from"].Value.ToString() : "";
            string purchasedOn = dataGridDevices.Rows[e.RowIndex].Cells["Purchased on"].Value != null ? dataGridDevices.Rows[e.RowIndex].Cells["Purchased on"].Value.ToString() : null;
            if (purchasedOn != null)
            {
                purchasedOn = DateTime.Parse(purchasedOn).ToString("yyyy-MM-dd");
            }
            string invoiceNumber = dataGridDevices.Rows[e.RowIndex].Cells["Invoice number"].Value != null ? dataGridDevices.Rows[e.RowIndex].Cells["Invoice number"].Value.ToString() : "";
            string soldTo = dataGridDevices.Rows[e.RowIndex].Cells["Sold to"].Value != null ? dataGridDevices.Rows[e.RowIndex].Cells["Sold to"].Value.ToString() : "";
            string soldOn = dataGridDevices.Rows[e.RowIndex].Cells["Sold on"].Value != null ? dataGridDevices.Rows[e.RowIndex].Cells["Sold on"].Value.ToString() : null;
            if (soldOn != null)
            {
                soldOn = DateTime.Parse(purchasedOn).ToString("yyyy-MM-dd");
            }

            // when save button is clicked
            if (this.dataGridDevices.Columns[e.ColumnIndex].Name == "btnSave")
            {
                string result = this.db.UpdateDevice(id, serialNo, modelId, type, purchasedOn, purchasedFrom, soldOn, soldTo, invoiceNumber);

                DialogResult dialogResult = MessageBox.Show(result, "Update", MessageBoxButtons.OK);
            }

            //when delete button is clicked
            if (this.dataGridDevices.Columns[e.ColumnIndex].Name == "btnDelete")
            {
                DialogResult dialogResult = MessageBox.Show("Delete device " + serialNo + "?", "Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string result = this.db.DeleteDevice(serialNo);
                    DialogResult dialogResultDeleted = MessageBox.Show(result, "Notice", MessageBoxButtons.OK);

                    if (dialogResultDeleted == DialogResult.OK)
                    {
                        this.showData(Convert.ToInt32(this.txtPageNo.Text), 20, "", 0, "");
                        this.lblTotalValue.Text = Convert.ToString(this.db.GetTotalDevices("", 0));
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                }
            }
        }

        private void dataGridAddDevices_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //when delete button is clickedf
            if (this.dataGridCommon.Columns[e.ColumnIndex].Name == "btnAddDeviceNew")
            {
                this.dataGridCommon.Rows.Add();
            }

            if (this.dataGridCommon.Columns[e.ColumnIndex].Name == "btnRemoveDeviceNew")
            {
                if(dataGridCommon.Rows.Count > 1)
                {
                    this.dataGridCommon.Rows.RemoveAt(dataGridCommon.CurrentRow.Index);
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
            if (grpShowDevices.Visible)
            {
                grpShowDevices.Hide();
            }
            if (txtAddModelName.Visible)
            {
                txtAddModelName.Hide();
            }
            if (lblAddModelBrand.Visible)
            {
                lblAddModelBrand.Hide();
            }
            if (dropdownAddModelBrand.Visible)
            {
                dropdownAddModelBrand.Hide();
            }
            if (dataGridCommon.Visible)
            {
                dataGridCommon.Hide();
            }
            if (!lblAddBrandModelName.Visible)
            {
                lblAddBrandModelName.Show();
            }
            if (!this.btnSave.Visible)
            {
                this.btnSave.Show();
            }
            if (!this.btnCancel.Visible)
            {
                this.btnCancel.Show();
            }

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
        }

        private void btnAddModel_Click(object sender, EventArgs e)
        {
            if (grpShowDevices.Visible)
            {
                grpShowDevices.Hide();
            }
            if (txtAddBrandName.Visible)
            {
                txtAddBrandName.Hide();
            }
            if (dataGridCommon.Visible)
            {
                dataGridCommon.Hide();
            }
            if (!lblAddBrandModelName.Visible)
            {
                lblAddBrandModelName.Show();
            }
            if (btnReport.Enabled == false)
            {
                btnReport.Enabled = true;
            }
            if (!this.btnSave.Visible)
            {
                this.btnSave.Show();
            }
            if (!this.btnCancel.Visible)
            {
                this.btnCancel.Show();
            }

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
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(lblAddModelBrand.Visible)
            {
                string modelName = txtAddModelName.Text.Trim();
                int brandId = Convert.ToInt32(dropdownAddModelBrand.SelectedValue);
                string result = this.db.AddModel(modelName, brandId);

                MessageBox.Show(result, "Model Added", MessageBoxButtons.OK);

                Thread LoadBrands = new Thread(delegate () {
                    this.brands = this.db.GetBrands();
                });

                LoadBrands.Start();

            } else if(txtAddBrandName.Visible)
            {
                string brandName = txtAddBrandName.Text.Trim();
                string result = this.db.AddBrand(brandName);

                MessageBox.Show(result, "Brand Added", MessageBoxButtons.OK);

                Thread LoadModels = new Thread(delegate () {
                    this.brands = this.db.GetModels(0);
                });

                LoadModels.Start();
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
                            newDevices.Rows[newDevices.Rows.Count - 1][cell.ColumnIndex] = cell.Value != null ? cell.Value.ToString() : "01/01/1999";
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

        void showData(int pageNumber, int pageSize, string search, int modelId, string type)
        {
            this.dataGridDevices.Columns.Clear();

            int total = Convert.ToInt32(this.db.GetTotalDevices(search, modelId));
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

            if (pageNumber == maxPage)
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

            this.devices = this.db.GetDevices(search, modelId, pageNumber, pageSize, "", "");

            this.dataGridDevices.DataSource = this.devices;

            DataGridViewComboBoxColumn brandsComboBox = new DataGridViewComboBoxColumn();
            {
                brandsComboBox.DataSource = this.brands;
                brandsComboBox.Name = "Brand";
                brandsComboBox.DisplayMember = "Brand";
                brandsComboBox.ValueMember = "ID";
                this.dataGridDevices.Columns["BrandName"].Visible = false;
                this.dataGridDevices.Columns.Insert(2, brandsComboBox);

                foreach (DataGridViewRow row in this.dataGridDevices.Rows)
                {
                    row.Cells["Brand"].Value = row.Cells["BrandId"].Value;
                }
            }

            DataGridViewComboBoxColumn modelsComboBox = new DataGridViewComboBoxColumn();
            {
                modelsComboBox.DataSource = this.models;
                modelsComboBox.Name = "Model";
                modelsComboBox.DisplayMember = "Model";
                modelsComboBox.ValueMember = "ID";
                this.dataGridDevices.Columns["ModelName"].Visible = false;
                this.dataGridDevices.Columns.Insert(3, modelsComboBox);

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
                button.Name = "btnSave";
                button.HeaderText = "";
                button.Text = "Save";
                button.UseColumnTextForButtonValue = true;
                this.dataGridDevices.Columns.Add(button);
            }

            DataGridViewButtonColumn button2 = new DataGridViewButtonColumn();
            {
                button2.Name = "btnDelete";
                button2.HeaderText = "";
                button2.Text = "Delete";
                button2.UseColumnTextForButtonValue = true;
                this.dataGridDevices.Columns.Add(button2);
            }

            this.dataGridDevices.Columns["ID"].Visible = false;
            this.dataGridDevices.Columns["BrandId"].Visible = false;
            this.dataGridDevices.Columns["ModelId"].Visible = false;

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
        }

        private void btnReport_Click(object sender, EventArgs e)
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

            if (dataGridCommon.ReadOnly == false)
            {
                dataGridCommon.ReadOnly = true;
            }
            if (grpShowDevices.Visible)
            {
                grpShowDevices.Hide();
            }

            if (!dataGridCommon.Visible)
            {
                dataGridCommon.Show();
            }
            if (txtAddBrandName.Visible)
            {
                txtAddBrandName.Hide();
            }
            if (lblAddBrandModelName.Visible)
            {
                lblAddBrandModelName.Hide();
            }
            if (lblAddModelBrand.Visible)
            {
                lblAddModelBrand.Hide();
            }
            if (dropdownAddModelBrand.Visible)
            {
                dropdownAddModelBrand.Hide();
            }
            if (txtAddModelName.Visible)
            {
                txtAddModelName.Hide();
            }
            if (this.btnSave.Visible)
            {
                this.btnSave.Hide();
            }
            if (this.btnCancel.Visible)
            {
                this.btnCancel.Hide();
            }

            grpAddComponents.Show();
            grpAddComponents.Text = "Report";
            this.report = this.db.GetReport();
            this.dataGridCommon.Columns.Clear();
            this.dataGridCommon.DataSource = this.report;

            this.dataGridCommon.Columns["No."].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridCommon.Columns["Brand"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridCommon.Columns["Model"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridCommon.Columns["Device count"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            if (!dataGridCommon.Visible)
            {
                dataGridCommon.Show();
            }
        }
    }
}
