namespace NewsApp.Infrastructure.Models
{
	using Microsoft.EntityFrameworkCore;
	using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static NewsApp.Common.Validations.EntityValidations.NewsArticle;

    public class Article
    {
	    [Key]
        [Comment("Id of article.")]
        public Guid Id { get; set; }

        [Required]
        [StringLength(TitleMaxLength)]
        [Comment("Title of the article.")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(ContentMaxLength)]
        [Comment("Content of the article.")]
        public string Content { get; set; } = string.Empty;

        [Required]
        [Comment("Date of publish for the article.")]
        [Column("Publish Date")]
        public DateTime PublishDate { get; set; }


        [Required, ForeignKey(nameof(Category))]
        [Comment("Id of the category of article.")]
        public Guid CategoryId { get; set; }
        [Comment("Category of the article.")]
        public Category Category { get; set; }

        [Required, ForeignKey(nameof(Journalist))]
        [Comment("Id of the journalist writed the article.")]
        public Guid JournalistId { get; set; }
        [Comment("The journalist writed the article.")]
        public Journalist Journalist { get; set; }

    }
}
