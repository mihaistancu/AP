namespace AP.Routing.Config
{
    public interface IInstitutionConfig
    {
        bool IsExternalInstitution(string endpointId);
        string GetUrl(string endpointId);
    }
}
