using AP.Data;

namespace AP.Signals
{
    public interface IReceiptFactory
    {
        Message Get(Message message);
    }
}
