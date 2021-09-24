using AP.Processing.Sync;
using System.Collections.Generic;

namespace AP.Host.Console
{
    public class HandlerFactory
    {
        Dictionary<string, IHandler> handlers = new Dictionary<string, IHandler>();

        public void Set(string name, IHandler handler)
        {
            handlers[name] = handler;
        }

        public IHandler Get(string name)
        {
            return handlers[name];
        }
    }
}
