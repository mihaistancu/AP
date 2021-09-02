using System;
using Unity;

namespace AP.ConsoleApp
{
    public class Store : IStore, IDisposable
    {
        UnityContainer container;

        public Store()
        {
            container = new UnityContainer();
            container.RegisterType<IStore, Store>();
        }

        public T Get<T>()
        {
            return container.Resolve<T>();
        }

        public void Dispose()
        {
            container.Dispose();
        }
    }
}
