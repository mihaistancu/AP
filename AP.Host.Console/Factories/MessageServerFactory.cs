using AP.Messaging.Service;
using AP.Web.Server.Owin;

namespace AP.Host.Console
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
