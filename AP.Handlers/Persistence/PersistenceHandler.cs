using AP.Messaging;

namespace AP.Handlers.Persistence
{
    public class PersistenceHandler : IHandler
    {
        private IMessageStorage storage;

        public PersistenceHandler(IMessageStorage storage)
        {
            this.storage = storage;
        }

        public virtual void Handle(Message message, IOutput output)
        {
            storage.Save(message);
        }
    }
}
