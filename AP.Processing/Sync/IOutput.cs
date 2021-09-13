namespace AP.Processing.Sync
{
    public interface IOutput
    {
        void Send();
        void Buffer(Message error);
    }
}
