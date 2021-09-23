namespace AP.Processing
{
    public class Message
    {
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string EnvelopeType { get; set; }
        public string Url { get; set; }
        public string DocumentType { get; set; }
        public Certificate Certificate { get; set; }
    }

    public class EnvelopeType
    {
        public const string UserMessage = "UserMessage";
        public const string Signal = "Signal";
    }

    public class Certificate
    {
    }
}
