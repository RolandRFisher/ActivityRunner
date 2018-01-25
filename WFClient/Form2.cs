using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFClient
{
    public partial class Form2 : Form
    {
        public string ItemName { get { return txtItemName.Text; } }
        public int TotalRequests { get { return int.Parse(txtTotalRequests.Text); } }
        public bool IsMultiThreaded { get { return cbIsMultiThreaded.Checked; } }
        public int ConcurrentRequests { get { return int.Parse(txtConcurrentRequests.Text); } }
        public string RequestCode { get { return txtRequestCode.Text; } }
        public Form2()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
