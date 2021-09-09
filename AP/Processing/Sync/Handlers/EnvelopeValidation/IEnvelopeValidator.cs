using AP.Data;

namespace AP.Processing.Sync.Handlers.EnvelopeValidation
{
    public interface IEnvelopeValidator
    {
        void Validate(Message message);
    }
}
