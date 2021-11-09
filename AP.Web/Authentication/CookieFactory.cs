using AP.Web.Cookies;

namespace AP.Web.Authentication
{
    public class CookieFactory
    {
        public Cookie CreateAuthenticationCookie()
        {
            return new Cookie();
        }
    }
}
