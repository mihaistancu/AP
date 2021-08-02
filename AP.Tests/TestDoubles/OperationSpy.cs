using System.IO;

namespace AP.Tests.TestDoubles
{
    public class OperationSpy : IOperation
    {
        public bool WasCalled { get; set; }

        public void Process(Stream stream)
        {
            WasCalled = true;
        }
    }
}