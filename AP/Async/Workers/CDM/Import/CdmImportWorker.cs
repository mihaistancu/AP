namespace AP.Async.Workers.CDM.Import
{
    public class CdmImportWorker : Worker
    {
        private readonly ICdmParser parser;
        private readonly ICdmStorage storage;

        public CdmImportWorker(ICdmParser parser, ICdmStorage storage)
        {
            this.parser = parser;
            this.storage = storage;
        }

        public override void Do(Work work)
        {
            System.Console.WriteLine("CdmImport");

            var data = parser.Parse(work.Message);
            storage.Save(data);

            work.Workflow.Next(work);
        }
    }
}
