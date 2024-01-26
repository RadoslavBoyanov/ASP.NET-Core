namespace BookManufacturingApp.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Genre { get; set; }

        public decimal Price { get; set; }

        public string Information { get; set; }

        public int Pages { get; set; }

        public DateTime PrintingDate { get; set; }

        public int AuthorId { get; set; }

        // You may include other properties or methods as needed

        public AuthorViewModel Author { get; set; }
    }
}
