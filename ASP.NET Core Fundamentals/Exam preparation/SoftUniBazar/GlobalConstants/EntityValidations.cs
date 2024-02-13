namespace SoftUniBazar.GlobalConstants
{/// <summary>
/// Entity validations
/// </summary>
    public static class EntityValidations
    {
        /// <summary>
        /// Validations for class Ad
        /// </summary>
        public static class Ad
        {
            /// <summary>
            /// Ad name maximum string length
            /// </summary>
            public const int AdNameMaxLength = 25;
            /// <summary>
            /// Ad name minimum string length
            /// </summary>
            public const int AdNameMinLength = 5;

            /// <summary>
            /// Ad description maximum string length
            /// </summary>
            public const int AdDescriptionMaxLength = 250;
            /// <summary>
            /// Ad description minimum string length
            /// </summary>
            public const int AdDescriptionMinLength = 15;


            /// <summary>
            /// Ad date time format for CreatedOn
            /// </summary>
            public const string DateTimeFormat = "yyyy-MM-dd H:mm";
        }

        /// <summary>
        /// Validations for class Category
        /// </summary>
        public static class Category
        {
            /// <summary>
            /// Category name maximum string length
            /// </summary>
            public const int CategoryNameMaxLength = 15;
            /// <summary>
            /// Category name minimum string length
            /// </summary>
            public const int CategoryNameMinLength = 3;
        }
    }
}
