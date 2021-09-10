using AP.Data;
using System;

namespace AP.Signals
{
    public interface IErrorFactory
    {
        Message Get(Exception exception, Message message);
    }
}
