namespace AP.Routing.Config
{
    public interface ICsnConfig
    {
        bool IsCsn(string endpointId);
        string GetUrl(string endpointId);
    }
}
