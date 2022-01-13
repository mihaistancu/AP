namespace AP.Web.Authentication
{
    public class ActiveDirectory
    {
        public bool IsValid(string username, string password)
        {
            return username == "op" && password == "pass";
        }

        public string[] Groups(string username)
        {
            if (username == "op")
            {
                return new[] { "AD-operators" };
            }
            else
            {
                return new[] { "AD-administrators" };
            }
        }
    }
}
