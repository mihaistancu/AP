namespace AP.Processing
{
    public interface IRouter
    {
        void Route(string endpointId, params Message[] messages);
    }
}
