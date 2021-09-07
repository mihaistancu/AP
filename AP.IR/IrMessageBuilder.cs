namespace AP.IR
{
    public class IrMessageBuilder : IIrMessageBuilder
    {
        public void UseRequest(Message message)
        {
            
        }

        public void UseSubscriptions()
        {
            
        }

        public Message Build()
        {
            return new Message
            {
                SedType = "SYN001",
                Content = "SYN001"
            };
        }
    }
}
