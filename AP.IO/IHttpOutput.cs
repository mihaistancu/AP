namespace AP.IO
{
    public interface IHttpOutput
    {
        void ContentType(string contentType);
        void Send(byte[] bytes);
        void Status(int status);
    }
}