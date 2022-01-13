using AP.Messages;

namespace AP.Handlers.Receipt
{
    public interface IReceiptFactory
    {
        Message Get(Message message);
    }
}
