namespace AP.Processing.Sync
{
    public class Pipeline
    {
        private IHandler[] handlers;

        public Pipeline(params IHandler[] handlers)
        {
            this.handlers = handlers;
        }

        public virtual void Process(Message message, IOutput output)
        {
            foreach (var handler in handlers)
            {
                var canContinue = handler.Handle(message, output);

                if (!canContinue) return;
            }

            output.Send();
        }
    }
}