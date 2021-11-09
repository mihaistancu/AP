using AP.Web.Identity;

namespace AP.Web.Authentication
{
    public class AuthenticationResult
    {
        public bool IsAuthenticated { get; set; }
        public Claims Claims { get; set; }
    }
}
