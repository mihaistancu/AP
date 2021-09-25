using AP.Messaging;

namespace AP.Gateways.Institution
{
    public interface IMessageClient
    {
        void Send(string url, Message message);
    }
}
