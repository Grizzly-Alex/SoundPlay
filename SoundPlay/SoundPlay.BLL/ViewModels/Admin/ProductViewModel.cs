using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using SoundPlay.DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace SoundPlay.BLL.ViewModels.Admin
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required] public string? Name { get; set; }
        [Required] public string? Description { get; set; }
        [Required] public decimal Price { get; set; }
		[ValidateNever] public string? PictureUrl { get; set; }
        [Required] public DateTime DateDelivery { get; set; }
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }
        public int? ColorId { get; set; }
        [ValidateNever] public Category? Category { get; set; }
		[ValidateNever] public Brand? Brand { get; set; }
		[ValidateNever] public Color? Color { get; set; }
    }
}
