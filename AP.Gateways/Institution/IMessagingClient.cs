using AP.Processing;

namespace AP.Gateways.Institution
{
    public interface IMessagingClient
    {
        void Send(string url, Message message);
    }
}
