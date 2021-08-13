namespace AP.Receiver.Handlers
{
    public class TlsCheckHandler : IHandler
    {
        public bool Handle(Message message)
        {
            System.Console.WriteLine("TLS Check");
            return true;
        }
    }
}
