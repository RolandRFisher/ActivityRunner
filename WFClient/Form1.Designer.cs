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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.RequestCode = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.gvResults = new System.Windows.Forms.DataGridView();
            this.btnAddToTestList = new System.Windows.Forms.Button();
            this.bwRequests = new System.ComponentModel.BackgroundWorker();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.lblPercentage = new System.Windows.Forms.Label();
            this.lblTotalCompletedCount = new System.Windows.Forms.Label();
            this.btnSendTest = new System.Windows.Forms.Button();
            this.gvConfigurationSettings = new System.Windows.Forms.DataGridView();
            this.lblTotalExecutionTime = new System.Windows.Forms.Label();
            this.btnClearRequestCode = new System.Windows.Forms.Button();
            this.btnClearConfigGrid = new System.Windows.Forms.Button();
            this.btnExportResults = new System.Windows.Forms.Button();
            this.btnExportConfiguration = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.chbDetailSummary = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvConfigurationSettings)).BeginInit();
            this.SuspendLayout();
            // 
            // RequestCode
            // 
            this.RequestCode.Location = new System.Drawing.Point(12, 17);
            this.RequestCode.Multiline = true;
            this.RequestCode.Name = "RequestCode";
            this.RequestCode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.RequestCode.Size = new System.Drawing.Size(554, 150);
            this.RequestCode.TabIndex = 0;
            this.RequestCode.Text = resources.GetString("RequestCode.Text");
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(653, 173);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Run All";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(12, 202);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(550, 109);
            this.txtOutput.TabIndex = 4;
            // 
            // gvResults
            // 
            this.gvResults.AllowUserToOrderColumns = true;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvResults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.gvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvResults.DefaultCellStyle = dataGridViewCellStyle20;
            this.gvResults.Location = new System.Drawing.Point(12, 360);
            this.gvResults.Name = "gvResults";
            this.gvResults.ReadOnly = true;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvResults.RowHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.gvResults.Size = new System.Drawing.Size(1291, 338);
            this.gvResults.TabIndex = 5;
            // 
            // btnAddToTestList
            // 
            this.btnAddToTestList.Location = new System.Drawing.Point(572, 53);
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
            this.pbProgress.Location = new System.Drawing.Point(1031, 751);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(284, 23);
            this.pbProgress.TabIndex = 7;
            // 
            // lblPercentage
            // 
            this.lblPercentage.AutoSize = true;
            this.lblPercentage.BackColor = System.Drawing.Color.Transparent;
            this.lblPercentage.ForeColor = System.Drawing.Color.Red;
            this.lblPercentage.Location = new System.Drawing.Point(1037, 757);
            this.lblPercentage.Name = "lblPercentage";
            this.lblPercentage.Size = new System.Drawing.Size(13, 13);
            this.lblPercentage.TabIndex = 8;
            this.lblPercentage.Text = "0";
            // 
            // lblTotalCompletedCount
            // 
            this.lblTotalCompletedCount.AutoSize = true;
            this.lblTotalCompletedCount.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCompletedCount.ForeColor = System.Drawing.Color.Red;
            this.lblTotalCompletedCount.Location = new System.Drawing.Point(939, 754);
            this.lblTotalCompletedCount.Name = "lblTotalCompletedCount";
            this.lblTotalCompletedCount.Size = new System.Drawing.Size(35, 18);
            this.lblTotalCompletedCount.TabIndex = 11;
            this.lblTotalCompletedCount.Text = "0/0";
            // 
            // btnSendTest
            // 
            this.btnSendTest.Location = new System.Drawing.Point(12, 173);
            this.btnSendTest.Name = "btnSendTest";
            this.btnSendTest.Size = new System.Drawing.Size(75, 23);
            this.btnSendTest.TabIndex = 12;
            this.btnSendTest.Text = "Test";
            this.btnSendTest.UseVisualStyleBackColor = true;
            this.btnSendTest.Click += new System.EventHandler(this.btnSendTest_Click);
            // 
            // gvConfigurationSettings
            // 
            this.gvConfigurationSettings.AllowUserToOrderColumns = true;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvConfigurationSettings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.gvConfigurationSettings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvConfigurationSettings.DefaultCellStyle = dataGridViewCellStyle23;
            this.gvConfigurationSettings.Location = new System.Drawing.Point(653, 17);
            this.gvConfigurationSettings.Name = "gvConfigurationSettings";
            this.gvConfigurationSettings.ReadOnly = true;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvConfigurationSettings.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.gvConfigurationSettings.Size = new System.Drawing.Size(641, 150);
            this.gvConfigurationSettings.TabIndex = 14;
            // 
            // lblTotalExecutionTime
            // 
            this.lblTotalExecutionTime.AutoSize = true;
            this.lblTotalExecutionTime.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalExecutionTime.ForeColor = System.Drawing.Color.Red;
            this.lblTotalExecutionTime.Location = new System.Drawing.Point(12, 753);
            this.lblTotalExecutionTime.Name = "lblTotalExecutionTime";
            this.lblTotalExecutionTime.Size = new System.Drawing.Size(18, 18);
            this.lblTotalExecutionTime.TabIndex = 15;
            this.lblTotalExecutionTime.Text = "0";
            // 
            // btnClearRequestCode
            // 
            this.btnClearRequestCode.Location = new System.Drawing.Point(93, 173);
            this.btnClearRequestCode.Name = "btnClearRequestCode";
            this.btnClearRequestCode.Size = new System.Drawing.Size(75, 23);
            this.btnClearRequestCode.TabIndex = 20;
            this.btnClearRequestCode.Text = "Clear Input";
            this.btnClearRequestCode.UseVisualStyleBackColor = true;
            this.btnClearRequestCode.Click += new System.EventHandler(this.btnClearRequestCode_Click);
            // 
            // btnClearConfigGrid
            // 
            this.btnClearConfigGrid.Location = new System.Drawing.Point(572, 82);
            this.btnClearConfigGrid.Name = "btnClearConfigGrid";
            this.btnClearConfigGrid.Size = new System.Drawing.Size(75, 23);
            this.btnClearConfigGrid.TabIndex = 21;
            this.btnClearConfigGrid.Text = "Clear Grids";
            this.btnClearConfigGrid.UseVisualStyleBackColor = true;
            this.btnClearConfigGrid.Click += new System.EventHandler(this.btnClearConfigGrid_Click);
            // 
            // btnExportResults
            // 
            this.btnExportResults.Location = new System.Drawing.Point(1182, 704);
            this.btnExportResults.Name = "btnExportResults";
            this.btnExportResults.Size = new System.Drawing.Size(121, 23);
            this.btnExportResults.TabIndex = 22;
            this.btnExportResults.Text = "Export Results...";
            this.btnExportResults.UseVisualStyleBackColor = true;
            this.btnExportResults.Click += new System.EventHandler(this.btnExportResults_Click);
            // 
            // btnExportConfiguration
            // 
            this.btnExportConfiguration.Location = new System.Drawing.Point(1182, 173);
            this.btnExportConfiguration.Name = "btnExportConfiguration";
            this.btnExportConfiguration.Size = new System.Drawing.Size(112, 23);
            this.btnExportConfiguration.TabIndex = 23;
            this.btnExportConfiguration.Text = "Export Config...";
            this.btnExportConfiguration.UseVisualStyleBackColor = true;
            this.btnExportConfiguration.Click += new System.EventHandler(this.btnExportConfiguration_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(1055, 173);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 23);
            this.button1.TabIndex = 24;
            this.button1.Text = "Import Configuration";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chbDetailSummary
            // 
            this.chbDetailSummary.AutoSize = true;
            this.chbDetailSummary.Checked = true;
            this.chbDetailSummary.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbDetailSummary.Location = new System.Drawing.Point(13, 337);
            this.chbDetailSummary.Name = "chbDetailSummary";
            this.chbDetailSummary.Size = new System.Drawing.Size(69, 17);
            this.chbDetailSummary.TabIndex = 25;
            this.chbDetailSummary.Text = "Summary";
            this.chbDetailSummary.UseVisualStyleBackColor = true;
            this.chbDetailSummary.CheckedChanged += new System.EventHandler(this.chbDetailSummary_CheckedChanged);
            // 
            // Form1
            // 
            this.AcceptButton = this.btnSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1315, 781);
            this.Controls.Add(this.chbDetailSummary);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnExportConfiguration);
            this.Controls.Add(this.btnExportResults);
            this.Controls.Add(this.btnClearConfigGrid);
            this.Controls.Add(this.btnClearRequestCode);
            this.Controls.Add(this.lblTotalExecutionTime);
            this.Controls.Add(this.gvConfigurationSettings);
            this.Controls.Add(this.btnSendTest);
            this.Controls.Add(this.lblTotalCompletedCount);
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
        private System.Windows.Forms.Label lblTotalCompletedCount;
        private System.Windows.Forms.Button btnSendTest;
        private System.Windows.Forms.DataGridView gvConfigurationSettings;
        private System.Windows.Forms.Label lblTotalExecutionTime;
        private System.Windows.Forms.Button btnClearRequestCode;
        private System.Windows.Forms.Button btnClearConfigGrid;
        private System.Windows.Forms.Button btnExportResults;
        private System.Windows.Forms.Button btnExportConfiguration;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chbDetailSummary;
    }
}

