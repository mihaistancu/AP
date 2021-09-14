namespace AP.Processing.Async.IR.Request
{
    public class IrRequestWorker : IWorker
    {
        private IIrRequestResponder publisher;
        
        public IrRequestWorker(IIrRequestResponder publisher)
        {
            this.publisher = publisher;
        }

        public virtual bool Handle(Message message)
        {
            publisher.Respond(message);
            return true;
        }
    }
}
