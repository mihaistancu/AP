using AP.Http;

namespace AP.Web.Cookies
{
    public class CookieWriter
    {
        private IHttpOutput output;

        public CookieWriter(IHttpOutput output)
        {
            this.output = output;
        }

        public void Write(Cookie cookie)
        {

        }
    }
}
