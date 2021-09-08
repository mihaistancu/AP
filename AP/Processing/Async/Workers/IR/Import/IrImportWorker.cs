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

        public Message[] Handle(Message message)
        {
            System.Console.WriteLine("IrImport");

            var data = parser.Parse(message.Blob);
            storage.Save(data);

            return new[] { message };
        }
    }
}
