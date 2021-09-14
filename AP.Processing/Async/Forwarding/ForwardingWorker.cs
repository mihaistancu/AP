namespace AP.Processing.Async.Forwarding
{
    public class ForwardingWorker : IWorker
    {
        private IContentBasedRouter router;

        public ForwardingWorker(IContentBasedRouter router)
        {
            this.router = router;
        }

        public virtual bool Handle(Message message)
        {
            router.Route(message);
            return true;
        }
    }
}
