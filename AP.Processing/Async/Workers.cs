namespace AP.Processing.Async
{
    public class Workers
    {
        public static string ScanMessageFromCsn => nameof(ScanMessageFromCsn);
        public static string ScanMessageFromAp => nameof(ScanMessageFromAp);
        public static string ScanMessageFromInstitution => nameof(ScanMessageFromInstitution);
        public static string ValidateDocumentFromCsn => nameof(ValidateDocumentFromCsn);
        public static string ValidateDocumentFromAp => nameof(ValidateDocumentFromAp);
        public static string ValidateDocumentFromInstitution => nameof(ValidateDocumentFromInstitution);
        public static string ForwardToAp => nameof(ForwardToAp);
        public static string ForwardToInstitution => nameof(ForwardToInstitution);
        public static string ImportCdm => nameof(ImportCdm);
        public static string ReportCdm => nameof(ReportCdm);
        public static string ProvideCdm => nameof(ProvideCdm);
        public static string PublishCdm => nameof(PublishCdm);
        public static string ImportIr => nameof(ImportIr);
        public static string ProvideIr => nameof(ProvideIr);
        public static string PublishIr => nameof(PublishIr);
    }
}
