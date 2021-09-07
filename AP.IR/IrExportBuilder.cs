using System.Collections.Generic;

namespace AP.IR
{
    public class IrExportBuilder : IIrExportBuilder
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
                },
                new Message
                {
                    SedType = "SYN001",
                    Content = "SYN001"
                }
            };
        }
    }
}
