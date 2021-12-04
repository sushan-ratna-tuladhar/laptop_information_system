using System;
using System.Windows.Forms;

namespace LaptopInformationSystem
{
    public partial class DeviceActionForm : Form
    {
        private string code;
        public event EventHandler onBtnEditClick;
        public event EventHandler onBtnDeleteClick;

        public DeviceActionForm()
        {
            InitializeComponent();
        }

        public DeviceActionForm(string code)
        {
            InitializeComponent();
            this.code = code;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            onBtnEditClick?.Invoke(btnEdit.Text, null);
            this.Close();
        }

        private void Popup_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            onBtnDeleteClick?.Invoke(btnDelete.Text, null);
        }
    }
}
