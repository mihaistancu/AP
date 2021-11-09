namespace AP.Web.Authentication
{
    public class ActiveDirectory
    {
        public bool IsValid(string username, string password)
        {
            return true;
        }

        public string[] Groups(string username)
        {
            return new[] { "security-officers" };
        }
    }
}
