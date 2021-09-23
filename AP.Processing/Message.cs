namespace AP.Processing
{
    public class Message
    {
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string UseCase { get; set; }
        public string Domain { get; set; }
        public string EnvelopeType { get; set; }
        public string DocumentType { get; set; }
        public Certificate Certificate { get; set; }
    }

    public class EnvelopeType
    {
        public const string UserMessage = "UserMessage";
        public const string Signal = "Signal";
    }

    public class UseCase
    {
        public const string Business = "Business";
        public const string System = "System";
    }

    public class Domain
    {
        public const string National = "National";
        public const string International = "International";
    }

    public class Certificate
    {
    }
}
