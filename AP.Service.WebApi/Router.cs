using AP.Async;
using AP.Async.Workflows;
using AP.Sync;
using AP.Sync.Pipelines;
using AP.Sync.Signals;

namespace AP.Service.WebApi
{
    public class Router
    {
        private readonly IProvider provider;

        public Router(IProvider provider)
        {
            this.provider = provider;
        }

        public string Route(string url, Message message)
        {
            var pipeline = GetPipeline(url);
            var signal = GetSignal(url);
            var workflow = GetWorkflow(message);
            var broker = GetBroker();
            var controller = new Controller(pipeline, workflow, signal, broker);
            return controller.Handle(message);
        }

        private Pipeline GetPipeline(string url)
        {
            return url.Contains("Inbound")
                ? (Pipeline)provider.Get<DecryptionPipeline>()
                : (Pipeline)provider.Get<SignatureCheckPipeline>();
        }

        private ISignal GetSignal(string url)
        {
            return url.Contains("System")
                ? (ISignal)provider.Get<ReceiptAndErrorSignal>()
                : (ISignal)provider.Get<ErrorOnlySignal>();
        }

        private Workflow GetWorkflow(Message message)
        {
            switch (message.SedType)
            {
                case "SYN001": return provider.Get<IrSyncWorkflow>();
                case "SYN002": return provider.Get<IrRequestWorkflow>();
                case "SYN003": return provider.Get<CdmSyncWorkflow>();
                case "SYN004": return provider.Get<CdmRequestWorkflow>();
                case "SYN005": return provider.Get<CdmVersionWorkflow>();
                default: return provider.Get<BusinessWorkflow>();
            }
        }

        private MessageBroker GetBroker()
        {
            return provider.Get<MessageBroker>();
        }
    }
}
