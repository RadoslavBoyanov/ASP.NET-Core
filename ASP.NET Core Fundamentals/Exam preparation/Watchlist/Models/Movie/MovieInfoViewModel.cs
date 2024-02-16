namespace Watchlist.Models.Movie
{

    /// <summary>
    /// View model for All and Watched
    /// </summary>
    public class MovieInfoViewModel
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Director { get; set; }

        public string? ImageUrl { get; set; }

        public decimal Rating { get; set; }

        public string? Genre { get; set; }
    }
}
