namespace AP.Processing.Async.CDM.Request
{
    public class CdmRequestWorker : IWorker
    {
        private ICdmProvider responder;

        public CdmRequestWorker(ICdmProvider responder)
        {
            this.responder = responder;
        }

        public virtual bool Handle(Message message)
        {
            responder.Respond(message);
            return true;
        }
    }
}
