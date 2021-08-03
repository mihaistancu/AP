namespace AP.Tests.TestDoubles
{
    public class HandlerSpy : IHandler
    {
        public bool WasCalled { get; private set; }
        public bool Returns { get; set; }

        public HandlerSpy()
        {
            Returns = true;
        }

        public bool Handle(Message message)
        {
            WasCalled = true;
            return Returns;
        }
    }
}