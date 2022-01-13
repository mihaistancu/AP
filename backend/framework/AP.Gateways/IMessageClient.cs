using AP.Messages;

namespace AP.Gateways
{
    public interface IMessageClient
    {
        void Send(string url, Message message);
    }
}
