using AP.Data;

namespace AP.Processing.Sync.Handlers.Validation
{
    public interface IEnvelopeValidator
    {
        void Validate(Message message);
    }
}
