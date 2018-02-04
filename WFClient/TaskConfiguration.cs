namespace WFClient
{
    internal class TaskConfiguration
    {
        public TaskConfiguration()
        {
        }

        public int ItemId { get; set; }
        public string Name { get; set; }
        public int MaxConcurrentThreads { get; set; }
        public int TotalRequests { get; set; }
        public bool IsMultiThreadExecution { get; set; }
        public string RequestCode { get; set; }
        public bool IsRequestPerSecond { get; set; }
        public int RequestPerSecond { get; set; }
        public int Durtion { get; set; }
    }
}