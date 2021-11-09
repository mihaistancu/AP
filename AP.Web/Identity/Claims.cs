using System.Collections.Generic;

namespace AP.Web.Identity
{
    public class Claims
    {
        private List<KeyValuePair<string, string>> claims = new List<KeyValuePair<string, string>>();

        public void Add(string key, string value)
        {
            claims.Add(new KeyValuePair<string, string>(key, value));
        }

        public bool Has(string key, string value)
        {
            return claims.Contains(new KeyValuePair<string, string>(key, value));
        }
    }
}
