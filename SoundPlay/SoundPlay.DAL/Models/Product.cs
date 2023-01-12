namespace SoundPlay.DAL.Models
{
    public abstract class Product
    {
        public int Id { get; set; }
        public string? ModelName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }  
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public int BrandId { get; set; }
        public Brand? Brand { get; set; }
        public int ColorId { get; set; }
        public Color? Color { get; set; }
    }
}
