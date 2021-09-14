using AP.Processing.Async.CDM.Report;

namespace AP.CDM
{
    public class CdmReporter : ICdmReporter
    {
        private CdmStorage storage;
        private ICdmRouter router;

        public CdmReporter(CdmStorage storage, ICdmRouter router)
        {
            this.storage = storage;
            this.router = router;
        }

        public void Report()
        {
            var message = storage.GetReport();
            router.Route(message);
        }
    }
}
