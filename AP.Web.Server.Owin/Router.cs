using Microsoft.Owin;
using System.Collections.Generic;
using System.Linq;

namespace AP.Web.Server.Owin
{
    public class Router
    {
        private List<Route> routes = new List<Route>();

        public void Add(Route route)
        {
            routes.Add(route);
        }

        public void Route(IOwinRequest request, IOwinResponse response)
        {
            var route = GetRoute(request);
            var input = new WebInput(route.Path, request);
            var output = new WebOutput(response);
            route.Service.Handle(input, output);
        }

        private Route GetRoute(IOwinRequest request)
        {
            var url = request.Uri.AbsolutePath;
            var method = request.Method;
            return routes.First(r => r.Matches(method, url));
        }
    }
}
