namespace AP.Processing
{
    public class Work
    {
        public Message Message { get; set; }
        public IWorker Worker { get; set; }
        public IWorkflow Workflow { get; set; }
    }
}
