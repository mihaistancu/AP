using AP.Configuration.Server.Routing;
using AP.Configuration.Server.Settings;
using AP.Web.Server.Owin;

namespace AP.Configuration.Server
{
    public class ConfigurationServer : WebServer
    {
        private GetAllRulesApi getAllRulesApi;
        private AddRuleApi addRuleApi;
        private UpdateRuleApi updateRuleApi;
        private DeleteRuleApi deleteRuleApi;
        private GetAllSettingsApi getAllSettingsApi;
        private UpdateSettingApi updateSettingApi;

        public ConfigurationServer(
            GetAllRulesApi getAllRulesApi,
            AddRuleApi addRuleApi,
            UpdateRuleApi updateRuleApi,
            DeleteRuleApi deleteRuleApi,
            GetAllSettingsApi getAllSettingsApi,
            UpdateSettingApi updateSettingApi,
            Router router) 
            : base(router)
        {
            this.getAllRulesApi = getAllRulesApi;
            this.addRuleApi = addRuleApi;
            this.updateRuleApi = updateRuleApi;
            this.deleteRuleApi = deleteRuleApi;
            this.getAllSettingsApi = getAllSettingsApi;
            this.updateSettingApi = updateSettingApi;
        }

        public void Start()
        {
            router.Map("GET", "/routing-rules", getAllRulesApi);
            router.Map("POST", "/routing-rules", addRuleApi);
            router.Map("PUT", "/routing-rules/{id}", updateRuleApi);
            router.Map("DELETE", "/routing-rules/{id}", deleteRuleApi);

            router.Map("GET", "/settings", getAllSettingsApi);
            router.Map("PUT", "/settings/{id}", updateSettingApi);

            Start("http://localhost:9090");
        }
    }
}
