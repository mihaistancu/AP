using AP.Http;
using AP.Web.Authentication;
using AP.Web.Identity;
using AP.Web.Files;

namespace AP.Web.Routes
{
    public class LoginRoutes
    {
        private FileServer server;
        private Authenticator authenticator;
        private ClaimsStorage storage;

        public LoginRoutes(
            FileServer server,
            Authenticator authenticator,
            ClaimsStorage storage)
        {
            this.server = server;
            this.authenticator = authenticator;
            this.storage = storage;
        }

        public void Apply(IHttpServer server)
        {
            server.Map("GET", "/login", ServeLoginPage, AllowAnyone);
            server.Map("POST", "/login", Authenticate, AllowAnyone);
        }

        private void ServeLoginPage(IHttpInput input, IHttpOutput output)
        {
            server.Serve("login/index.html", output);
        }

        private void Authenticate(IHttpInput input, IHttpOutput output)
        {
            var reader = new CredentialsReader(input);
            var result = authenticator.Authenticate(reader.Username, reader.Password);
            if (result.IsAuthenticated)
            {
                storage.Set("", result.Claims);
            }
        }

        private bool AllowAnyone(IHttpInput input)
        {
            return true;
        }
    }
}
