namespace AP
{
    public class Bridge
    {
        private IHandler handler;

        public Bridge()
        {
        }

        public void Send(ProcessingRequest request)
        {
            handler.Handle(request);
        }

        public void Setup(string v, IHandler step)
        {
            this.handler = step;    
        }
    }
}