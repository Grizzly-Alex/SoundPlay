namespace SoundPlay.DAL.Models;

public abstract class Product : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
	public string? PictureUrl { get; set; }  
    public DateTime DateDelivery  { get; set;} 
    public int CategoryId { get; set; } 
    public int BrandId { get; set; }
    public int ColorId { get; set; }

	[ForeignKey("CategoryId")] public Category Category { get; set; }
	[ForeignKey("BrandId")] public Brand? Brand { get; set; }
    [ForeignKey("ColorId")] public Color? Color { get; set; }
}
