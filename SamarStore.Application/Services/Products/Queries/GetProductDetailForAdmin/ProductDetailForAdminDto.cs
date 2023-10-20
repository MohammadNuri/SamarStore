namespace SamarStore.Application.Services.Products.Queries.GetProductDetailForAdmin;

public class ProductDetailForAdminDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;    
    public string Category { get; set; } = string.Empty;    
    public string Brand { get; set; } = string.Empty;       
    public string Description { get; set; } = string.Empty;
    public int Price { get; set; }
    public int Inventory { get; set; }
    public bool Displayed { get; set; }
    public List<ProductDetailFeatureDto> Features { get; set; }
    public List<ProductDetailImagesDto> Images { get; set; }
}