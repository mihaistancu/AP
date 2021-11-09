using AP.Http;

namespace AP.Web.Authentication
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
