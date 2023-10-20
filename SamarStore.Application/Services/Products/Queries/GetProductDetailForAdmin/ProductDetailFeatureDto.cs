namespace SamarStore.Application.Services.Products.Queries.GetProductDetailForAdmin;

public class ProductDetailFeatureDto
{
    public long Id { get; set; }
    public string DisplayName { get; set; } = string.Empty; 
    public string Value { get; set; } = string.Empty;
}