namespace AP.AS4.ReceiptFactories
{
    public class EmptyReceiptFactory : IReceiptFactory
    {
        public string Get(Message message)
        {
            return string.Empty;
        }
    }
}
