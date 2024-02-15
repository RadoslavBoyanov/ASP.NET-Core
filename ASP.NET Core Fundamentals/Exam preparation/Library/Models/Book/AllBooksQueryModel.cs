namespace Library.Models.Book
{
    /// <summary>
    /// collection of books
    /// </summary>
    public class AllBooksQueryModel
    {
        public ICollection<BookInfoViewModel> Books { get; set; } = new List<BookInfoViewModel>();
    }
}
