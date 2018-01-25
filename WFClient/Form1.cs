using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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
        private List<TaskConfiguration> _items;


        public Form1()
        {
            InitializeComponent();

            Init();
        }

        private void Init()
        {
            _Exclist = new List<int>();
            _stopwatch = new Stopwatch();
            _items = new List<TaskConfiguration>();

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
            try
            {
                _Exclist.Clear();
                btnSend.Enabled = false;
                btnAddToTestList.Enabled = false;

                _stopwatch.Stop();
                _stopwatch.Reset();
                _stopwatch.Start();
                _ts = _stopwatch.Elapsed;

                _upperBound = int.Parse(txtTotalRequests.Text);
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

        private void btnSendTest_Click(object sender, EventArgs e)
        {
            txtOutput.Text = JToken.Parse(SendRequestTest().Content).ToString(Formatting.Indented);
        }
        private void bwRequests_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var backgroundWorker = sender as BackgroundWorker;

            ExecuteRequest(backgroundWorker, int.Parse(txtConcurrentRequests.Text), (int.Parse(txtTotalRequests.Text)), cbIsMultiThreaded.Checked);
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

        private void ExecuteRequest(BackgroundWorker backgroundWorker, int maxThreads, int maxRequests, bool isMultiThreaded)
        {
            _concurrentQueue = new ConcurrentQueue<TestRunnerQ>();
            var requestCode = RequestCode.Text;
            var runner = new Runner();

            if (isMultiThreaded)
            {
                var maxDegreeOfParallelism = maxThreads == 0 ? 1 : maxThreads;
                var options = new ParallelOptions() { MaxDegreeOfParallelism = maxDegreeOfParallelism };

                Parallel.For(0, maxRequests, options, i =>
                 {
                     DoWork(backgroundWorker, maxThreads, maxRequests, runner, requestCode, i);
                 });
                //TaskMultiThreading(backgroundWorker, maxThreads, maxRequests, runner, requestCode);
            }
            else
            {
                for (int i = 1; i <= maxRequests; i++)
                {
                    DoWork(backgroundWorker, maxThreads, maxRequests, runner, requestCode, i);
                }
            }

        }

        private void TaskMultiThreading(BackgroundWorker backgroundWorker, int maxThreads, int maxRequests, Runner runner,
            string requestCode)
        {
            var tasks = new List<Task>(maxRequests);
            for (int i = 0; i < maxRequests; i++)
            {
                tasks.Add(Task.Factory.StartNew(() => DoWork(backgroundWorker, maxThreads, maxRequests, runner, requestCode, i)));
            }
            Task.WaitAll(tasks.ToArray());
        }

        private void ParallelMultiThreading(BackgroundWorker backgroundWorker, int maxThreads, int maxRequests, Runner runner,
            string requestCode)
        {
            Parallel.For(0, maxRequests, i => { DoWork(backgroundWorker, maxThreads, maxRequests, runner, requestCode, i); });
        }

        private void DoWork(BackgroundWorker backgroundWorker, int maxThreads, int maxRequests, Runner runner,
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
                TaskName = $"Activity {i}", //TODO: Get Custom Name from UI.
                MaxThreads = maxThreads,
                MaxRequests = maxRequests,
                ExecuteId = i,
                IsSuccessful = restResponse.IsSuccessful,
                StartTime = startDate,
                EndTime = endDate,
                ElapsedMilliseconds = sw.ElapsedMilliseconds
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
            UpdateDataGridView(dataTable);

            if ((int)percentage != 100) return;

            btnSend.Enabled = true;
            btnAddToTestList.Enabled = true;
        }

        private void UpdateDataGridView(DataTable dataTable)
        {
            gvResults.DataSource = dataTable;
            gvResults.DataMember = dataTable.TableName;
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
            PopulateCifigurationGrid();
        }

        private void PopulateCifigurationGrid()
        {
            Form2 frm = new Form2();
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                _items.Add(
                    new TaskConfiguration()
                    {
                        ItemId = _items.Count + 1,
                        Name = frm.ItemName,
                        MaxConcurrentThreads = frm.ConcurrentRequests,
                        TotalRequests = frm.TotalRequests,
                        IsMultiThreadExecution = frm.IsMultiThreaded,
                        RequestCode = frm.RequestCode
                    });
            }
            frm.Dispose();

            var dataTable = CreateDataTable(_items);
            gvConfigurationSettings.DataSource = dataTable;
            gvConfigurationSettings.DataMember = dataTable.TableName;
        }
    }
}
