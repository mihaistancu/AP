namespace AP.IO
{
    public interface IWebService
    {
        void Handle(IWebInput input, IWebOutput output);
    }
}
