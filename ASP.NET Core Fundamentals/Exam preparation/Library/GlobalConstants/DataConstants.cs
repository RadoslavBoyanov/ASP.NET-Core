namespace Library.GlobalConstants
{
    /// <summary>
    /// Constants for validations
    /// </summary>
    public static class DataConstants
    {
        /// <summary>
        /// Constants for class Book
        /// </summary>
        public static class Book
        {
            public const int TitleMaxLength = 50;
            public const int TitleMinLength = 10;

            public const int AuthorMaxLength = 50;
            public const int AuthorMinLength = 5;

            public const int DescriptionMaxLength = 5000;
            public const int DescriptionMinLength = 5;

            public const int RatingMaxDecimal = 10;
            public const int RatingMinDecimal = 0;
        }

        /// <summary>
        /// Constants for class Category
        /// </summary>
        public static class Category
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 5;
        }
    }
}
