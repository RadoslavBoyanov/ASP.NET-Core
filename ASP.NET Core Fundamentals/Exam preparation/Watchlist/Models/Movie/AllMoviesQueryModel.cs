namespace Watchlist.Models.Movie
{
    public class AllMoviesQueryModel
    {
        public ICollection<MovieInfoViewModel> Movies { get; set; } = new HashSet<MovieInfoViewModel>();
    }
}
