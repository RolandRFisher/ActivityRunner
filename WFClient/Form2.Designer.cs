namespace WFClient
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.txtTotalRequests = new System.Windows.Forms.NumericUpDown();
            this.txtConcurrentRequests = new System.Windows.Forms.NumericUpDown();
            this.lblMaxConcurrentThreads = new System.Windows.Forms.Label();
            this.lblTotalRequests = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.lblItemName = new System.Windows.Forms.Label();
            this.cbIsMultiThreaded = new System.Windows.Forms.CheckBox();
            this.txtRequestCode = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalRequests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConcurrentRequests)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTotalRequests
            // 
            this.txtTotalRequests.Location = new System.Drawing.Point(142, 39);
            this.txtTotalRequests.Name = "txtTotalRequests";
            this.txtTotalRequests.Size = new System.Drawing.Size(47, 20);
            this.txtTotalRequests.TabIndex = 23;
            this.txtTotalRequests.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtConcurrentRequests
            // 
            this.txtConcurrentRequests.Location = new System.Drawing.Point(145, 107);
            this.txtConcurrentRequests.Name = "txtConcurrentRequests";
            this.txtConcurrentRequests.Size = new System.Drawing.Size(50, 20);
            this.txtConcurrentRequests.TabIndex = 22;
            this.txtConcurrentRequests.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblMaxConcurrentThreads
            // 
            this.lblMaxConcurrentThreads.AutoSize = true;
            this.lblMaxConcurrentThreads.Location = new System.Drawing.Point(15, 107);
            this.lblMaxConcurrentThreads.Name = "lblMaxConcurrentThreads";
            this.lblMaxConcurrentThreads.Size = new System.Drawing.Size(124, 13);
            this.lblMaxConcurrentThreads.TabIndex = 21;
            this.lblMaxConcurrentThreads.Text = "Max Concurrent Threads";
            // 
            // lblTotalRequests
            // 
            this.lblTotalRequests.AutoSize = true;
            this.lblTotalRequests.Location = new System.Drawing.Point(12, 39);
            this.lblTotalRequests.Name = "lblTotalRequests";
            this.lblTotalRequests.Size = new System.Drawing.Size(79, 13);
            this.lblTotalRequests.TabIndex = 20;
            this.lblTotalRequests.Text = "Total Requests";
            // 
            // txtItemName
            // 
            this.txtItemName.ForeColor = System.Drawing.Color.Maroon;
            this.txtItemName.Location = new System.Drawing.Point(142, 13);
            this.txtItemName.MaxLength = 100;
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(326, 20);
            this.txtItemName.TabIndex = 24;
            this.txtItemName.Text = "Task Name";
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Location = new System.Drawing.Point(15, 13);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(58, 13);
            this.lblItemName.TabIndex = 25;
            this.lblItemName.Text = "Item Name";
            // 
            // cbIsMultiThreaded
            // 
            this.cbIsMultiThreaded.AutoSize = true;
            this.cbIsMultiThreaded.Location = new System.Drawing.Point(18, 87);
            this.cbIsMultiThreaded.Name = "cbIsMultiThreaded";
            this.cbIsMultiThreaded.Size = new System.Drawing.Size(135, 17);
            this.cbIsMultiThreaded.TabIndex = 26;
            this.cbIsMultiThreaded.Text = "Multi-Thread Execution";
            this.cbIsMultiThreaded.UseVisualStyleBackColor = true;
            // 
            // txtRequestCode
            // 
            this.txtRequestCode.Location = new System.Drawing.Point(15, 154);
            this.txtRequestCode.Multiline = true;
            this.txtRequestCode.Name = "txtRequestCode";
            this.txtRequestCode.ReadOnly = true;
            this.txtRequestCode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRequestCode.Size = new System.Drawing.Size(554, 150);
            this.txtRequestCode.TabIndex = 27;
            this.txtRequestCode.Text = resources.GetString("txtRequestCode.Text");
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(409, 320);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 28;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(490, 320);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 29;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 355);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtRequestCode);
            this.Controls.Add(this.cbIsMultiThreaded);
            this.Controls.Add(this.lblItemName);
            this.Controls.Add(this.txtItemName);
            this.Controls.Add(this.txtTotalRequests);
            this.Controls.Add(this.txtConcurrentRequests);
            this.Controls.Add(this.lblMaxConcurrentThreads);
            this.Controls.Add(this.lblTotalRequests);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalRequests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConcurrentRequests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown txtTotalRequests;
        private System.Windows.Forms.NumericUpDown txtConcurrentRequests;
        private System.Windows.Forms.Label lblMaxConcurrentThreads;
        private System.Windows.Forms.Label lblTotalRequests;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.CheckBox cbIsMultiThreaded;
        private System.Windows.Forms.TextBox txtRequestCode;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}