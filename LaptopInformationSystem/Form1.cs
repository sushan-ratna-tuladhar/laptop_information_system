using System;
using System.Windows.Forms;

namespace LaptopInformationSystem
{
    public partial class Form1 : Form
    {
        private Helpers.DbHelper db = new Helpers.DbHelper();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.db.UpdateAccessedDate();
        }

        private void btnShowDevice_Click(object sender, EventArgs e)
        {

        }

        private void btnAddDevice_Click(object sender, EventArgs e)
        {
            grpAddDevice.Show();
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
    }
}
