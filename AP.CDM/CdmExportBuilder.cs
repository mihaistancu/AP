using AP.Data;
using AP.Processing.Async.CDM.Export;

namespace AP.CDM
{
    public class CdmExportBuilder : ICdmExportBuilder
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
                    DocumentType = "SYN003",
                    Direction = Direction.Out
                },
                new Message
                {
                    DocumentType = "SYN003",
                    Direction = Direction.Out
                }
            };
        }
    }
}
