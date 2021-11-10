using System;

namespace AP.Routing.UseCases
{
    public class CreateGroupWithInstitution
    {
        private RoutingRuleStorage storage;

        public CreateGroupWithInstitution(RoutingRuleStorage storage)
        {
            this.storage = storage;
        }

        public string CreateGroupWith(string institutionId)
        {
            var groupId = Guid.NewGuid().ToString();
            storage.AddInstitutionToGroup(institutionId, groupId);
            return groupId;
        }
    }
}
