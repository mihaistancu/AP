using System;

namespace AP.Processing.RabbitMQ.Serialization
{
    public interface IStore
    {
        T Get<T>(Type type);
    }
}
