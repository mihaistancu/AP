using System;

namespace AP.Middleware.RabbitMQ.Serialization
{
    public interface IStore
    {
        T Get<T>(Type type);
    }
}
