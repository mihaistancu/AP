using AP.Receiver.Handlers;

namespace AP.Receiver.Pipelines
{
    public class SignatureCheckPipeline : Pipeline
    {
        public SignatureCheckPipeline(IStore store): base(
            store.Get<TlsCheckHandler>(),
            store.Get<SignatureCheckHandler>(),
            store.Get<ValidationHandler>(),
            store.Get<PersistenceHandler>())
        {
        }
    }
}
