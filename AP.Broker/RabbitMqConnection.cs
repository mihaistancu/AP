using RabbitMQ.Client;
using System;

namespace AP.Broker
{
    public class RabbitMqConnection : IDisposable
    {
        private IConnection connection;
        private IModel model;

        public RabbitMqConnection(IConnection connection, IModel model)
        {
            this.connection = connection;
            this.model = model;
        }

        public void Dispose()
        {
            connection.Dispose();
            model.Dispose();
        }
    }
}
