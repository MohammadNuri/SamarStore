namespace SamarStore.Application.Services.Products.Queries.GetProductDetailForSite
{
	public class ProductDetailForSiteDto
	{
		public long Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string Brand { get; set; } = string.Empty;
		public string Category { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;	
		public int Price { get; set; }	
		public List<string> Images { get; set; }
		public List<ProductDetailForSite_FeatureDto> Feature { get; set; }	

	}



}
