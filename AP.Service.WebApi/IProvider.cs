using System;

namespace AP.Service.WebApi
{
    public interface IProvider
    {
        T Get<T>(); 
    }
}
