using AP.Handlers;

namespace AP.Endpoints
{
    public interface IHandlerFactory
    {
        IHandler Get(string handlerName);
    }
}
