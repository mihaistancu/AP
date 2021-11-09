using AP.Identity;

namespace AP.Authentication
{
    public class Authenticator
    {
        public AuthenticationResult Authenticate(string username, string password)
        {
            return new AuthenticationResult
            {
                IsAuthenticated = true,
                Claims = new Claims()
            };
        }
    }
}
