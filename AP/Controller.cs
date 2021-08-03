using AP.Receiver;

namespace AP
{
    public class Controller
    {
        private Pipeline pipeline;

        public Controller(Pipeline pipeline)
        {
            this.pipeline = pipeline;
        }

        public void Handle(Message message)
        {
            pipeline.Process(message);
        }
    }
}