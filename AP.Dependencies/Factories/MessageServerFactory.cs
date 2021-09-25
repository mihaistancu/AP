using AP.Https;
using AP.Server;

namespace AP.Dependencies.Factories
{
    public class MessageServerFactory
    {
        public static MessageServer Get()
        {
            var handlerFactory = new HandlerFactory();

            return new MessageServer(new OwinWebServer(), handlerFactory.Get);
        }
    }
}
