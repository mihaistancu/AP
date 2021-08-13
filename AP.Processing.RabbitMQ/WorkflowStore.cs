using AP.Processing.Workflows;
using System.Collections.Generic;

namespace AP.Processing.RabbitMQ
{
    public class WorkflowStore
    {
        private Dictionary<string, IWorkflow> workflows;

        public WorkflowStore(
            BusinessWorkflow business,
            CdmRequestWorkflow cdmRequest,
            CdmSyncWorkflow cdmSync,
            CdmVersionWorkflow cdmVersion,
            IrRequestWorkflow irRequest,
            IrSyncWorkflow irSync)
        {
            workflows = new Dictionary<string, IWorkflow>
            {
                { "business", business },
                { "cdmrequest", cdmRequest },
                { "cdmsync", cdmSync },
                { "cdmversion", cdmVersion },
                { "irrequest", irRequest },
                { "irsync", irSync }
            };
        }

        public IWorkflow Get(string key)
        {
            return workflows[key];
        }
    }
}
