namespace AP.Http
{
    public interface IHttpHandler
    {
        void Handle(IHttpInput input, IHttpOutput output);
    }
}
