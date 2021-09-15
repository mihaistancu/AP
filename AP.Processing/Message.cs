namespace AP.Processing
{
    public class Message
    {
        public string Sender { get; set; }
        public Direction Direction { get; set; }
        public MessageType Type { get; set; }
        public string Envelope { get; set; }
        public string DocumentType { get; set; }
        public Certificate Certificate { get; set; }
    }

    public enum Direction
    {
        In,
        Out
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
