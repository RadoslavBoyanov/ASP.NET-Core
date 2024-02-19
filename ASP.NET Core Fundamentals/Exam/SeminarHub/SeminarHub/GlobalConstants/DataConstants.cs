namespace SeminarHub.GlobalConstants
{
    /// <summary>
    /// Validations for data models and view models
    /// </summary>
    public static class DataConstants
    {
        /// <summary>
        /// Constants for seminar
        /// </summary>
        public static class Seminar
        {
            public const int TopicMaxLength = 100;
            public const int TopicMinLength = 3;

            public const int LecturerMaxLength = 60;
            public const int LecturerMinLength = 5;

            public const int DetailsMaxLength = 500;
            public const int DetailsMinLength = 10;

            public const int DurationMaxRange = 180;
            public const int DurationMinRange = 30;

            public const string DateAndTimeFormat = "dd/MM/yyyy HH:mm";
        }


        /// <summary>
        /// Constants for Category
        /// </summary>
        public static class Category
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 3;
        }
    }
}
