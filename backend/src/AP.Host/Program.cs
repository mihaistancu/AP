namespace AP.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            Context.Build();

            using (Context.Metrics.Start())
            using (Context.Trace.Start())
            using (Context.Orchestrator.Start())            
            {
                Context.Ingestion.Start("http://+:8080");                
            }
        }
    }
}
