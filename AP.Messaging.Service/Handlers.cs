namespace AP.Messaging.Service
{
    public class Handlers
    {
        public static string ProcessAsync = nameof(ProcessAsync);
        public static string Decrypt = nameof(Decrypt);
        public static string ValidateEnvelope = nameof(ValidateEnvelope);
        public static string Persist = nameof(Persist);
        public static string PullRequest = nameof(PullRequest);
        public static string Receipt = nameof(Receipt);
        public static string ValidateSignature = nameof(ValidateSignature);
        public static string ValidateTlsCertificate = nameof(ValidateTlsCertificate);
    }
}
