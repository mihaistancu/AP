using AP.Http;

namespace AP.Web.Cookies
{
    public class CookieReader
    {
        private IHttpInput input;

        public CookieReader(IHttpInput input)
        {
            this.input = input;
        }

        public Cookie Get(string name)
        {
            return new Cookie();
        }
    }
}
