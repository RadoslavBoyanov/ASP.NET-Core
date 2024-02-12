namespace Homies.GlobalConstants
{
    public static class EntityValidations
    {
        /// <summary>
        /// Validations for class Event
        /// </summary>
        public static class Event
        {
            /// <summary>
            /// Event name maximum length of the string
            /// </summary>
            public const int EventNameMaxLength = 20;
            /// <summary>
            /// Event name minimum length of the string
            /// </summary>
            public const int EventNameMinLength = 5;

            /// <summary>
            /// Event description maximum length of the string
            /// </summary>
            public const int EventDescriptionMaxLength = 150;

            /// <summary>
            /// Event description minimum length of the string
            /// </summary>
            public const int EventDescriptionMinLength = 15;


            /// <summary>
            /// Date time format for CreatedOn, Start and End
            /// </summary>
            public const string DateTimeFormat = "yyyy-MM-dd H:mm";
        }

        /// <summary>
        /// Validations for class Type
        /// </summary>
        public static class Type
        {

            /// <summary>
            /// Type name maximum length of the string
            /// </summary>
            public const int TypeNameMaxLength = 15;

            /// <summary>
            /// Type name minimum length of the string
            /// </summary>
            public const int TypeNameMinLength = 5;
        }
    }
}
