namespace AP.Processing.Async.CDM.Request
{
    public class CdmRequestWorker : IWorker
    {
        private ICdmProvider provider;

        public CdmRequestWorker(ICdmProvider provider)
        {
            this.provider = provider;
        }

        public virtual bool Handle(Message message)
        {
            provider.Respond(message);
            return true;
        }
    }
}
