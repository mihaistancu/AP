using AP.Processing.Sync;

namespace AP.Web.Server.Owin
{
    public interface IServerConfig
    {
        IHandler Get(string url);
    }
}
