using AP.Antimalware.Amsi;
using AP.AS4;
using AP.CDM;
using AP.Cryptography;
using AP.Gateways.AP;
using AP.Gateways.CSN;
using AP.Gateways.Institution;
using AP.IR;
using AP.IR.Request;
using AP.IR.Subscriptions;
using AP.Messaging.Client;
using AP.Messaging.Queue;
using AP.Monitoring;
using AP.Processing.Async;
using AP.Processing.Async.Antimalware;
using AP.Processing.Async.DocumentValidation;
using AP.Processing.Async.Forwarding;
using AP.Processing.Async.Synchronization.CDM.Import;
using AP.Processing.Async.Synchronization.CDM.Report;
using AP.Processing.Async.Synchronization.CDM.Request;
using AP.Processing.Async.Synchronization.CDM.Subscriptions;
using AP.Processing.Async.Synchronization.IR.Import;
using AP.Processing.Async.Synchronization.IR.Request;
using AP.Processing.Async.Synchronization.IR.Subscriptions;
using AP.Routing;
using AP.Storage;
using AP.Validation;
using System;
using System.Collections.Generic;

namespace AP.Host.Console
{
    public class WorkerFactory
    {
        private Dictionary<string, IWorker> cache = new Dictionary<string, IWorker>();
        private Dictionary<string, Func<IWorker>> factories = new Dictionary<string, Func<IWorker>>();

        public WorkerFactory(
            MessageClient messageClient, 
            MessageQueue messageQueue, 
            MessageStorage messageStorage)
        {
            var csnGateway = new CsnGateway(new CsnConfig(), messageClient);
            var apGateway = new ApGateway(new Encryptor(), new ApConfig(), messageClient);
            var institutionGateway = new InstitutionGateway(new RoutingConfig(), messageClient, messageQueue);
            var scanner = new AmsiScanner();
            var cdmStorage = new CdmStorage();
            var irStorage = new IrStorage();
            var documentValidator = new DocumentValidator();
            var documentValidationErrorFactory = new DocumentValidationErrorFactory();
            var antimalwareErrorFactory = new AntimalwareErrorFactory();

            factories[Workers.ScanMessageFromCsn] = 
                () => new MonitoredWorker(
                    new AntimalwareWorker(scanner, antimalwareErrorFactory, messageStorage, csnGateway));

            factories[Workers.ScanMessageFromAp] = 
                () => new MonitoredWorker(
                    new AntimalwareWorker(scanner, antimalwareErrorFactory, messageStorage, apGateway));

            factories[Workers.ScanMessageFromInstitution] = 
                () => new MonitoredWorker(
                    new AntimalwareWorker(scanner, antimalwareErrorFactory, messageStorage, institutionGateway));
            
            factories[Workers.ValidateDocumentFromCsn] = 
                () => new MonitoredWorker(
                    new DocumentValidationWorker(documentValidator, documentValidationErrorFactory, messageStorage, csnGateway));
                
            factories[Workers.ValidateDocumentFromAp] = 
                () => new MonitoredWorker(
                    new DocumentValidationWorker(documentValidator, documentValidationErrorFactory, messageStorage, apGateway));

            factories[Workers.ValidateDocumentFromInstitution] = 
                () => new MonitoredWorker(
                    new DocumentValidationWorker(documentValidator, documentValidationErrorFactory, messageStorage, institutionGateway));

            factories[Workers.ForwardToAp] = 
                () => new MonitoredWorker(
                    new ForwardingWorker(apGateway));
                
            factories[Workers.ForwardToInstitution] = 
                () => new MonitoredWorker(
                    new ForwardingWorker(institutionGateway));
                
            factories[Workers.ImportCdm] = 
                () => new MonitoredWorker(
                    new CdmImportWorker(new CdmImporter()));
                
            factories[Workers.ReportCdm] = 
                () => new MonitoredWorker(
                    new CdmReportWorker(new CdmReporter(), csnGateway));
                
            factories[Workers.ProvideCdm] = 
                () => new MonitoredWorker(
                    new CdmRequestWorker(
                        new CdmProvider(new CdmRequestParser(), cdmStorage, messageStorage, csnGateway)));
                
            factories[Workers.PublishCdm] = 
                () => new MonitoredWorker(
                    new CdmSubscriptionsWorker(
                        new CdmPublisher(new CdmSubscriptionStorage(), cdmStorage, messageStorage, institutionGateway)));
                
            factories[Workers.ImportIr] = 
                () => new MonitoredWorker(
                    new IrImportWorker(new IrImporter()));
                
            factories[Workers.ProvideIr] = 
                () => new MonitoredWorker(
                    new IrRequestWorker(
                        new IrProvider(new IrRequestParser(), irStorage, messageStorage, institutionGateway)));
                
            factories[Workers.PublishIr] = 
                () => new MonitoredWorker(
                    new IrSubscriptionsWorker(
                        new IrPublisher(new IrSubscriptionStorage(), irStorage, messageStorage, institutionGateway)));
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
