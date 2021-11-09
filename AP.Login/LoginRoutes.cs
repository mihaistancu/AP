using AP.Authentication;
using AP.Http;
using AP.Identity;

namespace AP.Login
{
    public class LoginRoutes
    {
        private EmbeddedResourceServer server;
        private Authenticator authenticator;
        private ClaimsStorage storage;

        public LoginRoutes(
            EmbeddedResourceServer server, 
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
            server.Serve("login.html", output);
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
