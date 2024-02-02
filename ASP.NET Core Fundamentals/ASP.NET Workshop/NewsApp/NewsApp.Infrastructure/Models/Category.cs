namespace NewsApp.Infrastructure.Models
{
	using Microsoft.EntityFrameworkCore;
	using System.ComponentModel.DataAnnotations;

    using static NewsApp.Common.Validations.EntityValidations.NewsCategory;

    public class Category
    {
        public Category()
        {
	        Articles = new HashSet<Article>();
            CategoryJournalists = new HashSet<CategoryJournalist>();
        }

        [Key]
        [Comment("Id for the news category.")]
        public Guid Id { get; set; }

        [Required]
        [StringLength(NameMaxLength)]
        [Comment("Name of the news category.")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(ContentMaxLength)]
        [Comment("Content for the category.")]
        public string Content { get; set; } = string.Empty;

        [Comment("Collection of articles in one category.")]
        public ICollection<Article> Articles { get; set; }
        [Comment("Journalists who writed articles in that category.")]
        public ICollection<CategoryJournalist> CategoryJournalists { get; set; }
	}
}
