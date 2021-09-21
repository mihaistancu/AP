using Microsoft.Owin;

namespace AP.Web.Server.Owin
{
    public class WebOutput
    {
        private IOwinResponse response;

        public WebOutput(IOwinResponse response)
        {
            this.response = response;
        }
    }
}
