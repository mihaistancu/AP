namespace AP.Processing.Async.IR.Request
{
    public class IrRequestWorker : IWorker
    {
        private IIrProvider publisher;
        
        public IrRequestWorker(IIrProvider publisher)
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
