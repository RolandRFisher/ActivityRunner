using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using APITestLib;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace WFClient
{
    public partial class Form1 : Form
    {
        private int _lowerBound = 1;
        private int _upperBound = 100;
        private List<int> _Exclist;
        private ConcurrentQueue<TestRunnerQ> _concurrentQueue;
        private Stopwatch _stopwatch;
        private TimeSpan _ts;
        private long _sum;
        private ConcurrentQueue<TaskConfiguration> _items;


        public Form1()
        {
            InitializeComponent();

            Init();
        }

        private void Init()
        {
            _Exclist = new List<int>();
            _stopwatch = new Stopwatch();
            _items = new ConcurrentQueue<TaskConfiguration>();
            btnAddToTestList.Enabled = true;
        }

        //Reference-https://stackoverflow.com/questions/18746064/using-reflection-to-create-a-datatable-from-a-class
        private static DataTable CreateDataTable<T>(IEnumerable<T> list)
        {
            Type type = typeof(T);
            var properties = type.GetProperties();

            DataTable dataTable = new DataTable();
            foreach (PropertyInfo info in properties)
            {
                dataTable.Columns.Add(new DataColumn(info.Name, Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));
            }

            foreach (T entity in list)
            {
                object[] values = new object[properties.Length];
                for (int i = 0; i < properties.Length; i++)
                {
                    values[i] = properties[i].GetValue(entity);
                }

                dataTable.Rows.Add(values);
            }

            return dataTable;
        }

        ~Form1()
        {
            _stopwatch.Stop();
        }
        private void btnRun_Click(object sender, EventArgs e)
        {
            if (gvConfigurationSettings.DataSource == null)
            {
                Init();
                MessageBox.Show("Add Configuration First! \n\nClick the \">> Add >>\" button.");
            }
            else
            {
                _concurrentQueue = new ConcurrentQueue<TestRunnerQ>();

                var taskConfigurations = _items.ToArray().ToList();
                var totalRequests = taskConfigurations.Sum(s => s.TotalRequests);
                if (taskConfigurations.Any(configuration => configuration.IsRequestPerSecond))
                {
                    totalRequests = taskConfigurations[0].RequestPerSecond * 60;
                }

                try
                {
                    _Exclist.Clear();
                    btnSend.Enabled = false;
                    btnAddToTestList.Enabled = false;

                    _stopwatch.Stop();
                    _stopwatch.Reset();
                    _stopwatch.Start();
                    _ts = _stopwatch.Elapsed;

                    _upperBound = int.Parse(totalRequests.ToString());
                    pbProgress.Maximum = 100;
                    pbProgress.Step = 1;
                    pbProgress.Value = _lowerBound;
                    bwRequests.RunWorkerAsync();
                }


                catch (Exception)
                {
                    throw;
                }
            }
        }

        private void btnSendTest_Click(object sender, EventArgs e)
        {
            txtOutput.Text = JToken.Parse(SendRequestTest().Content).ToString(Formatting.Indented);
        }

        private void bwRequests_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var maxDegreeOfParallelism = 10;
            var options = new ParallelOptions() { MaxDegreeOfParallelism = maxDegreeOfParallelism };
            Parallel.For(0, _items.Count, options, i =>
            {
                TaskConfiguration t;
                _items.TryDequeue(out t);
                Execute(sender, t.ItemId, t.Name, t.MaxConcurrentThreads.ToString(), t.TotalRequests.ToString(), t.IsMultiThreadExecution, t.RequestCode, t.IsRequestPerSecond, t.RequestPerSecond, t.Durtion);
                _items.Enqueue(t);
            });


            //foreach (var t in _items)
            //{
            //    lock (t)
            //    {
            //        Execute(sender, t.ItemId, t.Name, t.MaxConcurrentThreads.ToString(), t.TotalRequests.ToString(), true, t.RequestCode);
            //    }
            //}

            //Execute(sender, txtConcurrentRequests.Text, txtTotalRequests.Text, cbIsMultiThreaded.Checked, RequestCode.Text);
        }

        private void Execute(object sender, int itemId, string taskName, string concurrentRequests, string totalRequests, bool isMultiThreaded, string requestCode, bool isRequestPerSecond, int requestPerSecond, int durtion)
        {
            var backgroundWorker = sender as BackgroundWorker;
            ExecuteRequest(backgroundWorker, itemId, taskName, int.Parse(concurrentRequests), (int.Parse(totalRequests)), isMultiThreaded, requestCode, isRequestPerSecond, requestPerSecond, durtion);
        }

        private void SingleThreaded(BackgroundWorker backgroundWorker)
        {
            for (int i = 1; i <= _upperBound; i++)
            {
                SendRequest();
                backgroundWorker?.ReportProgress(1);
            }
        }
        private IRestResponse SendRequestTest()
        {
            var requestCode = RequestCode.Text;
            APITestLib.Runner runner = new Runner();
            var restResponse = runner.SendRequest(requestCode);

            return restResponse;
        }

        private void SendRequest()
        {
            var requestCode = RequestCode.Text;
            APITestLib.Runner runner = new Runner();
            var restResponse = runner.SendRequest(requestCode);
        }

        private void ExecuteRequest(BackgroundWorker backgroundWorker, int itemId, string taskName, int maxThreads, int maxRequests, bool isMultiThreaded, string requestCode, bool isRequestPerSecond, int requestPerSecond, int durtion)
        {
            var runner = new Runner();

            if (isMultiThreaded && !isRequestPerSecond)
            {
                var maxDegreeOfParallelism = maxThreads == 0 ? 1 : maxThreads;
                var options = new ParallelOptions() { MaxDegreeOfParallelism = maxDegreeOfParallelism };

                Parallel.For(0, maxRequests, options, i =>
                 {
                     DoWork(backgroundWorker, itemId, taskName, maxThreads, maxRequests, runner, requestCode, i);
                 });
                //TaskMultiThreading(backgroundWorker, itemId, taskName, maxThreads, maxRequests, runner, requestCode);
            }
            else
            {
                if (isRequestPerSecond)
                {
                    var time = durtion * 1000 * 60;

                    while (time > 0)
                    {
                        for (int i = 1; i <= requestPerSecond; i++)
                        {
                            DoWork(backgroundWorker, itemId, taskName, maxThreads, maxRequests, runner, requestCode, i);
                        }
                        time -= 1000;
                        Thread.Sleep(1000);
                    }
                }
                else
                {
                    for (int i = 1; i <= maxRequests; i++)
                    {
                        DoWork(backgroundWorker, itemId, taskName, maxThreads, maxRequests, runner, requestCode, i);
                    }
                }



            }

        }

        private void TaskMultiThreading(BackgroundWorker backgroundWorker, int itemId, string taskName, int maxThreads, int maxRequests, Runner runner,
            string requestCode, bool isRequestPerSecond, int requestPerSecond, int durtion)
        {
            var tasks = new List<Task>(maxRequests);
            for (int i = 0; i < maxRequests; i++)
            {
                tasks.Add(Task.Factory.StartNew(() => DoWork(backgroundWorker, itemId, taskName, maxThreads, maxRequests, runner, requestCode, i)));
            }
            Task.WaitAll(tasks.ToArray());
        }

        private void ParallelMultiThreading(BackgroundWorker backgroundWorker, int itemId, string taskName, int maxThreads, int maxRequests, Runner runner,
            string requestCode)
        {
            Parallel.For(0, maxRequests, i => { DoWork(backgroundWorker, itemId, taskName, maxThreads, maxRequests, runner, requestCode, i); });
        }

        private void DoWork(BackgroundWorker backgroundWorker, int itemId, string taskName, int maxThreads, int maxRequests, Runner runner,
            string requestCode, int i)
        {
            var startDate = DateTime.Now;
            var sw = new Stopwatch();
            sw.Start();


            var restResponse = runner.SendRequest(requestCode);


            sw.Stop();
            var endDate = DateTime.Now;


            _concurrentQueue.Enqueue(new TestRunnerQ
            {
                ItemId = itemId,
                TaskName = taskName,
                Activity = $"Activity {i}",
                MaxThreads = maxThreads,
                MaxRequests = maxRequests,
                ExecuteId = i,
                IsSuccessful = restResponse.IsSuccessful,
                StartTime = startDate,
                EndTime = endDate,
                ElapsedMilliseconds = sw.ElapsedMilliseconds,
                ContentLength = restResponse.Content.Length,
            });
            backgroundWorker?.ReportProgress(1);
        }

        private void bwRequests_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            UpdateUi(e);
        }
        private void UpdateUi(ProgressChangedEventArgs e)
        {
            _Exclist.Add(e.ProgressPercentage);
            var progressValue = _Exclist.Sum(i => i);
            var percentage = (double)(progressValue * 100) / (double)_upperBound;
            pbProgress.Value = (int)percentage;
            lblPercentage.Text = (int)percentage + @"% Completed";
            lblTotalCompletedCount.Text = (progressValue).ToString() + @"/" + _upperBound.ToString();

            _sum = _stopwatch.ElapsedMilliseconds;
            TimeSpan t = TimeSpan.FromMilliseconds(_sum);

            lblTotalExecutionTime.Text = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", t.TotalHours, t.TotalMinutes, t.TotalSeconds, t.TotalMilliseconds);


            var dataTable = CreateDataTable(_concurrentQueue.ToList().ToList());
            UpdateResultsGridView(dataTable);

            if ((int)percentage != 100) return;

            btnSend.Enabled = true;
            btnAddToTestList.Enabled = true;
        }

        private void UpdateResultsGridView(DataTable dataTable)
        {
            if (chbDetailSummary.Checked)
            {
                PopulateSummary(dataTable);
                return;
            }
            gvResults.DataSource = dataTable;
            gvResults.DataMember = dataTable?.TableName;

            for (int i = 0; i < gvResults.Rows.Count; i++)
            {
                if (gvResults.Rows[i].Cells[0].Value == null) continue;

                if (!(bool)gvResults.Rows[i].Cells["IsSuccessful"].Value)
                {
                    gvResults.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
            }
            for (var i = 0; i < gvResults.Columns.Count; i++)
            {
                gvResults.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            for (var i = 0; i < gvConfigurationSettings.Columns.Count; i++)
            {
                gvConfigurationSettings.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void bwRequests_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnSend.Enabled = true;
            btnSendTest.Enabled = true;
        }

        private void txtConcurrentRequests_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblMaxConcurrentThreads_Click(object sender, EventArgs e)
        {

        }

        private void btnAddToTestList_Click(object sender, EventArgs e)
        {
            PopulateCofigurationGrid();
        }

        private void PopulateCofigurationGrid()
        {
            Form2 frm = new Form2();
            frm.RequestCode = RequestCode.Text;
            RequestCode.Text = string.Empty;
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                _items.Enqueue(
                    new TaskConfiguration()
                    {
                        ItemId = _items.Count + 1,
                        Name = frm.ItemName,
                        MaxConcurrentThreads = frm.ConcurrentRequests,
                        TotalRequests = frm.TotalRequests,
                        IsMultiThreadExecution = frm.IsMultiThreaded,
                        RequestCode = frm.RequestCode,
                        IsRequestPerSecond = frm.IsRequestPerSecond,
                        RequestPerSecond = frm.RequestPerSecond,
                        Durtion = frm.Durtion,
                    });
            }
            frm.Dispose();

            var dataTable = CreateDataTable(_items);
            gvConfigurationSettings.DataSource = dataTable;
            gvConfigurationSettings.DataMember = dataTable.TableName;
        }

        private void btnClearRequestCode_Click(object sender, EventArgs e)
        {
            RequestCode.Text = string.Empty;
        }

        private void btnClearConfigGrid_Click(object sender, EventArgs e)
        {
            gvConfigurationSettings.DataSource = null;
            gvConfigurationSettings.DataMember = string.Empty;
            for (int i = 0; i <= _items.Count; i++)
            {
                TaskConfiguration t = new TaskConfiguration();
                _items.TryDequeue(out t);
            }

            var dt = gvResults.DataSource as DataTable;
            if (dt != null)
            {
                dt.Clear();
                gvResults.DataSource = null;
            }
            gvResults.DataMember = string.Empty;
        }

        private void btnExportConfiguration_Click(object sender, EventArgs e)
        {
            ExportToCsv(gvConfigurationSettings);
        }

        private void btnExportResults_Click(object sender, EventArgs e)
        {
            ExportToCsv(gvResults);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        /// <summary> 
        /// Exports the datagridview values to Excel. 
        /// </summary> 
        private void ExportToCsv(DataGridView gridview, string format = "csv")
        {
            var result = string.Empty;


            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "CSV|*.csv|JSON|*.json|All files (*.*)|*.*";
                dialog.FilterIndex = 1;
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    switch (dialog.FilterIndex)
                    {
                        case 1:
                            result = GetCsvString(gridview);
                            break;
                        case 2:
                            result = JsonConvert.SerializeObject(gridview.DataSource as DataTable, Formatting.Indented);
                            break;
                    }
                    File.WriteAllText(dialog.FileName, result);
                }
            }
        }

        private static string GetCsvString(DataGridView gridview)
        {
            var sb = new StringBuilder();

            var headers = gridview.Columns.Cast<DataGridViewColumn>();
            sb.AppendLine(string.Join(",", headers.Select(column => "\"" + column.HeaderText + "\"").ToArray()));

            foreach (DataGridViewRow row in gridview.Rows)
            {
                var cells = row.Cells.Cast<DataGridViewCell>();
                sb.AppendLine(string.Join(",", cells.Select(cell => "\"" + cell.Value + "\"").ToArray()));
            }

            return sb.ToString();
        }

        private void chbDetailSummary_CheckedChanged(object sender, EventArgs e)
        {
            if (_concurrentQueue == null) return;

            if (chbDetailSummary.Checked)
            {
                var dataTable = CreateDataTable(_concurrentQueue.ToList().ToList());
                PopulateSummary(dataTable);
            }
            else
            {
                var dataTable = CreateDataTable(_concurrentQueue.ToList().ToList());
                UpdateResultsGridView(dataTable);
            }
        }

        private void PopulateSummary(DataTable dt)
        {
            List<TestRunnerQ> testRunnerQs = new List<TestRunnerQ>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TestRunnerQ tr = new TestRunnerQ();
                foreach (DataColumn column in dt.Columns)
                {
                    var propertyInfos = tr.GetType().GetProperties();
                    foreach (var propertyInfo in propertyInfos)
                    {
                        if (propertyInfo.Name == column.ColumnName)
                        {
                            propertyInfo.SetValue(tr, dt.Rows[i][column.ColumnName]);
                        }
                    }
                }
                testRunnerQs.Add(tr);
            }

            if (testRunnerQs != null)
            {
                var query = testRunnerQs
                    .GroupBy(g => new
                    {
                        g.ItemId,
                        g.TaskName
                    })
                    .Select(group => new
                    {
                        ItemId = @group.Key.ItemId,
                        TaskName = @group.Key.TaskName,
                        CumulativeElapsedMilliseconds = @group.Sum(a => a.ElapsedMilliseconds),
                        AverageElapsedMilliseconds = Math.Round(@group.Average(a => a.ElapsedMilliseconds),2),
                        Slowest = @group.Max(a => a.ElapsedMilliseconds),
                        Fastest = @group.Min(a => a.ElapsedMilliseconds),
                        Completed = @group.Count()
                    });

                gvResults.DataSource = query.ToList();
                gvResults.DataMember = string.Empty;
            }
        }
    }
}
