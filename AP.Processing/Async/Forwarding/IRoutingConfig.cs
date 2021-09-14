namespace AP.Processing.Async.Forwarding
{
    public interface IRoutingConfig
    {
        string GetEndpoint(Message message);
    }
}
