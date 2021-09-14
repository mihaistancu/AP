using AP.Processing;

namespace AP.Routing
{
    public interface IWebClient
    {
        void Send(string url, params Message[] messages);
    }
}
