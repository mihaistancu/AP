using AP.Messages;

namespace AP.Workers.Synchronization.IR.Import
{
    public interface IIrImporter
    {
        void Import(Message message);
    }
}
