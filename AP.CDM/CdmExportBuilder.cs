using AP.Async.Workers.CDM.Export;
using System.Collections.Generic;

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

        public List<Message> Build()
        {
            return new List<Message>
            {
                new Message
                {
                    SedType = "SYN003",
                    Content = "SYN003"
                },
                new Message
                {
                    SedType = "SYN003",
                    Content = "SYN003"
                }
            };
        }
    }
}
