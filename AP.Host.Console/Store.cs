﻿using AP.Async;
using AP.Async.Workers.Antimalware;
using AP.Middleware.RabbitMQ;
using AP.Middleware.RabbitMQ.Serialization;
using AP.Antimalware.Amsi;
using System;
using Unity;
using AP.Async.Workers.Validation;
using AP.Validation;

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
