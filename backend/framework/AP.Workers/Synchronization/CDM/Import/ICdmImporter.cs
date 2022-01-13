using AP.Messages;

namespace AP.Workers.Synchronization.CDM.Import
{
    public interface ICdmImporter
    {
        void Import(Message message);
    }
}
