using AP.Messaging;

namespace AP.Workers.Synchronization.CDM.Import
{
    public interface ICdmImporter
    {
        void Import(Message message);
    }
}
