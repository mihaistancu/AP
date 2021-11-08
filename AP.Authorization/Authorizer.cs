using AP.Cookies;
using AP.Http;
using AP.Identity;

namespace AP.Authorization
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
            var parser = new CookieParser(input);
            var cookie = parser.Get("auth");
            var claims = storage.Get(cookie.Value);
            var result = claims.Has("group", "operators");
            return true;
        }

        public bool AllowAuthenticated(IHttpInput input)
        {
            return true;
        }
    }
}
