using static SeminarHub.GlobalConstants.DataConstants.Seminar;

namespace SeminarHub.Models.Seminar
{
    /// <summary>
    /// View model for All and Joined method
    /// </summary>
    public class SeminarAllViewModel
    {
        public SeminarAllViewModel(int id ,string topic, string lecturer, string organizer, string category, DateTime dateAndTime)
        {
            Id = id;
            Topic = topic;
            Lecturer = lecturer;
            Organizer = organizer;
            Category = category;
            DateAndTime = dateAndTime.ToString(DateAndTimeFormat);
        }

        public int Id { get; set; }

        public string Topic { get; set; }

        public string Lecturer { get; set; }

        public string Organizer { get; set; } 

        public string Category { get; set; }

        public string DateAndTime { get; set; }
    }
}
