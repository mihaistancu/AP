namespace AP.Http
{
    public interface IHttpOutput
    {
        void AddCookie(string key, string value);
        void ContentType(string contentType);
        void Send(byte[] bytes);
        void Status(int status);
    }
}