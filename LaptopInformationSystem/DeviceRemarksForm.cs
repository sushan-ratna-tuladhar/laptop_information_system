using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaptopInformationSystem
{
    public partial class DeviceRemarksForm : Form
    {
        public event EventHandler onBtnSaveClick;

        public DeviceRemarksForm()
        {
            InitializeComponent();
        }

        public DeviceRemarksForm(string updateRemarks, string repairRemarks)
        {
            InitializeComponent();
            this.txtUpdateRemarksEdit.Text = updateRemarks;
            this.txtRepairRemarksEdit.Text = repairRemarks;
        }

        private void txtCodeEdit_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtModelEdit_TextChanged(object sender, EventArgs e)
        {

        }

        private void DeviceEditForm_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveEdit_Click(object sender, EventArgs e)
        {
            onBtnSaveClick?.Invoke(btnSaveEdit.Text, null);
        }
    }
}
