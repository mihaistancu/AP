namespace AP.Processing.Sync
{
    public class Pipeline: IHandler
    {
        private IHandler[] handlers;

        public Pipeline(params IHandler[] handlers)
        {
            this.handlers = handlers;
        }

        public virtual void Handle(Message message, IOutput output)
        {   
            foreach (var handler in handlers)
            {
                handler.Handle(message, output);

                if (output.IsMessageSent()) return;
            }
        }
    }
}