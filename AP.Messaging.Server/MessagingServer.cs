using AP.Web.Server.Owin;

namespace AP.Messaging.Server
{
    public class MessagingServer : WebServer
    {
        private MessagingService service;

        public MessagingServer(Router router, MessagingService service) : base(router)
        {            
            this.service = service;
        }

        public void Start()
        {
            router.Map("POST", "*", service);
            Start("http://localhost:9000");
        }
    }
}
