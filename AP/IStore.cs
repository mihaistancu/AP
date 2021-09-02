using System;

namespace AP
{
    public interface IStore
    {
        T Get<T>();

        T Get<T>(Type type);
    }
}
