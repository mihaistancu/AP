using System.Collections.Generic;

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

        public List<Message> Build()
        {
            return new List<Message>
            { 
                new Message
                {
                    SedType = "SYN001",
                    Content = "SYN001"
                }
            };
        }
    }
}
