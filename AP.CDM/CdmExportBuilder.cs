using AP.Processing.Async.Workers.CDM.Export;

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
                    Content = "SYN003"
                },
                new Message
                {
                    DocumentType = "SYN003",
                    Content = "SYN003"
                }
            };
        }
    }
}
