using System;
using System.Collections.Generic;
using System.Linq;

namespace AP.Middleware.RabbitMQ.Serialization
{
    public class Map<T>
    {
        private IStore store;
        private Dictionary<string, Type> map;

        public Map(IStore store)
        {
            this.store = store;
            var allAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            var allTypes = allAssemblies.SelectMany(a => a.GetTypes());
            var filteredTypes = allTypes.Where(t => typeof(T).IsAssignableFrom(t));
            map = filteredTypes.ToDictionary(t => t.Name, t => t);
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
