using AP.Handlers;

namespace AP.Server
{
    public interface IHandlerFactory
    {
        IHandler Get(string handlerName);
    }
}
