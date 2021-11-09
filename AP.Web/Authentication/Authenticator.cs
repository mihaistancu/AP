using AP.Http;
using AP.Web.Cookies;
using AP.Web.Identity;

namespace AP.Web.Authentication
{
    public class Authenticator
    {
        private ActiveDirectory activeDirectory;
        private ClaimsStorage storage;

        public Authenticator(ActiveDirectory activeDirectory, ClaimsStorage storage)
        {
            this.activeDirectory = activeDirectory;
            this.storage = storage;
        }

        public void Authenticate(IHttpInput input, IHttpOutput output)
        {
            var reader = new CredentialsReader(input);
            bool isValid = activeDirectory.IsValid(reader.Username, reader.Password);
            
            if (isValid)
            {
                var claims = new Claims();
                var cookie = new Cookie();
                var writer = new CookieWriter(output);
                writer.Write(cookie);
                storage.Set(cookie.Value, claims);
            }
        }
    }
}
