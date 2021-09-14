namespace AP.Processing.Async.CDM.Request
{
    public class CdmRequestWorker : IWorker
    {
        private ICdmRequestResponder responder;

        public CdmRequestWorker(ICdmRequestResponder responder)
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
