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
            this.chbRequestPerSecond = new System.Windows.Forms.CheckBox();
            this.pnlStandardRequests = new System.Windows.Forms.Panel();
            this.pnlRequestPerSecond = new System.Windows.Forms.Panel();
            this.txtRequestPerSecond = new System.Windows.Forms.NumericUpDown();
            this.lblRequestPerSecond = new System.Windows.Forms.Label();
            this.txtDurtion = new System.Windows.Forms.NumericUpDown();
            this.lblDuration = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalRequests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConcurrentRequests)).BeginInit();
            this.pnlStandardRequests.SuspendLayout();
            this.pnlRequestPerSecond.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRequestPerSecond)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDurtion)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTotalRequests
            // 
            this.txtTotalRequests.Location = new System.Drawing.Point(133, 19);
            this.txtTotalRequests.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtTotalRequests.Name = "txtTotalRequests";
            this.txtTotalRequests.Size = new System.Drawing.Size(47, 20);
            this.txtTotalRequests.TabIndex = 23;
            this.txtTotalRequests.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // txtConcurrentRequests
            // 
            this.txtConcurrentRequests.Location = new System.Drawing.Point(136, 65);
            this.txtConcurrentRequests.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
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
            this.lblMaxConcurrentThreads.Location = new System.Drawing.Point(6, 65);
            this.lblMaxConcurrentThreads.Name = "lblMaxConcurrentThreads";
            this.lblMaxConcurrentThreads.Size = new System.Drawing.Size(124, 13);
            this.lblMaxConcurrentThreads.TabIndex = 21;
            this.lblMaxConcurrentThreads.Text = "Max Concurrent Threads";
            // 
            // lblTotalRequests
            // 
            this.lblTotalRequests.AutoSize = true;
            this.lblTotalRequests.Location = new System.Drawing.Point(3, 19);
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
            this.cbIsMultiThreaded.Location = new System.Drawing.Point(9, 45);
            this.cbIsMultiThreaded.Name = "cbIsMultiThreaded";
            this.cbIsMultiThreaded.Size = new System.Drawing.Size(135, 17);
            this.cbIsMultiThreaded.TabIndex = 26;
            this.cbIsMultiThreaded.Text = "Multi-Thread Execution";
            this.cbIsMultiThreaded.UseVisualStyleBackColor = true;
            this.cbIsMultiThreaded.CheckedChanged += new System.EventHandler(this.cbIsMultiThreaded_CheckedChanged);
            // 
            // txtRequestCode
            // 
            this.txtRequestCode.Location = new System.Drawing.Point(15, 188);
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
            this.btnOk.Location = new System.Drawing.Point(409, 354);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 28;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            this.btnOk.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnOk_KeyDown);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(490, 354);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 29;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chbRequestPerSecond
            // 
            this.chbRequestPerSecond.AutoSize = true;
            this.chbRequestPerSecond.Checked = true;
            this.chbRequestPerSecond.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbRequestPerSecond.Location = new System.Drawing.Point(236, 39);
            this.chbRequestPerSecond.Name = "chbRequestPerSecond";
            this.chbRequestPerSecond.Size = new System.Drawing.Size(122, 17);
            this.chbRequestPerSecond.TabIndex = 30;
            this.chbRequestPerSecond.Text = "Request per second";
            this.chbRequestPerSecond.UseVisualStyleBackColor = true;
            this.chbRequestPerSecond.CheckedChanged += new System.EventHandler(this.chbRequestPerSecond_CheckedChanged);
            // 
            // pnlStandardRequests
            // 
            this.pnlStandardRequests.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlStandardRequests.Controls.Add(this.lblTotalRequests);
            this.pnlStandardRequests.Controls.Add(this.lblMaxConcurrentThreads);
            this.pnlStandardRequests.Controls.Add(this.txtConcurrentRequests);
            this.pnlStandardRequests.Controls.Add(this.txtTotalRequests);
            this.pnlStandardRequests.Controls.Add(this.cbIsMultiThreaded);
            this.pnlStandardRequests.Location = new System.Drawing.Point(18, 66);
            this.pnlStandardRequests.Name = "pnlStandardRequests";
            this.pnlStandardRequests.Size = new System.Drawing.Size(200, 100);
            this.pnlStandardRequests.TabIndex = 31;
            // 
            // pnlRequestPerSecond
            // 
            this.pnlRequestPerSecond.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlRequestPerSecond.Controls.Add(this.lblDuration);
            this.pnlRequestPerSecond.Controls.Add(this.txtDurtion);
            this.pnlRequestPerSecond.Controls.Add(this.lblRequestPerSecond);
            this.pnlRequestPerSecond.Controls.Add(this.txtRequestPerSecond);
            this.pnlRequestPerSecond.Location = new System.Drawing.Point(236, 65);
            this.pnlRequestPerSecond.Name = "pnlRequestPerSecond";
            this.pnlRequestPerSecond.Size = new System.Drawing.Size(200, 100);
            this.pnlRequestPerSecond.TabIndex = 32;
            // 
            // txtRequestPerSecond
            // 
            this.txtRequestPerSecond.Location = new System.Drawing.Point(6, 17);
            this.txtRequestPerSecond.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtRequestPerSecond.Name = "txtRequestPerSecond";
            this.txtRequestPerSecond.Size = new System.Drawing.Size(47, 20);
            this.txtRequestPerSecond.TabIndex = 27;
            this.txtRequestPerSecond.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblRequestPerSecond
            // 
            this.lblRequestPerSecond.AutoSize = true;
            this.lblRequestPerSecond.Location = new System.Drawing.Point(59, 19);
            this.lblRequestPerSecond.Name = "lblRequestPerSecond";
            this.lblRequestPerSecond.Size = new System.Drawing.Size(111, 13);
            this.lblRequestPerSecond.TabIndex = 27;
            this.lblRequestPerSecond.Text = "Requests Per Second";
            // 
            // txtDurtion
            // 
            this.txtDurtion.Location = new System.Drawing.Point(6, 45);
            this.txtDurtion.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtDurtion.Name = "txtDurtion";
            this.txtDurtion.Size = new System.Drawing.Size(47, 20);
            this.txtDurtion.TabIndex = 31;
            this.txtDurtion.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(59, 47);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(92, 13);
            this.lblDuration.TabIndex = 32;
            this.lblDuration.Text = "Duration (minutes)";
            // 
            // Form2
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(589, 396);
            this.Controls.Add(this.pnlRequestPerSecond);
            this.Controls.Add(this.pnlStandardRequests);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.chbRequestPerSecond);
            this.Controls.Add(this.txtRequestCode);
            this.Controls.Add(this.lblItemName);
            this.Controls.Add(this.txtItemName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalRequests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConcurrentRequests)).EndInit();
            this.pnlStandardRequests.ResumeLayout(false);
            this.pnlStandardRequests.PerformLayout();
            this.pnlRequestPerSecond.ResumeLayout(false);
            this.pnlRequestPerSecond.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRequestPerSecond)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDurtion)).EndInit();
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
        private System.Windows.Forms.CheckBox chbRequestPerSecond;
        private System.Windows.Forms.Panel pnlStandardRequests;
        private System.Windows.Forms.Panel pnlRequestPerSecond;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.NumericUpDown txtDurtion;
        private System.Windows.Forms.Label lblRequestPerSecond;
        private System.Windows.Forms.NumericUpDown txtRequestPerSecond;
    }
}