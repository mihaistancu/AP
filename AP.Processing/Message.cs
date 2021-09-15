namespace AP.Processing
{
    public class Message
    {
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public MessageType Type { get; set; }
        public string Envelope { get; set; }
        public string DocumentType { get; set; }
        public Certificate Certificate { get; set; }
    }

    public enum MessageType
    {
        System,
        Business,
        Signal
    }

    public class Certificate
    {
    }
}
