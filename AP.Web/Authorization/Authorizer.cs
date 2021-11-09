using AP.Http;
using AP.Web.Cookies;
using AP.Web.Identity;

namespace AP.Web.Authorization
{
    public class Authorizer
    {
        private ClaimsStorage storage;

        public Authorizer(ClaimsStorage storage)
        {
            this.storage = storage;
        }

        public bool AllowOperators(IHttpInput input)
        {
            var parser = new CookieReader(input);
            var cookie = parser.Get("auth");
            var claims = storage.Get(cookie.Value);
            var result = claims.Has("group", "operators");
            return true;
        }

        public bool AllowAuthenticated(IHttpInput input)
        {
            return true;
        }

        public bool AllowAnonymous(IHttpInput input)
        {
            return true;
        }
    }
}
