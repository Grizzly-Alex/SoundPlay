﻿namespace SoundPlay.BLL.ViewModels.Admin;

public class ProductViewModel
{
        public int Id { get; set; }

	[Required(ErrorMessage = "Value {0} must not be empty!")]
	public string Name { get; set; }

	[Required(ErrorMessage = "Value {0} must not be empty!")]
	public string Description { get; set; }

	[Precision(8, 2)]
	[Range(1, 999999, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
	[Required(ErrorMessage = "Value {0} must not be empty!")]
	public decimal Price { get; set; }
	public string ViewPrice { get => Price.ToString("C", CultureInfo.GetCultureInfo("en-US")); }
	public DateTime DateDelivery { get; set; }

	[ValidateNever]
	[DisplayName("Picture Url")]
	public string? PictureUrl { get; set; }

	[Required(ErrorMessage = "Value {0} from the list must be selected!")]
	[DisplayName("Category")]
	public int CategoryId { get; set; }

	[Required(ErrorMessage = "Value {0} from the list must be selected!")]
	[DisplayName("Brand")]
	public int BrandId { get; set; }

	[Required(ErrorMessage = "Value {0} from the list must be selected!")]
	[DisplayName("Color")]
	public int ColorId { get; set; }
    [ValidateNever] public Category? Category { get; set; }
	[ValidateNever] public Brand? Brand { get; set; }
	[ValidateNever] public Color? Color { get; set; }
}
