using AP.Data;

namespace AP.Processing.Async.Workers.IR.Import
{
    public class IrImportWorker : IWorker
    {
        private IIrParser parser;
        private IIrStorage storage;

        public IrImportWorker(IIrParser parser, IIrStorage storage)
        {
            this.parser = parser;
            this.storage = storage;
        }

        public virtual Message[] Handle(Message message)
        {
            var data = parser.Parse(message.Blob);
            storage.Save(data);

            return new[] { message };
        }
    }
}
