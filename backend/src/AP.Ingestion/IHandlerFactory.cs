using AP.Handlers;

namespace AP.Ingestion
{
    public interface IHandlerFactory
    {
        IHandler Get(string handlerName);
    }
}
