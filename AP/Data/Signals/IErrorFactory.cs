using AP.Data;
using System;

namespace AP.Signals
{
    public interface IErrorFactory
    {
        string Get(Exception exception, Message message);
    }
}
