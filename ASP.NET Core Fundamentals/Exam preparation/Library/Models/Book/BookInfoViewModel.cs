namespace Library.Models.Book
{
    /// <summary>
    /// View model for All books
    /// </summary>
    public class BookInfoViewModel
    {
        public int Id { get; init; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Rating { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; init; } = string.Empty;
    }
}
