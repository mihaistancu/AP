using AP.Http;
using AP.Web.Authentication;
using AP.Web.Files;

namespace AP.Web.Routes
{
    public class LoginRoutes
    {
        private FileServer server;
        private Authenticator authenticator;

        public LoginRoutes(FileServer server, Authenticator authenticator)
        {
            this.server = server;
            this.authenticator = authenticator;
        }

        public void Apply(IHttpServer server)
        {
            server.Map("GET", "/login", ServeLoginPage, AllowAnyone);
            server.Map("POST", "/login", authenticator.Authenticate, AllowAnyone);
        }

        private void ServeLoginPage(IHttpInput input, IHttpOutput output)
        {
            server.Serve("login/index.html", output);
        }

        private bool AllowAnyone(IHttpInput input)
        {
            return true;
        }
    }
}
