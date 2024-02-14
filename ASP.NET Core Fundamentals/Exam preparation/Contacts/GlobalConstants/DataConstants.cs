namespace Contacts.GlobalConstants
{
    public static class DataConstants
    {
        public static class ApplicationUser
        {
            public const int ApplicationUserNameMaxLength = 20;
            public const int ApplicationUserNameMinLength = 5;

            public const int ApplicationUserEmailMaxLength = 60;
            public const int ApplicationUserEmailMinLength = 10;

            public const int ApplicationUserPasswordMaxLength = 20;
            public const int ApplicationUserPasswordMinLength = 5;
        }

        public static class Contact
        {
            public const int ContactFirstNameMaxLength = 50;
            public const int ContactFirstNameMinLength = 2;

            public const int ContactLastNameMaxLength = 50;
            public const int ContactLastNameMinLength = 5;

            public const int ContactEmailMaxLength = 60;
            public const int ContactEmailMinLength = 10;

            public const int ContactPhoneNumberMaxLength = 13;
            public const int ContactPhoneNumberMinLength = 10;

            public const string ContactWebsiteRegex = @"^((www\.[A-Za-z0-9-]+.bg)|)$";
        }
    }
}
