using AP.Messaging;

namespace AP.Workers.Synchronization.CDM.Import
{
    public class CdmImportWorker : IWorker
    {
        private ICdmImporter importer;

        public CdmImportWorker(ICdmImporter importer)
        {
            this.importer = importer;
        }

        public virtual bool Handle(Message message)
        {
            importer.Import(message);
            return true;
        }
    }
}
