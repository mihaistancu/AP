using AP.Processing;
using AP.Processing.Async.Workers.CDM.Import;

namespace AP.CDM
{
    public class CdmImporter : ICdmImporter
    {
        private CdmStorage storage;

        public CdmImporter(CdmStorage storage)
        {
            this.storage = storage;
        }

        public void Import(Message message)
        {
            storage.Save(message);
        }
    }
}
