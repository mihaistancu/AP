using System;

namespace AP.AS4
{
    public class As4ErrorFactory : IErrorFactory
    {
        public string Get(Exception exception, Message message)
        {
            return exception.ToString();
        }
    }
}
