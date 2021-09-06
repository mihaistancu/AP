using AP.Receiver.Handlers;

namespace AP.Receiver.Pipelines
{
    public class DecryptionPipeline: Pipeline
    {
        public DecryptionPipeline(IStore store): base(
            store.Get<TlsCheckHandler>(),
            store.Get<DecryptionHandler>(),
            store.Get<ValidationHandler>(),
            store.Get<PersistenceHandler>())
        {
        }
    }
}
