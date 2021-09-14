using AP.Processing;
using AP.Processing.Async.IR.Import;

namespace AP.IR
{
    public class IrImporter : IIrImporter
    {
        private IrStorage storage;

        public IrImporter(IrStorage storage)
        {
            this.storage = storage;
        }

        public void Import(Message message)
        {
            storage.Save(message);
        }
    }
}
