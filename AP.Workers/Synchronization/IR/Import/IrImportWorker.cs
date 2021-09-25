using AP.Messages;

namespace AP.Workers.Synchronization.IR.Import
{
    public class IrImportWorker : IWorker
    {
        private IIrImporter importer;

        public IrImportWorker(IIrImporter importer)
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
