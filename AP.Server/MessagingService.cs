using AP.Processing.Sync;

namespace AP.Server
{
    public class MessagingService : IService
    {
        private Parser parser;
        private IPipelineConfig config;

        public MessagingService(Parser parser, IPipelineConfig config)
        {
            this.parser = parser;
            this.config = config;
        }

        public virtual void Handle(IInput input, IOutput output)
        {
            var message = parser.Parse(input.GetBody());
            var pipeline = config.GetPipeline(input.GetUrl());
            pipeline.Process(message, output);
        }
    }
}
