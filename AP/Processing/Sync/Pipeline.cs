namespace AP.Processing.Sync
{
    public class Pipeline
    {
        private IHandler[] handlers;

        public Pipeline(params IHandler[] handlers)
        {
            this.handlers = handlers;
        }

        public virtual void Process(Message message)
        {
            foreach (var handler in handlers)
            {
                bool canContinue = handler.Handle(message);

                if (!canContinue) break;
            }
        }
    }
}