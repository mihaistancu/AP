﻿using AP.Http;
using AP.Web.Authentication;
using AP.Web.Identity;
using System;

namespace AP.Web.Api.Authentication
{
    public class AuthenticationApi
    {
        private ActiveDirectory activeDirectory;
        private ClaimsStorage storage;

        public AuthenticationApi(
            ActiveDirectory activeDirectory,
            ClaimsStorage storage)
        {
            this.activeDirectory = activeDirectory;
            this.storage = storage;
        }

        public void Authenticate(IHttpInput input, IHttpOutput output)
        {
            var (username, password) = Parse(input);
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

        public static (string, string) Parse(IHttpInput input)
        {
            var json = Json.Read(input);

            return (
                json.Value<string>("username"),
                json.Value<string>("password"));
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
