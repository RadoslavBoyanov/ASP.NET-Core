namespace NewsApp.Infrastructure.Models
{
	using Microsoft.EntityFrameworkCore;
	using System.ComponentModel.DataAnnotations;

    using static NewsApp.Common.Validations.EntityValidations.Journalist;

    public class Journalist
    {
        public Journalist()
        {
	        Articles = new HashSet<Article>();
            CategoryJournalists = new HashSet<CategoryJournalist>();
        }

        [Key]
        [Comment("Id of the journalist.")]
        public Guid Id { get; set; }

        [Required]
        [StringLength(NameMaxLength)]
        [Comment("Name of the journalist.")]
        public string Name { get; set; } = string.Empty;

        [StringLength(EmailMaxLength)]
        [Comment("Email of the journalist.")]
        public string Email { get; set; } = string.Empty;

        [Comment("Articles of the journalist.")]
        public ICollection<Article> Articles { get; set; }
        [Comment("The categories of articles he has written.")]
        public ICollection<CategoryJournalist> CategoryJournalists { get; set; }
    }
}
