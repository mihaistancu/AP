using AP.Data;

namespace AP.Processing.Async.Workers.IR.Import
{
    public interface IIrImporter
    {
        void Import(Message message);
    }
}
