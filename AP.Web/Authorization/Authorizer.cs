using System.Linq;
using AP.Http;
using AP.Web.Files;
using AP.Web.Identity;

namespace AP.Web.Authorization
{
    public class Authorizer
    {
        private const string OperatorsGroup = "AD-operators";
        private const string AdministratorsGroup = "AD-administrators";
        private const string SecurityOfficersGroup = "AD-security-officers";
        
        private ClaimsStorage storage;

        public Authorizer(ClaimsStorage storage)
        {
            this.storage = storage;
        }

        public HttpHandler AllowOperators(HttpHandler handle)
        {
            return AllowApi(handle, OperatorsGroup, AdministratorsGroup, SecurityOfficersGroup);
        }

        public HttpHandler AllowAdministrators(HttpHandler handle)
        {
            return AllowApi(handle, AdministratorsGroup, SecurityOfficersGroup);
        }

        public HttpHandler AllowSecurityOfficers(HttpHandler handle)
        {
            return AllowApi(handle, SecurityOfficersGroup);
        }

        private HttpHandler AllowApi(HttpHandler handle, params string[] groups)
        {
            return (input, output) =>
            {
                var token = input.GetCookie("auth");

                if (token == null)
                {
                    output.Status(401);
                }
                else if (IsAllowed(token, groups))
                {
                    handle(input, output);
                }
                else
                {
                    output.Status(403);
                }
            };
        }

        public HttpHandler AllowStaticFile(HttpHandler handle)
        {
            return (input, output) =>
            {
                var token = input.GetCookie("auth");

                if (token == null)
                {
                    output.Status(401);
                    Login.Serve(output);
                }
                else if (IsAllowed(token, OperatorsGroup, AdministratorsGroup, SecurityOfficersGroup))
                {
                    handle(input, output);
                }
                else
                {
                    output.Status(403);
                    Login.Serve(output);
                }
            };
        }

        private bool IsAllowed(string token, params string[] groups)
        {
            var claims = storage.Get(token);
            return groups.Any(group => claims.Has("group", group));
        }
    }
}
