namespace AP.Tests.TestDoubles
{
    public class ProcessorSpy : IProcessor
    {
        public bool ProcessWasCalled { get; private set; }

        public bool ThrowException { get; set; }

        public void Process(Message message)
        {
            if (ThrowException)
            {
                throw new System.Exception();
            }
            ProcessWasCalled = true;    
        }
    }
}
