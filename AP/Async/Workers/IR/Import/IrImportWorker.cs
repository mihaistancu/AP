using AP.Async.Workers.IR.Import;

namespace AP.Async.Workers.IR
{
    public class IrImportWorker : Worker
    {
        private IIrParser parser;
        private IIrStorage storage;

        public IrImportWorker(IIrParser parser, IIrStorage storage)
        {
            this.parser = parser;
            this.storage = storage;
        }

        public override void Do(Work work)
        {
            System.Console.WriteLine("IrImport");

            var data = parser.Parse(work.Message.Blob);
            storage.Save(data);

            work.Workflow.Next(work);
        }
    }
}
