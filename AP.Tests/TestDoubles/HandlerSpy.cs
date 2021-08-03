using AP.Receiver;

namespace AP.Tests.TestDoubles
{
    public class HandlerSpy : IHandler
    {
        public bool HandleWasCalled { get; private set; }
        public bool Returns { get; set; }

        public HandlerSpy()
        {
            Returns = true;
        }

        public bool Handle(Message message)
        {
            HandleWasCalled = true;
            return Returns;
        }
    }
}