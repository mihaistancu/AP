namespace AP.Processing.Sync.Handlers
{
    public class PersistenceHandler : IHandler
    {
        public virtual bool Handle(Message message)
        {
            return true;
        }
    }
}
