namespace DemoApp.Core
{
    public class AuthorizationConstants
    {
        public static class Roles
        {
            public const string ADMINISTRATORS = "Administrators";
            public const string CUSTOMERS = "Customers";

            public const string ADMINISTRATORS_CUSTOMERS = "Administrators,Members";
        }

        public const string DEFAULT_PASSWORD = "Pass@word1";
    }
}
