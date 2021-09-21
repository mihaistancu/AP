using Microsoft.Owin;

namespace AP.Web.Server.Owin
{
    public class Output
    {
        private IOwinResponse response;

        public Output(IOwinResponse response)
        {
            this.response = response;
        }
    }
}
