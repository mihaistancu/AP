﻿using AP.Receiver.Controllers;
using System.Collections.Generic;

namespace AP.Receiver.WebApi
{
    public class Router
    {
        private Dictionary<string, Controller> routes;

        public Router(
            BusinessInboundController businessInbound,
            BusinessOutboxController businessOutbox,
            SystemController system)
        {
            routes = new Dictionary<string, Controller>
            {
                {"/Business/Inbound", businessInbound },
                {"/Business/Outbox", businessOutbox },
                {"/System", system }
            };
        }

        public string Route(string url, Message message)
        {
            var controller = routes[url];
            return controller.Handle(message);
        }
    }
}
