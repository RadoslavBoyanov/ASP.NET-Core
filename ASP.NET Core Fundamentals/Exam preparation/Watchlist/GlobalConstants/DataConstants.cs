namespace Watchlist.GlobalConstants
{
    /// <summary>
    /// Validations for entities
    /// </summary>
    public static class DataConstants
    {
        /// <summary>
        /// Validations for entity Movie
        /// </summary>
        public static class Movie
        {
            public const int TitleMaxLength = 50;
            public const int TitleMinLength = 10;

            public const int DirectorMaxLength = 50;
            public const int DirectorMinLength = 5;

            public const int RatingMaxRange = 10;
            public const int RatingMinLength = 0;
        }

        /// <summary>
        /// Validations for entity Genre
        /// </summary>
        public static class Genre
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 5;
        }

        /// <summary>
        /// Validations for entity User
        /// </summary>
        public static class User
        {
            public const int NameMaxLength = 20;
            public const int NameMinLength = 5;

            public const int EmailMaxLength = 60;
            public const int EmailMinLength = 10;

            public const int PasswordMaxLength = 20;
            public const int PasswordMinLength = 5;
        }
    }
}
