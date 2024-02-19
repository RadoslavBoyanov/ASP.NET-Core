namespace SeminarHub.Models.Seminar
{
    /// <summary>
    /// View model for Delete method
    /// </summary>
    public class SeminarDeleteViewModel
    {
        public int Id { get; set; }

        public string Topic { get; set; }

        public DateTime DateAndTime { get; set; }
    }
}
