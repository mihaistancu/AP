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

        public HttpHandler ApiForOperators(HttpHandler handle)
        {
            return Allow(handle, false, OperatorsGroup, AdministratorsGroup, SecurityOfficersGroup);
        }

        public HttpHandler ApiForAdministrators(HttpHandler handle)
        {
            return Allow(handle, false, AdministratorsGroup, SecurityOfficersGroup);
        }

        public HttpHandler ApiForSecurityOfficers(HttpHandler handle)
        {
            return Allow(handle, false, SecurityOfficersGroup);
        }

        public HttpHandler StaticFilesForOperators(HttpHandler handle)
        {
            return Allow(handle, true, OperatorsGroup, AdministratorsGroup, SecurityOfficersGroup);
        }

        private HttpHandler Allow(HttpHandler handle, bool showLoginOnFailure, params string[] groups)
        {
            return (input, output) =>
            {
                int status = Check(input, groups);

                output.Status(status);

                if (status == 200)
                {
                    handle(input, output);
                }
                else if (showLoginOnFailure)
                {
                    Login.Serve(output);
                }
            };
        }

        private int Check(IHttpInput input, params string[] groups)
        {
            var token = input.GetCookie("auth");
            if (token == null)
            {
                return 401;
            }
            var claims = storage.Get(token);
            if (claims == null)
            {
                return 403;
            }
            if (groups.Any(group => claims.Has("group", group)))
            {
                return 200;
            }
            return 403;
        }
    }
}
