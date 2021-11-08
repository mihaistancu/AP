using AP.Http;
using AP.Identity;

namespace AP.Login
{
    public class LoginRoutes
    {
        private EmbeddedResourceServer server;
        private ClaimsStorage storage;

        public LoginRoutes(EmbeddedResourceServer server, ClaimsStorage storage)
        {
            this.server = server;
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
            storage.Set("", new Claims());
        }

        private bool AllowAnyone(IHttpInput input) 
        {
            return true;
        }
    }
}
