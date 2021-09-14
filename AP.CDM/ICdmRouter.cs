using AP.Processing;

namespace AP.CDM
{
    public interface ICdmRouter
    {
        void Route(CdmRequest request, Message[] messages);
        void Route(CdmSubscription subscription, Message[] messages);
        void Route(Message message);
    }
}
