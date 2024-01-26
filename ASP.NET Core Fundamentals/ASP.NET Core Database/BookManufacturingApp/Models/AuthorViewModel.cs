namespace BookManufacturingApp.Models
{
    public class AuthorViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string Nationality { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Biography { get; set; }

        // You may include other properties or methods as needed

        public List<BookViewModel> Books { get; set; }
    }
}
