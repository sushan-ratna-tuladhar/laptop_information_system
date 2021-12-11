using System;
using System.Data;
using System.Windows.Forms;

namespace LaptopInformationSystem
{
    public partial class MainForm : Form
    {
        private Helpers.DbHelper db = new Helpers.DbHelper();
        private DataTable devices;
        private DeviceActionForm deviceAction;
        private DeviceEditForm deviceEdit;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.db.UpdateAccessedDate();
        }

        private void btnShowDevice_Click(object sender, EventArgs e)
        {
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

            try
            {
                DataTable brands = this.db.GetBrands();

                dropdownGetDevicesBrand.DisplayMember = "Brand";
                dropdownGetDevicesBrand.ValueMember = "ID";
                dropdownGetDevicesBrand.DataSource = brands;
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
            // find out which column was clicked
            if (this.dataGridDevices.Columns[e.ColumnIndex] == dataGridDevices.Columns[6])
            {
                // display on the new form.
                this.deviceAction = new DeviceActionForm();
                EventArgs args = new EventArgs();

                int id = Convert.ToInt32(this.dataGridDevices.Rows[e.RowIndex].Cells[1].Value.ToString());
                string code = this.dataGridDevices.Rows[e.RowIndex].Cells[2].Value.ToString();
                string model = this.dataGridDevices.Rows[e.RowIndex].Cells[3].Value.ToString();
                string type = this.dataGridDevices.Rows[e.RowIndex].Cells[4].Value.ToString();
                string purchasedOn = this.dataGridDevices.Rows[e.RowIndex].Cells[5].Value.ToString();

                deviceAction.onBtnEditClick += (_sender, _e) => edit_onBtnEditClick(sender, e, id, code, model, type, purchasedOn);
                deviceAction.onBtnDeleteClick += (_sender, _e) => action_onBtnDeleteClick(sender, e, code);

                deviceAction.ShowDialog();
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

            grpAddComponents.Show();
            lblAddBrandModelName.Show();
            txtAddModelName.Show();
            lblAddModelBrand.Show();
            
            grpAddComponents.Text = "Add Model";
            btnAddModel.Enabled = false;

            DataTable brands = this.db.GetBrands();

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
            } else
            {
                string brandName = txtAddBrandName.Text.Trim();
                string result = this.db.AddBrand(brandName);

                MessageBox.Show(result, "Brand Added", MessageBoxButtons.OK);
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

        //Custom functions
        void edit_onBtnEditClick(object sender, EventArgs e, int id, string code, string model, string type, string purchasedOn)
        {
            this.deviceAction.Close();
            this.deviceEdit = new DeviceEditForm(code, model, type, purchasedOn);
            EventArgs args = new EventArgs();

            deviceEdit.onBtnSaveClick += (_sender, _e) => edit_onBtnSaveClick(sender, e, id);
            deviceEdit.ShowDialog();
        }

        void edit_onBtnSaveClick(object sender, EventArgs e, int id)
        {
            try
            {
                string changedCode = deviceEdit.txtCodeEdit.Text.Trim();
                string changedModel = deviceEdit.txtModelEdit.Text.Trim();
                string changedType = deviceEdit.dropdownTypeEdit.Text.Trim();
                string changedPurchasedOn = deviceEdit.dateTimePickerPurchasedOnEdit.Value.ToString("yyyy-MM-dd");

                DialogResult dialogResult = MessageBox.Show("Update device?", "Update", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    string result = this.db.UpdateDevice(id, changedCode, changedModel, changedType, changedPurchasedOn);
                    DialogResult dialogResultUpdated = MessageBox.Show(result, "Notice", MessageBoxButtons.OK);

                    if (dialogResultUpdated == DialogResult.OK)
                    {
                        this.deviceEdit.Close();
                        this.showData(1, 20, "", 0, "");
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    this.deviceEdit.Close();
                    this.showData(1, 20, "", 0, "");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error on EditDevice: " + ex.Message + ", stack: " + ex.StackTrace);
                MessageBox.Show("Something went wrong", "Notice", MessageBoxButtons.OK);
            }
        }

        void action_onBtnDeleteClick(object sender, EventArgs e, string code)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Delete device " + code, "Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string result = this.db.DeleteDevice(code);
                    DialogResult dialogResultDeleted = MessageBox.Show(result, "Notice", MessageBoxButtons.OK);

                    if (dialogResultDeleted == DialogResult.OK)
                    {
                        this.deviceAction.Close();
                        this.showData(1, 20, "", 0, "");
                        this.lblTotalValue.Text = Convert.ToString(this.db.GetTotalDevices("", 0));
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    this.deviceAction.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error on DeleteDevice: " + ex.Message + ", stack: " + ex.StackTrace);
                MessageBox.Show("Something went wrong", "Notice", MessageBoxButtons.OK);
            }
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

            DataGridViewButtonColumn button = new DataGridViewButtonColumn();
            {
                button.Name = "btnAction";
                button.HeaderText = "";
                button.Text = "Action";
                button.UseColumnTextForButtonValue = true;
                this.dataGridDevices.Columns.Add(button);
            }

            this.dataGridDevices.Columns["ID"].Visible = false;
            this.lblTotalValue.Text = Convert.ToString(total);
            this.dataGridDevices.Show();
        }

        private void lblSearch_Click(object sender, EventArgs e)
        {

        }

    }
}
