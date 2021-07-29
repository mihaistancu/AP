namespace AP
{
    public abstract class MessageBroker
    {
        private IHandler handler;

        public MessageBroker()
        {
        }

        public void Send(ProcessingRequest request)
        {
            handler.Handle(request);
        }

        public void Setup(string step, IHandler handler)
        {
            this.handler = handler;
        }
    }
}