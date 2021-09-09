using AP.Data;

namespace AP.Processing.Async.Workers.IR.Import
{
    public class IrImportWorker : IWorker
    {
        private IIrImporter importer;

        public IrImportWorker(IIrImporter importer)
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
