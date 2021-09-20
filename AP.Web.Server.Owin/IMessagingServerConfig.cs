using AP.Processing.Sync;

namespace AP.Web.Server.Owin
{
    public interface IMessagingServerConfig
    {
        IHandler Get(string url);
    }
}
