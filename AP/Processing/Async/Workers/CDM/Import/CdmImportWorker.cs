using AP.Data;

namespace AP.Processing.Async.Workers.CDM.Import
{
    public class CdmImportWorker : IWorker
    {   
        private ICdmImporter importer;

        public CdmImportWorker(ICdmImporter importer)
        {
            this.importer = importer;
        }

        public virtual Message[] Handle(Message message)
        {
            importer.Import(message);

            return new[] { message };
        }
    }
}
