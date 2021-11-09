using AP.Http;

namespace AP.Login
{
    public class CredentialsReader
    {
        public string Username { get; }
        public string Password { get; }

        public CredentialsReader(IHttpInput input)
        {

        }
    }
}
