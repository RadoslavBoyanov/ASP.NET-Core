namespace MVCIntroDemo.Models.Product
{
	public class ProductViewModel
	{
		/// <summary>
		/// Id product.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Name of product.
		/// </summary>
		public string Name { get; set; } = string.Empty;


		/// <summary>
		/// Price of the product.
		/// </summary>
		public double Price { get; set; }
	}
}
