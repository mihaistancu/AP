namespace AP.Web.Server
{
    public interface IWebService
    {
        void Handle(IWebInput input, IWebOutput output);
    }
}
