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
            if (grpAddDevice.Visible)
            {
                grpAddDevice.Hide();
            }
            grpShowDevices.Show();
            btnShowDevice.Enabled = false;

            if(btnAddDevice.Enabled == false)
            {
                btnAddDevice.Enabled = true;
            }

            try
            {
                int total = 0;
                this.txtCodeSearch.Text = "";
                this.txtPageNo.Text = "1";
                this.dropdownPageSize.Text = "20";
                this.lblTotalValue.Text = this.db.GetTotalDevices();
                total = Convert.ToInt32(this.lblTotalValue.Text);

                this.showData(1, 20, total, "", "");

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
            grpAddDevice.Show();
            btnAddDevice.Enabled = false;

            if (btnShowDevice.Enabled == false)
            {
                btnShowDevice.Enabled = true;
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
            grpAddDevice.Hide();
        }

        private void btnSaveDevice_Click(object sender, EventArgs e)
        {
            try
            {
                string model = txtModel.Text.Trim();
                string code = txtCode.Text.Trim();
                string type = dropdownType.Text.Trim();
                string purchasedOn = dateTimePickerPurchasedOn.Value.ToString("yyyy-MM-dd");

                string result = this.db.AddDevice(code, model, type, purchasedOn);
                
                MessageBox.Show(result, "Notice", MessageBoxButtons.OK);

            }
            catch(Exception ex)
            {
                Console.WriteLine("Error on AddDevice : " + ex.Message + ", stack: " + ex.StackTrace);
                MessageBox.Show("Something went wrong", "Notice", MessageBoxButtons.OK);
            }
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
        }

        private void dropdownPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnGetDevices_Click(object sender, EventArgs e)
        {
            try
            {
                int pageNumber = Convert.ToInt32(txtPageNo.Text.Trim());
                int pageSize = Convert.ToInt32(dropdownPageSize.Text.Trim());
                int total = Convert.ToInt32(this.lblTotalValue.Text.Trim());
                string search = this.txtCodeSearch.Text.Trim();

                this.showData(pageNumber, pageSize, total, search, "");
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
                int total = Convert.ToInt32(this.lblTotalValue.Text.Trim());
                string search = this.txtCodeSearch.Text.Trim();

                this.showData(pageNumber, pageSize, total, search, "previousPage");
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
                int total = Convert.ToInt32(this.lblTotalValue.Text.Trim());
                string search = this.txtCodeSearch.Text.Trim();

                this.showData(pageNumber, pageSize, total, search, "nextPage");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error on GetDevices/NextPage : " + ex.Message + ", stack: " + ex.StackTrace);
                MessageBox.Show("Something went wrong", "Notice", MessageBoxButtons.OK);
            }
        }

        private void showData(int pageNumber, int pageSize, int total, string search, string type)
        {
            this.dataGridDevices.Columns.Clear();
            int remainingPages = (total/pageSize - pageNumber);

            if (remainingPages >= -1)
            {
                if(type == "nextPage")
                {
                    pageNumber = pageNumber + 1;
                }

                if (remainingPages == 0)
                {
                    this.btnNextPage.Enabled = false;
                }
            }

            if (pageNumber < 1)
            {
                pageNumber = 1;
            }
            else
            {
                if(type == "previousPage")
                {
                    pageNumber = pageNumber - 1;
                }
                
                if (pageNumber == 1)
                {
                    this.btnPreviousPage.Enabled = false;
                }
            }

            txtPageNo.Text = Convert.ToString(pageNumber);

            this.devices = this.db.GetDevices(search, pageNumber, pageSize, "", "");

            this.dataGridDevices.DataSource = devices;

            DataGridViewButtonColumn button = new DataGridViewButtonColumn();
            {
                button.Name = "btnAction";
                button.HeaderText = "";
                button.Text = "Action";
                button.UseColumnTextForButtonValue = true;
                this.dataGridDevices.Columns.Add(button);
            }

            this.dataGridDevices.Columns["ID"].Visible = false;
            this.dataGridDevices.Show();
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

                    if(dialogResultUpdated == DialogResult.OK)
                    {
                        this.deviceEdit.Close();
                        this.showData(1, 20, Convert.ToInt32(this.lblTotalValue.Text), "", "");
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    this.deviceEdit.Close();
                    this.showData(1, 20, Convert.ToInt32(this.lblTotalValue.Text), "", "");
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

                    if(dialogResultDeleted == DialogResult.OK)
                    {
                        this.deviceAction.Close();
                        this.showData(1, 20, Convert.ToInt32(this.lblTotalValue.Text), "", "");
                        this.lblTotalValue.Text = Convert.ToString(this.db.GetTotalDevices());
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
    }
}
