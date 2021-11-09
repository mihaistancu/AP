using AP.Http;
using AP.Web.Cookies;
using AP.Web.Identity;

namespace AP.Web.Authentication
{
    public class Authenticator
    {
        private ActiveDirectory activeDirectory;
        private CookieFactory factory;
        private ClaimsStorage storage;

        public Authenticator(
            ActiveDirectory activeDirectory, 
            CookieFactory factory,
            ClaimsStorage storage)
        {
            this.activeDirectory = activeDirectory;
            this.factory = factory;
            this.storage = storage;
        }

        public void Authenticate(IHttpInput input, IHttpOutput output)
        {
            var reader = new CredentialsReader(input);
            bool isValid = activeDirectory.IsValid(reader.Username, reader.Password);
            
            if (isValid)
            {
                var claims = GetClaims(reader.Username);
                var cookie = SetAuthenticationCookie(output);
                storage.Set(cookie.Value, claims);
            }
            else
            {
                output.Status(401);
            }
        }

        private Claims GetClaims(string username)
        {
            var groups = activeDirectory.Groups(username);
            var claims = new Claims();
            foreach (var group in groups)
            {
                claims.Add("group", group);
            }
            return claims;
        }

        private Cookie SetAuthenticationCookie(IHttpOutput output)
        {
            var cookie = factory.CreateAuthenticationCookie();
            var writer = new CookieWriter(output);
            writer.Write(cookie);
            return cookie;
        }
    }
}
