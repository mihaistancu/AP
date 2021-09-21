using AP.Web.Server.Owin;

namespace AP.Configuration.API
{
    public class ConfigurationServer : WebServer
    {
        private RoutingApi routingApi;

        public ConfigurationServer(
            RoutingApi routingApi, 
            Router router) : base(router)
        {
            this.routingApi = routingApi;
        }

        public void Start()
        {
            router.Map("GET", "/routing-rules", routingApi.GetRoutingRules);
            router.Map("POST", "/routing-rules", routingApi.SaveNewRoutingRule);
            router.Map("PUT", "/routing-rules/{id}", routingApi.UpdateRoutingRule);
            router.Map("DELETE", "/routing-rules/{id}", routingApi.DeleteRoutingRule);
            base.Start("http://localhost:9090");
        }
    }
}
