using AP.Processing;
using AP.Processing.Async.CDM.Report;
using AP.Processing.Async.Workers.CDM.Import;

namespace AP.CDM
{
    public class CdmStorage: ICdmImporter, ICdmReporter
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

        public void Import(Message message)
        {
            
        }

        public Message GetReport()
        {
            return new Message();
        }
    }
}
