namespace AP.Receiver
{
    public class Message
    {
        public UseCase UseCase { get; set; }
        public Channel Channel { get; set; }
    }

    public enum UseCase
    {
        Business,
        System
    }

    public enum Channel
    {
        Inbound,
        Outbox
    }
}
