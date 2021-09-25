namespace AP.Messaging
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
}
