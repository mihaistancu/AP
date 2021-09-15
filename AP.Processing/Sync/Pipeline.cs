namespace AP.Processing.Sync
{
    public class Pipeline
    {
        private IHandler[] handlers;

        public Pipeline(params IHandler[] handlers)
        {
            this.handlers = handlers;
        }

        public virtual Message Process(Message message)
        {   
            foreach (var handler in handlers)
            {
                var (canContinue, newMessage) = handler.Handle(message);

                if (!canContinue) return newMessage;
            }

            return null;
        }
    }
}