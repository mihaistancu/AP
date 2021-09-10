using AP.Processing.Sync;
using Microsoft.Owin;

namespace AP.Service.WebApi
{
    public class Output : IOutput
    {
        private IOwinResponse response;

        public Output(IOwinResponse response)
        {
            this.response = response;
        }

        public void Send()
        {
            response.Write("");
        }
    }
}
