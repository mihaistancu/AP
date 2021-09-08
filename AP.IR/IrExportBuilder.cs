using AP.Processing.Async.Workers.IR.Export;

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
