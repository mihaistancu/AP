using AP.Gateways.AP;
using AP.Gateways.CSN;
using AP.Gateways.Institution;
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

namespace AP.Host.Console
{
    public class Workers
    {
        private WorkerMap map;

        public IWorker ScanMessageFromCsn { get; private set; }
        public IWorker ScanMessageFromAp { get; private set; }
        public IWorker ScanMessageFromInstitution { get; private set; }
        public IWorker ValidateDocumentFromCsn { get; private set; }
        public IWorker ValidateDocumentFromAp { get; private set; }
        public IWorker ValidateDocumentFromInstitution { get; private set; }
        public IWorker ForwardToAp { get; private set; }
        public IWorker ForwardToInstitution { get; private set; }
        public IWorker ImportCdm { get; private set; }
        public IWorker ReportCdm { get; private set; }
        public IWorker ProvideCdm { get; private set; }
        public IWorker PublishCdm { get; private set; }
        public IWorker ImportIr { get; private set; }
        public IWorker ProvideIr { get; private set; }
        public IWorker PublishIr { get; private set; }

        public Workers(
            WorkerMap map,
            AntimalwareWorker<CsnGateway> scanMessageFromCsn,
            AntimalwareWorker<ApGateway> scanMessageFromAp,
            AntimalwareWorker<InstitutionGateway> scanMessageFromInstitution,
            DocumentValidationWorker<CsnGateway> validateDocumentFromCsn,
            DocumentValidationWorker<ApGateway> validateDocumentFromAp,
            DocumentValidationWorker<CsnGateway> validateDocumentFromInstitution,
            ForwardingWorker<ApGateway> forwardToAp,
            ForwardingWorker<InstitutionGateway> forwardToInstitution,
            CdmImportWorker importCdm,
            CdmReportWorker<CsnGateway> reportCdm,
            CdmRequestWorker provideCdm,
            CdmSubscriptionsWorker publishCdm,
            IrImportWorker importIr,
            IrRequestWorker provideIr,
            IrSubscriptionsWorker publishIr)
        {
            this.map = map;
            ScanMessageFromCsn = Map(scanMessageFromCsn, nameof(scanMessageFromCsn));
            ScanMessageFromAp = Map(scanMessageFromAp, nameof(scanMessageFromAp));
            ScanMessageFromInstitution = Map(scanMessageFromInstitution, nameof(scanMessageFromInstitution));
            ValidateDocumentFromCsn = Map(validateDocumentFromCsn, nameof(validateDocumentFromCsn));
            ValidateDocumentFromAp = Map(validateDocumentFromAp, nameof(validateDocumentFromAp));
            ValidateDocumentFromInstitution = Map(validateDocumentFromInstitution, nameof(validateDocumentFromInstitution));
            ForwardToAp = Map(forwardToAp, nameof(forwardToAp));
            ForwardToInstitution = Map(forwardToInstitution, nameof(forwardToInstitution));
            ImportCdm = Map(importCdm, nameof(importCdm));
            ReportCdm = Map(reportCdm, nameof(reportCdm));
            ProvideCdm = Map(provideCdm, nameof(provideCdm));
            PublishCdm = Map(publishCdm, nameof(publishCdm));
            ImportIr = Map(importIr, nameof(importIr));
            ProvideIr = Map(provideIr, nameof(provideIr));
            PublishIr = Map(publishIr, nameof(publishIr));
        }

        private IWorker Map(IWorker worker, string name)
        {
            return map.Add(new MonitoredWorker(worker), name);
        }
    }
}
