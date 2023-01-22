using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using SoundPlay.DAL.Models;
using System.Globalization;

namespace SoundPlay.BLL.ViewModels.Admin
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
		public string ViewPrice { get => Price.ToString("C", CultureInfo.GetCultureInfo("en-US")); }
		public DateTime DateDelivery { get; set; }
		[ValidateNever] public string? PictureUrl { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        [ValidateNever] public Category? Category { get; set; }
		[ValidateNever] public Brand? Brand { get; set; }
		[ValidateNever] public Color? Color { get; set; }
    }
}
