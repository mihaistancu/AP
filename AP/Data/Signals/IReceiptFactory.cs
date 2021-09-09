using AP.Data;

namespace AP.Signals
{
    public interface IReceiptFactory
    {
        string Get(Message message);
    }
}
