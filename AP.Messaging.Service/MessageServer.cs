﻿using AP.Handlers;
using AP.Web.Server;
using System;
using System.Linq;

namespace AP.Messaging.Service
{
    public class MessageServer
    {
        private IWebServer server;
        private Func<string, IHandler> getHandler;

        public MessageServer(IWebServer server, Func<string, IHandler> getHandler)
        {
            this.server = server;
            this.getHandler = getHandler;
        }

        public void Start()
        {
            Map("/Business/Inbound",
                Handler.ValidateTlsCertificate,
                Handler.Decrypt,
                Handler.ValidateEnvelope,
                Handler.Persist,
                Handler.ProcessAsync);

            Map("/Business/Outbox",
                Handler.ValidateTlsCertificate,
                Handler.ValidateSignature,
                Handler.ValidateEnvelope,
                Handler.Persist,
                Handler.ProcessAsync);

            Map("/Business/Inbox",
                Handler.ValidateTlsCertificate,
                Handler.ValidateSignature,
                Handler.ValidateEnvelope,
                Handler.PullRequest);

            Map("/System/Inbound",
                Handler.ValidateTlsCertificate,
                Handler.ValidateSignature,
                Handler.ValidateEnvelope,
                Handler.Persist,
                Handler.ProcessAsync,
                Handler.Receipt);

            Map("/System/Outbox",
                Handler.ValidateTlsCertificate,
                Handler.ValidateSignature,
                Handler.ValidateEnvelope,
                Handler.Persist,
                Handler.ProcessAsync,
                Handler.Receipt);

            Map("/System/Inbox",
                Handler.ValidateTlsCertificate,
                Handler.ValidateSignature,
                Handler.ValidateEnvelope,
                Handler.PullRequest);

            server.Start("http://localhost:9000");
        }

        private void Map(string url, params string[] pipeline)
        {
            var handlers = pipeline.Select(getHandler);
            server.Map("POST", url, new MessageService(handlers));
        }
    }
}
