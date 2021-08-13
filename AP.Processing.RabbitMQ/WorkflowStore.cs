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
                { Id(business), business },
                { Id(cdmRequest), cdmRequest },
                { Id(cdmSync), cdmSync },
                { Id(cdmVersion), cdmVersion },
                { Id(irRequest), irRequest },
                { Id(irSync), irSync }
            };
        }

        public IWorkflow GetWorkflow(string key)
        {
            return workflows[key];
        }

        public string GetKey(IWorkflow workflow)
        {
            return Id(workflow);
        }

        private string Id(IWorkflow workflow)
        {
            return workflow.GetType().Name;
        }
    }
}
