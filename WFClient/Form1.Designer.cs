namespace WFClient
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.RequestCode = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.gvResults = new System.Windows.Forms.DataGridView();
            this.btnAddToTestList = new System.Windows.Forms.Button();
            this.bwRequests = new System.ComponentModel.BackgroundWorker();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.lblPercentage = new System.Windows.Forms.Label();
            this.lblTotalRequests = new System.Windows.Forms.Label();
            this.lblTotalCompletedCount = new System.Windows.Forms.Label();
            this.btnSendTest = new System.Windows.Forms.Button();
            this.cbIsMultiThreaded = new System.Windows.Forms.CheckBox();
            this.gvConfigurationSettings = new System.Windows.Forms.DataGridView();
            this.lblTotalExecutionTime = new System.Windows.Forms.Label();
            this.lblMaxConcurrentThreads = new System.Windows.Forms.Label();
            this.txtConcurrentRequests = new System.Windows.Forms.NumericUpDown();
            this.txtTotalRequests = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.gvResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvConfigurationSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConcurrentRequests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalRequests)).BeginInit();
            this.SuspendLayout();
            // 
            // RequestCode
            // 
            this.RequestCode.Location = new System.Drawing.Point(12, 152);
            this.RequestCode.Multiline = true;
            this.RequestCode.Name = "RequestCode";
            this.RequestCode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.RequestCode.Size = new System.Drawing.Size(554, 150);
            this.RequestCode.TabIndex = 0;
            this.RequestCode.Text = resources.GetString("RequestCode.Text");
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(653, 317);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Send All";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(12, 346);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(550, 146);
            this.txtOutput.TabIndex = 4;
            // 
            // gvResults
            // 
            this.gvResults.AllowUserToOrderColumns = true;
            this.gvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvResults.Location = new System.Drawing.Point(12, 600);
            this.gvResults.Name = "gvResults";
            this.gvResults.Size = new System.Drawing.Size(1291, 209);
            this.gvResults.TabIndex = 5;
            // 
            // btnAddToTestList
            // 
            this.btnAddToTestList.Location = new System.Drawing.Point(572, 188);
            this.btnAddToTestList.Name = "btnAddToTestList";
            this.btnAddToTestList.Size = new System.Drawing.Size(75, 23);
            this.btnAddToTestList.TabIndex = 6;
            this.btnAddToTestList.Text = ">> Add >>";
            this.btnAddToTestList.UseVisualStyleBackColor = true;
            this.btnAddToTestList.Click += new System.EventHandler(this.btnAddToTestList_Click);
            // 
            // bwRequests
            // 
            this.bwRequests.WorkerReportsProgress = true;
            this.bwRequests.WorkerSupportsCancellation = true;
            this.bwRequests.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwRequests_DoWork);
            this.bwRequests.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwRequests_ProgressChanged);
            this.bwRequests.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwRequests_RunWorkerCompleted);
            // 
            // pbProgress
            // 
            this.pbProgress.Location = new System.Drawing.Point(1031, 819);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(284, 23);
            this.pbProgress.TabIndex = 7;
            // 
            // lblPercentage
            // 
            this.lblPercentage.AutoSize = true;
            this.lblPercentage.BackColor = System.Drawing.Color.Transparent;
            this.lblPercentage.ForeColor = System.Drawing.Color.Red;
            this.lblPercentage.Location = new System.Drawing.Point(1037, 825);
            this.lblPercentage.Name = "lblPercentage";
            this.lblPercentage.Size = new System.Drawing.Size(13, 13);
            this.lblPercentage.TabIndex = 8;
            this.lblPercentage.Text = "0";
            // 
            // lblTotalRequests
            // 
            this.lblTotalRequests.AutoSize = true;
            this.lblTotalRequests.Location = new System.Drawing.Point(1062, 322);
            this.lblTotalRequests.Name = "lblTotalRequests";
            this.lblTotalRequests.Size = new System.Drawing.Size(79, 13);
            this.lblTotalRequests.TabIndex = 10;
            this.lblTotalRequests.Text = "Total Requests";
            // 
            // lblTotalCompletedCount
            // 
            this.lblTotalCompletedCount.AutoSize = true;
            this.lblTotalCompletedCount.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCompletedCount.ForeColor = System.Drawing.Color.Red;
            this.lblTotalCompletedCount.Location = new System.Drawing.Point(939, 822);
            this.lblTotalCompletedCount.Name = "lblTotalCompletedCount";
            this.lblTotalCompletedCount.Size = new System.Drawing.Size(35, 18);
            this.lblTotalCompletedCount.TabIndex = 11;
            this.lblTotalCompletedCount.Text = "0/0";
            // 
            // btnSendTest
            // 
            this.btnSendTest.Location = new System.Drawing.Point(12, 317);
            this.btnSendTest.Name = "btnSendTest";
            this.btnSendTest.Size = new System.Drawing.Size(75, 23);
            this.btnSendTest.TabIndex = 12;
            this.btnSendTest.Text = "Send";
            this.btnSendTest.UseVisualStyleBackColor = true;
            this.btnSendTest.Click += new System.EventHandler(this.btnSendTest_Click);
            // 
            // cbIsMultiThreaded
            // 
            this.cbIsMultiThreaded.AutoSize = true;
            this.cbIsMultiThreaded.Location = new System.Drawing.Point(735, 320);
            this.cbIsMultiThreaded.Name = "cbIsMultiThreaded";
            this.cbIsMultiThreaded.Size = new System.Drawing.Size(135, 17);
            this.cbIsMultiThreaded.TabIndex = 13;
            this.cbIsMultiThreaded.Text = "Multi-Thread Execution";
            this.cbIsMultiThreaded.UseVisualStyleBackColor = true;
            // 
            // gvConfigurationSettings
            // 
            this.gvConfigurationSettings.AllowUserToOrderColumns = true;
            this.gvConfigurationSettings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvConfigurationSettings.Location = new System.Drawing.Point(653, 152);
            this.gvConfigurationSettings.Name = "gvConfigurationSettings";
            this.gvConfigurationSettings.Size = new System.Drawing.Size(641, 150);
            this.gvConfigurationSettings.TabIndex = 14;
            // 
            // lblTotalExecutionTime
            // 
            this.lblTotalExecutionTime.AutoSize = true;
            this.lblTotalExecutionTime.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalExecutionTime.ForeColor = System.Drawing.Color.Red;
            this.lblTotalExecutionTime.Location = new System.Drawing.Point(12, 821);
            this.lblTotalExecutionTime.Name = "lblTotalExecutionTime";
            this.lblTotalExecutionTime.Size = new System.Drawing.Size(18, 18);
            this.lblTotalExecutionTime.TabIndex = 15;
            this.lblTotalExecutionTime.Text = "0";
            // 
            // lblMaxConcurrentThreads
            // 
            this.lblMaxConcurrentThreads.AutoSize = true;
            this.lblMaxConcurrentThreads.Location = new System.Drawing.Point(876, 322);
            this.lblMaxConcurrentThreads.Name = "lblMaxConcurrentThreads";
            this.lblMaxConcurrentThreads.Size = new System.Drawing.Size(124, 13);
            this.lblMaxConcurrentThreads.TabIndex = 16;
            this.lblMaxConcurrentThreads.Text = "Max Concurrent Threads";
            this.lblMaxConcurrentThreads.Click += new System.EventHandler(this.lblMaxConcurrentThreads_Click);
            // 
            // txtConcurrentRequests
            // 
            this.txtConcurrentRequests.Location = new System.Drawing.Point(1000, 320);
            this.txtConcurrentRequests.Name = "txtConcurrentRequests";
            this.txtConcurrentRequests.Size = new System.Drawing.Size(50, 20);
            this.txtConcurrentRequests.TabIndex = 18;
            this.txtConcurrentRequests.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtTotalRequests
            // 
            this.txtTotalRequests.Location = new System.Drawing.Point(1147, 320);
            this.txtTotalRequests.Name = "txtTotalRequests";
            this.txtTotalRequests.Size = new System.Drawing.Size(47, 20);
            this.txtTotalRequests.TabIndex = 19;
            this.txtTotalRequests.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1315, 842);
            this.Controls.Add(this.txtTotalRequests);
            this.Controls.Add(this.txtConcurrentRequests);
            this.Controls.Add(this.lblMaxConcurrentThreads);
            this.Controls.Add(this.lblTotalExecutionTime);
            this.Controls.Add(this.gvConfigurationSettings);
            this.Controls.Add(this.cbIsMultiThreaded);
            this.Controls.Add(this.btnSendTest);
            this.Controls.Add(this.lblTotalCompletedCount);
            this.Controls.Add(this.lblTotalRequests);
            this.Controls.Add(this.lblPercentage);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.btnAddToTestList);
            this.Controls.Add(this.gvResults);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.RequestCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.gvResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvConfigurationSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConcurrentRequests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalRequests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox RequestCode;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.DataGridView gvResults;
        private System.Windows.Forms.Button btnAddToTestList;
        private System.ComponentModel.BackgroundWorker bwRequests;
        private System.Windows.Forms.ProgressBar pbProgress;
        private System.Windows.Forms.Label lblPercentage;
        private System.Windows.Forms.Label lblTotalRequests;
        private System.Windows.Forms.Label lblTotalCompletedCount;
        private System.Windows.Forms.Button btnSendTest;
        private System.Windows.Forms.CheckBox cbIsMultiThreaded;
        private System.Windows.Forms.DataGridView gvConfigurationSettings;
        private System.Windows.Forms.Label lblTotalExecutionTime;
        private System.Windows.Forms.Label lblMaxConcurrentThreads;
        private System.Windows.Forms.NumericUpDown txtConcurrentRequests;
        private System.Windows.Forms.NumericUpDown txtTotalRequests;
    }
}

