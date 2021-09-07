using AP.Async.Workers.IR.Import;
using System.Collections.Generic;

namespace AP.Async.Workers.IR
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

        public IEnumerable<Message> Handle(Message message)
        {
            System.Console.WriteLine("IrImport");

            var data = parser.Parse(message.Blob);
            storage.Save(data);

            yield return message;
        }
    }
}
