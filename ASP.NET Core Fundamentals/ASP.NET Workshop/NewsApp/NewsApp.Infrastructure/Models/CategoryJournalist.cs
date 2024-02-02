namespace NewsApp.Infrastructure.Models
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class CategoryJournalist
	{
		[Required, ForeignKey(nameof(Category))]
		public Guid CategoryId { get; set; }
		public Category Category { get; set; }

		[Required, ForeignKey(nameof(Journalist))]
		public Guid JournalistId { get; set; }
		public Journalist Journalist { get; set; }
	}
}
