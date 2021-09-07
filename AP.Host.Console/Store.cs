using AP.Async;
using AP.Async.Workers.Antimalware;
using AP.Middleware.RabbitMQ;
using AP.Middleware.RabbitMQ.Serialization;
using AP.Antimalware.Amsi;
using System;
using Unity;
using AP.Async.Workers.Validation;
using AP.Validation;
using AP.Sync.Handlers.Validation;
using AP.Async.Workers.Delivery;
using AP.IR;
using AP.Async.Workers.IR;
using AP.Async.Workers.IR.Import;

namespace AP.Host.Console
{
    public class Store : IStore, IDisposable
    {
        UnityContainer container;

        public Store()
        {
            container = new UnityContainer();
            container.RegisterInstance<IStore>(this);
            container.RegisterType<IMessageBroker, MessageBroker>(TypeLifetime.Singleton);
            container.RegisterType<MessageBroker>(TypeLifetime.Singleton);
            container.RegisterType<IScanner, AmsiScanner>(TypeLifetime.Singleton);
            container.RegisterType<IDocumentValidator, DocumentValidator>(TypeLifetime.Singleton);
            container.RegisterType<IEnvelopeValidator, EnvelopeValidator>(TypeLifetime.Singleton);
            container.RegisterType<IRouter, Delivery.Router>(TypeLifetime.Singleton);
            container.RegisterType<IIrParser, IrParser>(TypeLifetime.Singleton);
            container.RegisterType<IIrStorage, IrStorage>(TypeLifetime.Singleton);
            container.RegisterType<IIrMessageBuilder, IrMessageBuilder>(TypeLifetime.Singleton);
        }

        public T Get<T>()
        {
            return container.Resolve<T>();
        }

        public T Get<T>(Type type)
        {
            return (T)container.Resolve(type);
        }

        public void Dispose()
        {
            container.Dispose();
        }
    }
}
