using AP.Data;
using AP.Signals;
using System;

namespace AP.AS4
{
    public class As4ErrorFactory : IErrorFactory
    {
        public Message Get(Exception exception, Message message)
        {
            return new Message();
        }
    }
}
