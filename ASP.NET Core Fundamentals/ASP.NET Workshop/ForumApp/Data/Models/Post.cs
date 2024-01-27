using System.ComponentModel.DataAnnotations;

namespace ForumApp.Data.Models
{
    using static ForumApp.Data.Common.DataConstants.Post;

    public class Post
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MinLength(TitleMinLength)]
		[MaxLength(TitleMaxLength)]
		public string Title { get; set; } = string.Empty;

		[Required]
		[MinLength(ContentMinLength)]
		[MaxLength(ContentMaxLength)]
		public string Content { get; set; } = string.Empty;

		public bool IsDelete { get; set; }
	}
}
