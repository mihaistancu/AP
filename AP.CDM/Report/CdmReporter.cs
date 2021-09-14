using AP.Processing;
using AP.Processing.Async.CDM.Report;

namespace AP.CDM.Report
{
    public class CdmReporter : ICdmReporter
    {
        private CdmReportRequestParser parser;
        private CdmStorage storage;
        private IRouter router;

        public CdmReporter(
            CdmReportRequestParser parser, 
            CdmStorage storage, 
            IRouter router)
        {
            this.parser = parser;
            this.storage = storage;
            this.router = router;
        }

        public void Report(Message message)
        {
            var request = parser.Parse(message);
            var newMessage = storage.GetReport();
            router.Route(request.Requester, newMessage);
        }
    }
}
