using System;
using System.ComponentModel;
using System.Runtime.Remoting.Channels;
using RestSharp;

namespace WFClient
{
    public class TestRunnerQ
    {
        public int ItemId { get; set; }
        public string TaskName { get; set; }
        public string Activity { get; set; }
        public int MaxThreads { get; set; }
        public int MaxRequests { get; set; }
        public int ExecuteId { get; set; }
        public bool IsSuccessful { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public float ElapsedMilliseconds { get; set; }
        public long ContentLength { get; set; }
    }
}