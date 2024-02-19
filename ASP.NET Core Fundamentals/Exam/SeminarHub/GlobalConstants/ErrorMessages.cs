using static SeminarHub.GlobalConstants.DataConstants.Seminar;
namespace SeminarHub.GlobalConstants
{
    /// <summary>
    /// Errors constants for view models
    /// </summary>
    public static class ErrorMessages
    {
        public const string RequireErrorMessage = "The field {0} is required";
        public const string StringLengthErrorMessage = "The field {0} must be between {2} and {1} characters long";
        public const string DateErrorMessage = $"Invalid date! Format must be: {DateAndTimeFormat}";
    }
}
