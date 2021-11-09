using AP.Http;
using AP.Web.Identity;
using System;

namespace AP.Web.Authentication
{
    public class Authenticator
    {
        private ActiveDirectory activeDirectory;
        private ClaimsStorage storage;

        public Authenticator(
            ActiveDirectory activeDirectory, 
            ClaimsStorage storage)
        {
            this.activeDirectory = activeDirectory;
            this.storage = storage;
        }

        public void Authenticate(IHttpInput input, IHttpOutput output)
        {
            var (username, password) = Credentials.Parse(input);
            bool isValid = activeDirectory.IsValid(username, password);
            
            if (isValid)
            {
                var token = Guid.NewGuid().ToString();
                var claims = GetClaims(username);
                output.AddCookie("auth", token);
                storage.Set(token, claims);
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
    }
}
