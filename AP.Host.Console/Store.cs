﻿using AP.Async;
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
using AP.Async.Workers.CDM.Import;
using AP.CDM;
using AP.Async.Workers.CDM;
using AP.Async.Workers.CDM.Export;
using AP.Async.Workers.CDM.Report;
using AP.Service.WebApi;

namespace AP.Host.Console
{
    public class Store : IStore, IProvider, IDisposable
    {
        UnityContainer container;

        public Store()
        {
            container = new UnityContainer();
            container.RegisterInstance<IStore>(this);
            container.RegisterInstance<IProvider>(this);
            container.RegisterType<MessageBroker, RabbitMqMessageBroker>(TypeLifetime.Singleton);
            container.RegisterType<RabbitMqMessageBroker>(TypeLifetime.Singleton);
            container.RegisterType<IScanner, AmsiScanner>(TypeLifetime.Singleton);
            container.RegisterType<IDocumentValidator, DocumentValidator>(TypeLifetime.Singleton);
            container.RegisterType<IEnvelopeValidator, EnvelopeValidator>(TypeLifetime.Singleton);
            container.RegisterType<IRouter, Delivery.Router>(TypeLifetime.Singleton);
            container.RegisterType<IIrParser, IrParser>(TypeLifetime.Singleton);
            container.RegisterType<IIrStorage, IrStorage>(TypeLifetime.Singleton);
            container.RegisterType<IIrExportBuilder, IrExportBuilder>(TypeLifetime.Singleton);
            container.RegisterType<ICdmParser, CdmParser>(TypeLifetime.Singleton);
            container.RegisterType<ICdmStorage, CdmStorage>(TypeLifetime.Singleton);
            container.RegisterType<ICdmExportBuilder, CdmExportBuilder>(TypeLifetime.Singleton);
            container.RegisterType<ICdmReportBuilder, CdmReportBuilder>(TypeLifetime.Singleton);
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
