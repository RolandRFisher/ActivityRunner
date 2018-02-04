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
        public string ItemName => txtItemName.Text;
        public int TotalRequests => int.Parse(txtTotalRequests.Text);
        public bool IsMultiThreaded => cbIsMultiThreaded.Checked;
        public int ConcurrentRequests => int.Parse(txtConcurrentRequests.Text);
        public int RequestPerSecond => int.Parse(txtRequestPerSecond.Text);
        public int Durtion => int.Parse(txtDurtion.Text);
        public bool IsRequestPerSecond => chbRequestPerSecond.Checked;

        public string RequestCode
        {
            get
            {
                return txtRequestCode.Text;
            }
            set { txtRequestCode.Text = value; }
        }
        
        public Form2()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            txtConcurrentRequests.Enabled = false;
            ActivatePanels();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void cbIsMultiThreaded_CheckedChanged(object sender, EventArgs e)
        {
            txtConcurrentRequests.Enabled = cbIsMultiThreaded.Checked;
        }

        private void btnOk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            btnOk.PerformClick();
            e.SuppressKeyPress = true;
            e.Handled = true;
        }

        private void chbRequestPerSecond_CheckedChanged(object sender, EventArgs e)
        {
            ActivatePanels();
        }

        private void ActivatePanels()
        {
            if (chbRequestPerSecond.Checked)
            {
                pnlStandardRequests.Enabled = false;
                pnlRequestPerSecond.Enabled = true;
            }
            else
            {
                pnlStandardRequests.Enabled = true;
                pnlRequestPerSecond.Enabled = false;
            }
        }

        private void SetTotalRequestPanelControls()
        {
        }
    }
}
