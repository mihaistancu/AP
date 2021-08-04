using AP.Receiver.Handlers;

namespace AP.Receiver
{
    public class PipelineFactory
    {
        private Pipeline businessInbound;
        private Pipeline nonBusinessInbound;

        public PipelineFactory()
        {
            var tlsCheck = new TlsCheckHandler();
            var decryption = new DecryptionHandler();
            var signatureCheck = new SignatureCheckHandler();
            var validation = new ValidationHandler();
            var persistence = new PersistenceHandler();
            
            businessInbound = new Pipeline();
            businessInbound.Add(tlsCheck);
            businessInbound.Add(decryption);
            businessInbound.Add(validation);
            businessInbound.Add(persistence);

            nonBusinessInbound = new Pipeline();
            nonBusinessInbound.Add(tlsCheck);
            nonBusinessInbound.Add(signatureCheck);
            nonBusinessInbound.Add(validation);
            nonBusinessInbound.Add(persistence);
        }

        public Pipeline Create(UseCase useCase, Channel channel)
        {
            if (useCase == UseCase.Business && channel == Channel.Inbound)
            {
                return businessInbound;
            }
            return nonBusinessInbound;
        }
    }
}
