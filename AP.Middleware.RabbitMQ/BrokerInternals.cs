using RabbitMQ.Client;
using System;

namespace AP.Middleware.RabbitMQ
{
    public class BrokerInternals : IDisposable
    {
        private IConnection connection;
        private IModel model;

        public BrokerInternals(IConnection connection, IModel model)
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
