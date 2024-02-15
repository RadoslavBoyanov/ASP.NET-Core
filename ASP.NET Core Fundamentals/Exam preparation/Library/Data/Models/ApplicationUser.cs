using Microsoft.AspNetCore.Identity;

namespace Library.Data.Models
{
    /// <summary>
    /// Class for user 
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}
