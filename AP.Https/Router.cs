﻿using Microsoft.Owin;
using System.Collections.Generic;

namespace AP.Https
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
            var method = request.Method;
            var url = request.Uri.AbsolutePath;
            var parameters = new Dictionary<string, string>();

            foreach (var route in routes)
            {
                var isMatched = route.Matches(method, url, parameters);

                if (isMatched)
                {
                    var input = new HttpInput(parameters, request);
                    var output = new HttpOutput(response);
                    route.Service.Handle(input, output);
                    return;
                }
            }

            response.StatusCode = 404;
        }
    }
}
