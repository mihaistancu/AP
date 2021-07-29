using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AP.Tests
{
    [TestClass]
    public class BridgeTests
    {
        [TestMethod]
        public void CanSendProcessingRequest()
        {
            var bridge = new Bridge();

            var request = new ProcessingRequest();

            bridge.Send(request);
        }
    }
}
