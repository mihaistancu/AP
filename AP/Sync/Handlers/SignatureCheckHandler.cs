namespace AP.Sync.Handlers
{
    public class SignatureCheckHandler : IHandler
    {
        public bool Handle(Message message)
        {
            System.Console.WriteLine("Signature Check");
            return true;
        }
    }
}
