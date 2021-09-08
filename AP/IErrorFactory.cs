using System;

namespace AP
{
    public interface IErrorFactory
    {
        string Get(Exception exception, Message message);
    }
}
