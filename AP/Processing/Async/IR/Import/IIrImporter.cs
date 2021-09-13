using AP.Data;

namespace AP.Processing.Async.IR.Import
{
    public interface IIrImporter
    {
        void Import(Message message);
    }
}
