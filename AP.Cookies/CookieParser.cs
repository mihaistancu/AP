using AP.Http;

namespace AP.Cookies
{
    public class CookieParser
    {
        private IHttpInput input;

        public CookieParser(IHttpInput input)
        {
            this.input = input;
        }

        public Cookie Get(string name)
        {
            return new Cookie();
        }
    }
}
