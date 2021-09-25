namespace AP.IO
{
    public interface IWebOutput
    {
        void ContentType(string contentType);
        void Send(byte[] bytes);
        void Status(int status);
    }
}