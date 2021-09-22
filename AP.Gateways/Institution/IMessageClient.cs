using AP.Processing;

namespace AP.Gateways.Institution
{
    public interface IMessageClient
    {
        void Send(string url, Message message);
    }
}
