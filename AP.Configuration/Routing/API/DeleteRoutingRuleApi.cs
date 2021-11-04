﻿using AP.IO;

namespace AP.Configuration.Routing.API
{
    public class DeleteRoutingRuleApi : IWebHandler
    {
        private IRoutingRuleStorage storage;

        public DeleteRoutingRuleApi(IRoutingRuleStorage storage)
        {
            this.storage = storage;
        }

        public void Handle(IWebInput input, IWebOutput output)
        {
            string id = input.Get("id");
            storage.Delete(id);
            output.Status(204);
        }
    }
}
