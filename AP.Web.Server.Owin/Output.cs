﻿using AP.Processing.Sync;
using Microsoft.Owin;

namespace AP.Web.Server.Owin
{
    public class Output : IOutput
    {
        private IOwinResponse response;

        public Output(IOwinResponse response)
        {
            this.response = response;
        }

        public void Send(byte[] bytes)
        {
            response.Write(bytes);
        }
    }
}
