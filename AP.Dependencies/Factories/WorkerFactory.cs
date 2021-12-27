using AP.Scanner;
using AP.AS4;
using AP.CDM;
using AP.Cryptography;
using AP.Gateways.AP;
using AP.Gateways.CSN;
using AP.Gateways.Institution;
using AP.IR;
using AP.IR.Request;
using AP.IR.Subscriptions;
using AP.Orchestration;
using AP.Routing;
using AP.Validation;
using AP.Workers;
using AP.Workers.Antimalware;
using AP.Workers.DocumentValidation;
using AP.Workers.Forwarding;
using AP.Workers.Synchronization.CDM.Import;
using AP.Workers.Synchronization.CDM.Report;
using AP.Workers.Synchronization.CDM.Request;
using AP.Workers.Synchronization.CDM.Subscriptions;
using AP.Workers.Synchronization.IR.Import;
using AP.Workers.Synchronization.IR.Request;
using AP.Workers.Synchronization.IR.Subscriptions;
using System;
using System.Collections.Generic;

namespace AP.Dependencies.Factories
{
    public class WorkerFactory: IWorkerFactory
    {
        private Dictionary<string, IWorker> cache = new Dictionary<string, IWorker>();
        private Dictionary<string, Func<IWorker>> factories = new Dictionary<string, Func<IWorker>>();

        public WorkerFactory()
        {
            var csnGateway = new CsnGateway(new CsnConfig(), Context.MessageClient);
            var apGateway = new ApGateway(new Encryptor(), new ApConfig(), Context.MessageClient);
            var institutionGateway = new InstitutionGateway(new RoutingConfig(), Context.MessageClient, Context.MessageQueue);
            var scanner = new AmsiScanner();
            var cdmStorage = new CdmStorage();
            var irStorage = new IrStorage();
            var documentValidator = new DocumentValidator();
            var documentValidationErrorFactory = new DocumentValidationErrorFactory();
            var antimalwareErrorFactory = new AntimalwareErrorFactory();
            
            factories[Worker.ScanMessageFromCsn] =
                () => new MonitoredWorker(
                    Context.Log,
                    new AntimalwareWorker(scanner, antimalwareErrorFactory, Context.MessageStorage, csnGateway));

            factories[Worker.ScanMessageFromAp] =
                () => new MonitoredWorker(
                    Context.Log,
                    new AntimalwareWorker(scanner, antimalwareErrorFactory, Context.MessageStorage, apGateway));

            factories[Worker.ScanMessageFromInstitution] =
                () => new MonitoredWorker(
                    Context.Log,
                    new AntimalwareWorker(scanner, antimalwareErrorFactory, Context.MessageStorage, institutionGateway));

            factories[Worker.ValidateDocumentFromCsn] =
                () => new MonitoredWorker(
                    Context.Log,
                    new DocumentValidationWorker(documentValidator, documentValidationErrorFactory, Context.MessageStorage, csnGateway));

            factories[Worker.ValidateDocumentFromAp] =
                () => new MonitoredWorker(
                    Context.Log,
                    new DocumentValidationWorker(documentValidator, documentValidationErrorFactory, Context.MessageStorage, apGateway));

            factories[Worker.ValidateDocumentFromInstitution] =
                () => new MonitoredWorker(
                    Context.Log,
                    new DocumentValidationWorker(documentValidator, documentValidationErrorFactory, Context.MessageStorage, institutionGateway));

            factories[Worker.ForwardToAp] =
                () => new MonitoredWorker(
                    Context.Log,
                    new ForwardingWorker(apGateway));

            factories[Worker.ForwardToInstitution] =
                () => new MonitoredWorker(
                    Context.Log,
                    new ForwardingWorker(institutionGateway));

            factories[Worker.ImportCdm] =
                () => new MonitoredWorker(
                    Context.Log,
                    new CdmImportWorker(new CdmImporter()));

            factories[Worker.ReportCdm] =
                () => new MonitoredWorker(
                    Context.Log,
                    new CdmReportWorker(new CdmReporter(), csnGateway));

            factories[Worker.ProvideCdm] =
                () => new MonitoredWorker(
                    Context.Log,
                    new CdmRequestWorker(
                        new CdmProvider(new CdmRequestParser(), cdmStorage, Context.MessageStorage, csnGateway)));

            factories[Worker.PublishCdm] =
                () => new MonitoredWorker(
                    Context.Log,
                    new CdmSubscriptionsWorker(
                        new CdmPublisher(new CdmSubscriptionStorage(), cdmStorage, Context.MessageStorage, institutionGateway)));

            factories[Worker.ImportIr] =
                () => new MonitoredWorker(
                    Context.Log,
                    new IrImportWorker(new IrImporter()));

            factories[Worker.ProvideIr] =
                () => new MonitoredWorker(
                    Context.Log,
                    new IrRequestWorker(
                        new IrProvider(new IrRequestParser(), irStorage, Context.MessageStorage, institutionGateway)));

            factories[Worker.PublishIr] =
                () => new MonitoredWorker(
                    Context.Log,
                    new IrSubscriptionsWorker(
                        new IrPublisher(new IrSubscriptionStorage(), irStorage, Context.MessageStorage, institutionGateway)));
        }

        public IWorker Get(string name)
        {
            if (!cache.ContainsKey(name))
            {
                cache[name] = factories[name].Invoke();
            }
            return cache[name];
        }
    }
}
