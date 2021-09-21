namespace AP.Web.Server.Owin
{
    public interface IWebService
    {
        void Handle(WebInput input, WebOutput output);
    }
}
