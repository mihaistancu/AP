using Microsoft.Owin.Hosting;
using Newtonsoft.Json.Converters;
using Owin;
using System;
using System.Web.Http;

namespace AP.Portal.WebApi
{
    public class ApiServer
    {
        public IDisposable Start(string url)
        {
            return WebApp.Start(url, OnStartup);
        }

        private void OnStartup(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new StringEnumConverter());
            appBuilder.UseWebApi(config);
        }
    }
}
