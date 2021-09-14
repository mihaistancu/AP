using AP.Processing;
using System;

namespace AP.CDM
{
    public class CdmStorage
    {
        public Message[] Get(CdmRequest request)
        {
            return new[]
            {
                new Message(),
                new Message()
            };
        }

        public Message[] Get(CdmSubscription subscription)
        {
            return new[]
            {
                new Message(),
                new Message()
            };
        }

        public void Save(Message message)
        {
            
        }

        public Message GetReport()
        {
            return new Message();
        }
    }
}
