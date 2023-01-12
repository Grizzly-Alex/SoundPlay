using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoundPlay.DAL.Models
{
    public abstract class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }  
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
        public int BrandId { get; set; }
        [ForeignKey("BrandId")]
        public Brand? Brand { get; set; }
        public int ColorId { get; set; }
        [ForeignKey("ColorId")]
        public Color? Color { get; set; }
        public DateTime DateDelivery  { get; set;} 

        public Product() => DateDelivery = DateTime.Now;
    }
}
