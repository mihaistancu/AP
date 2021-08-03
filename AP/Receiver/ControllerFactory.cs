using AP.Processing;
using AP.Receiver.Handlers;
using AP.Receiver.Responders;

namespace AP.Receiver
{
    public class ControllerFactory
    {
        private Workflow workflow;

        private IHandler tlsCheck = new TlsCheckHandler();
        private IHandler decryption = new DecryptionHandler();
        private IHandler signatureCheck = new SignatureCheckHandler();
        private IHandler validation = new ValidationHandler();
        private IHandler persistence = new PersistenceHandler();

        private IResponder errorOnly = new ErrorOnlyResponder();
        private IResponder receiptAndError = new ReceiptAndErrorResponder();

        private Pipeline businessInbound;
        private Pipeline nonBusinessInbound;

        public ControllerFactory(Workflow workflow)
        {
            this.workflow = workflow;

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

        public Controller Create(UseCase useCase, Channel channel)
        {
            var pipeline = GetPipeline(useCase, channel);
            var responder = GetResponder(useCase);
            return new Controller(pipeline, workflow, responder);
        }

        private Pipeline GetPipeline(UseCase useCase, Channel channel)
        {
            if (useCase == UseCase.Business && channel == Channel.Inbound)
            {
                return businessInbound;
            }
            return nonBusinessInbound;
        }

        private IResponder GetResponder(UseCase useCase)
        {
            if (useCase == UseCase.System)
            {
                return receiptAndError;
            }
            else
            {
                return errorOnly;
            }
        }
    }
}
