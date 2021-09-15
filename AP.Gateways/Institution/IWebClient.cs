using AP.Processing;

namespace AP.Gateways.Institution
{
    public interface IWebClient
    {
        void Send(string url, Message message);
    }
}
