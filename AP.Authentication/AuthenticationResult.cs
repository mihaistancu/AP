using AP.Identity;

namespace AP.Authentication
{
    public class AuthenticationResult
    {
        public bool IsAuthenticated { get; set; }
        public Claims Claims { get; set; }
    }
}
