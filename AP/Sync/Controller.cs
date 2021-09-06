using System;

namespace AP.Sync
{
    public class Controller
    {
        private IProcessor syncProcessor;
        private IProcessor asyncProcessor;
        private ISignal signal;

        public Controller(IProcessor syncProcessor, IProcessor asyncProcessor, ISignal signal)
        {
            this.syncProcessor = syncProcessor;
            this.asyncProcessor = asyncProcessor;
            this.signal = signal;
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
                return signal.Error(exception);
            }

            return signal.Receipt();
        }
    }
}