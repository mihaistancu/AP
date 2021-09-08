﻿using AP.AS4;
using AP.AS4.ReceiptFactories;
using AP.Async;
using AP.Async.Workflows;
using AP.Sync;
using AP.Sync.Pipelines;

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
            var controller = new Controller(
                GetPipeline(url),
                GetWorkflow(message),
                GetBroker(),
                GetErrorFactory(),
                GetReceiptFactory(url));
            return controller.Handle(message);
        }

        private Pipeline GetPipeline(string url)
        {
            return url.Contains("Inbound")
                ? (Pipeline)provider.Get<DecryptionPipeline>()
                : (Pipeline)provider.Get<SignatureCheckPipeline>();
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

        private IErrorFactory GetErrorFactory()
        {
            return provider.Get<As4ErrorFactory>();
        }

        private IReceiptFactory GetReceiptFactory(string url)
        {
            return url.Contains("System")
                ? (IReceiptFactory)provider.Get<EmptyReceiptFactory>()
                : (IReceiptFactory)provider.Get<As4ReceiptFactory>();
        }
    }
}
