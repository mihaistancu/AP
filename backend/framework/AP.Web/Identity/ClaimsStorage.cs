using System.Collections.Generic;

namespace AP.Web.Identity
{
    public class ClaimsStorage
    {
        Dictionary<string, Claims> store = new Dictionary<string, Claims>();

        public void Set(string id, Claims claims)
        {
            store[id] = claims;
        }

        public Claims Get(string id)
        {
            return store.ContainsKey(id)
                ? store[id]
                : null;
        }
    }
}
