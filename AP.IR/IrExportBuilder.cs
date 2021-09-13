using AP.Data;
using AP.Processing.Async.IR.Export;

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

        public Message[] Build()
        {
            return new []
            { 
                new Message
                {
                    DocumentType = "SYN001",
                    Direction = Direction.Out
                },
                new Message
                {
                    DocumentType = "SYN001",
                    Direction = Direction.Out
                }
            };
        }
    }
}
