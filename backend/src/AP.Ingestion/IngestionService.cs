using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace AP.Ingestion
{
    public class IngestionService
    {
        WebApplication app;
        private IHandlerFactory factory;

        public IngestionService(IHandlerFactory factory)
        {
            this.factory = factory;
            app = WebApplication.CreateBuilder().Build();
        }

        public void Start(string url) 
        {
            app.Run(url);
        }

        private void Apply()
        {
            Map("/Business/Inbound", 
                Handler.ValidateTlsCertificate,
                Handler.Decrypt,
                Handler.ValidateEnvelope,
                Handler.Persist,
                Handler.ProcessAsync);

            Map("/Business/Outbox", 
                Handler.ValidateTlsCertificate,
                Handler.ValidateSignature,
                Handler.ValidateEnvelope,
                Handler.Persist,
                Handler.ProcessAsync);

            Map("/Business/Inbox", 
                Handler.ValidateTlsCertificate,
                Handler.ValidateSignature,
                Handler.ValidateEnvelope,
                Handler.PullRequest);

            Map("/System/Inbound", 
                Handler.ValidateTlsCertificate,
                Handler.ValidateSignature,
                Handler.ValidateEnvelope,
                Handler.Persist,
                Handler.ProcessAsync,
                Handler.Receipt);

            Map("/System/Outbox", 
                Handler.ValidateTlsCertificate,
                Handler.ValidateSignature,
                Handler.ValidateEnvelope,
                Handler.Persist,
                Handler.ProcessAsync,
                Handler.Receipt);

            Map("/System/Inbox", 
                Handler.ValidateTlsCertificate,
                Handler.ValidateSignature,
                Handler.ValidateEnvelope,
                Handler.PullRequest);
        }

        private void Map(string path, params string[] pipeline)
        {
            app.MapPost(path, (HttpRequest request, HttpResponse response) => {
                var input = new MessageInput(request);
                var output = new MessageOutput(response);
                Process(input, output, pipeline);
            });
        }

        private void Process(MessageInput input, MessageOutput output, params string[] pipeline)
        {
            var message = input.GetMessage();
            var handlers = pipeline.Select(factory.Get);

            foreach (var handler in handlers)
            {
                handler.Handle(message, output);

                if (output.IsMessageSent()) return;
            }
        }
    }
}
