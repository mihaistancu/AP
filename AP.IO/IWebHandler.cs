namespace AP.IO
{
    public interface IWebHandler
    {
        void Handle(IWebInput input, IWebOutput output);
    }
}
