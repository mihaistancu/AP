using AP.Data;

namespace AP.Processing.Sync.EnvelopeValidation
{
    public interface IEnvelopeValidator
    {
        void Validate(Message message);
    }
}
