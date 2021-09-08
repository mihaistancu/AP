namespace AP
{
    public interface IIrExportBuilder
    {
        void UseRequest(Message message);
        Message[] Build();
        void UseSubscriptions();
    }
}