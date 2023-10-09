namespace SamarStore.Application.Services.Products.Queries.GetProductForSite;

public class ProductForSiteDto
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string ImageSrc { get; set; } = string.Empty;
    public int Star { get; set; }
    public int Price { get; set; }
}