namespace AP.IO
{
    public interface IHttpHandler
    {
        void Handle(IHttpInput input, IHttpOutput output);
    }
}
