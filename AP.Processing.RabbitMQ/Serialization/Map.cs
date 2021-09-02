using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AP.Processing.RabbitMQ.Serialization
{
    public class Map<T>
    {
        private readonly IStore store;
        private Dictionary<string, Type> map;

        public Map(IStore store)
        {
            this.store = store;
            var assembly = Assembly.GetAssembly(typeof(IStore));
            var types = assembly.GetTypes().Where(t => typeof(T).IsAssignableFrom(t));
            map = types.ToDictionary(t => t.Name, t => t);
        }

        public T Get(string id)
        {
            return store.Get<T>(map[id]);
        }

        public string Id(T item)
        {
            return item.GetType().Name;
        }
    }
}
