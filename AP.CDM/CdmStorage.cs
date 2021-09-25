using AP.Messaging;

namespace AP.CDM
{
    public class CdmStorage
    {
        public Message Get(CdmRequest request)
        {
            return new Message();
        }

        public Message[] Get(CdmSubscription subscription)
        {
            return new[]
            {
                new Message(),
                new Message()
            };
        }
    }
}
