﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AP.Tests
{
    [TestClass]
    public class MessageBrokerTests
    {
        private MockMessageBroker broker;

        [TestInitialize]
        public void Initialize()
        {
            broker = new MockMessageBroker();
        }

        [TestMethod]
        public void CanTriggerProcessingStep()
        {
            var handler = new SpyHandler();
            broker.Setup("step", handler);

            var request = new ProcessingRequest();
            request.Step = "step";
            broker.Send(request);

            Assert.IsTrue(handler.WasCalled);
        }

        [TestMethod]
        public void CanTriggerDifferentProcessingSteps()
        {
            var handler1 = new SpyHandler();
            var handler2 = new SpyHandler();
            broker.Setup("step1", handler1);
            broker.Setup("step2", handler2);

            var request1 = new ProcessingRequest();
            request1.Step = "step1";
            broker.Send(request1);

            var request2 = new ProcessingRequest();
            request2.Step = "step2";
            broker.Send(request2);

            Assert.IsTrue(handler1.WasCalled);
            Assert.IsTrue(handler2.WasCalled);
        }
    }
}
