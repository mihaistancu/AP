namespace AP.Processing.Sync
{
    public interface IHandler
    {
        void Handle(Message message, IOutput output);
    }
}