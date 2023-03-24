namespace SoundPlay.Core.Models.Entities.Products;

public abstract class Product : Item
{
    public byte Stock { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string? PictureUrl { get; set; }
    public DateTime DateDelivery { get; set; }
    public int BrandId { get; set; }
    public int ColorId { get; set; }
    public Brand? Brand { get; set; }
    public Color? Color { get; set; }
}
