using System.ComponentModel.DataAnnotations;

namespace ForumApp.Models
{
	using ForumApp.Data.Common;
	public class PostFormModel
	{
		[Required]
		[StringLength(DataConstants.Post.TitleMaxLength, MinimumLength = DataConstants.Post.TitleMinLength)]
		public string Title { get; set; } = string.Empty;

		[Required]
		[StringLength(DataConstants.Post.ContentMaxLength, MinimumLength = DataConstants.Post.ContentMinLength)]
		public string Content { get; set; } = string.Empty;
	}
}
