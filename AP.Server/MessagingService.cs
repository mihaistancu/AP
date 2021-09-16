using AP.Processing.Sync;

namespace AP.Server
{
    public class MessagingService : IService
    {
        private IPipelineConfig config;
        private MessageReader reader;
        private MessageWriter writer;

        public MessagingService(
            IPipelineConfig config, 
            MessageReader reader, 
            MessageWriter writer)
        {
            this.config = config;
            this.reader = reader;
            this.writer = writer;
        }

        public virtual void Handle(IInput input, IOutput output)
        {
            var pipeline = config.GetPipeline(input.GetUrl());
            var message = reader.Read(input.GetBody());
            var newMessage = pipeline.Process(message);
            writer.Write(newMessage, output);
        }
    }
}
