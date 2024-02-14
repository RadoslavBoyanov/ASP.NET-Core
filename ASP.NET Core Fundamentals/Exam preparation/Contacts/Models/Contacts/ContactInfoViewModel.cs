namespace Contacts.Models.Contact
{
    /// <summary>
    /// Model view for All and My Team
    /// </summary>
    public class ContactInfoViewModel
    {
        public int Id { get; init; }

        public string FirstName { get; set; } 

        public string LastName { get; set; } 

        public string Email { get; set; } 

        public string PhoneNumber { get; set; } 

       
        public string? Address { get; set; }

     
        public string? Website { get; set; }
    }
}
