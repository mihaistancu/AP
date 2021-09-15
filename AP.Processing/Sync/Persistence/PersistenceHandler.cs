namespace AP.Processing.Sync.Persistence
{
    public class PersistenceHandler : IHandler
    {
        private IMessageStorage storage;

        public PersistenceHandler(IMessageStorage storage)
        {
            this.storage = storage;
        }

        public virtual (bool, Message) Handle(Message message)
        {
            storage.Save(message);
            return (true, null);
        }
    }
}
