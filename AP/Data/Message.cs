namespace AP.Data
{
    public class Message
    {
        public Direction Direction { get; set; }
        public string Envelope { get; set; }
        public string DocumentType { get; set; }
        public Certificate Certificate { get; set; }
    }

    public enum Direction
    {
        In,
        Out
    }
}
