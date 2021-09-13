using AP.Data;

namespace AP.Processing.Async.Workers.CDM.Import
{
    public interface ICdmImporter
    {
        void Import(Message message);
    }
}
