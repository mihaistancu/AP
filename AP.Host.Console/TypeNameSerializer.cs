using AP.Middleware.RabbitMQ.Serialization;
using AP.Processing.Async;
using System;

namespace AP.Host.Console
{
    public class TypeNameSerializer : Serializer
    {
        private Store store;

        public TypeNameSerializer(Store store)
        {
            this.store = store;
        }

        protected override IWorker Deserialize(string worker)
        {
            return store.Get<IWorker>(Type.GetType(worker));
        }

        protected override string Serialize(IWorker worker)
        {
            return worker.GetType().AssemblyQualifiedName;
        }
    }
}
