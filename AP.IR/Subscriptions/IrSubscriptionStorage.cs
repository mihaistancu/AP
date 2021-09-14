using System;

namespace AP.IR.Subscriptions
{
    public class IrSubscriptionStorage
    {
        public IrSubscription[] Get()
        {
            return new[]
            {
                new IrSubscription(),
                new IrSubscription()
            };
        }
    }
}
