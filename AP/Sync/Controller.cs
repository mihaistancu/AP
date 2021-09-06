using System;

namespace AP.Sync
{
    public class Controller
    {
        private IProcessor syncProcessor;
        private ISignal responder;
        private IProcessor asyncProcessor;

        public Controller(IProcessor syncProcessor, ISignal signal, IProcessor asyncProcessor)
        {
            this.syncProcessor = syncProcessor;
            responder = signal;
            this.asyncProcessor = asyncProcessor;
        }

        public string Handle(Message message)
        {
            try
            {
                syncProcessor.Process(message);
                asyncProcessor.Process(message);
            }
            catch (Exception exception)
            {
                return responder.Error(exception);
            }

            return responder.Receipt();
        }
    }
}