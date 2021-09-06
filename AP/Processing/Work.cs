namespace AP.Processing
{
    public class Work
    {
        public Message Message { get; set; }
        public Worker Worker { get; set; }
        public IWorkflow Workflow { get; set; }
        public ExceptionHandler ExceptionHandler { get; set; }
    }
}
