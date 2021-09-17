namespace AP.Processing
{
    public class Message
    {
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public EnvelopeType EnvelopeType { get; set; }
        public string Url { get; set; }
        public string DocumentType { get; set; }
        public Certificate Certificate { get; set; }
    }

    public enum EnvelopeType
    {
        UserMessage,
        Signal
    }

    public class Certificate
    {
    }
}
