using System.Collections.Generic;
using System.Linq;

namespace AP.Processing.RabbitMQ.Serialization
{
    public class Store<T>
    {
        private Dictionary<string, T> map;

        public Store(params T[] items)
        {
            map = items.ToDictionary(i => Id(i), i => i);
        }

        public T Get(string id)
        {
            return map[id];
        }

        public string Id(T item)
        {
            return item.GetType().Name;
        }
    }
}
