namespace ForumApp.Models
{
	public class PostViewModel
	{
		public int Id { get; init; }

		public string Title { get; set; } = string.Empty;

		public string Content { get; set; } = string.Empty;
	}
}
