﻿using AP.Processing;
using AP.Processing.RabbitMQ;
using AP.Processing.RabbitMQ.Serialization;
using AP.Processing.Workers.Antimalware;
using AP.Processing.Workers.Antimalware.Amsi;
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
            container.RegisterInstance<IStore>(this);
            container.RegisterType<IMessageBroker, MessageBroker>(TypeLifetime.Singleton);
            container.RegisterType<MessageBroker>(TypeLifetime.Singleton);
            container.RegisterType<IScanner, AmsiScanner>(TypeLifetime.Singleton);
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
