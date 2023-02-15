namespace SoundPlay.BLL.ViewModels.Customer;

public sealed class CatalogProductViewModel : EntityViewModel
{
	public string Name { get; set; }
	public decimal Price { get; set; }
	public string ViewPrice { get => Price.ToString("C0", CultureInfo.GetCultureInfo("en-US")); }
	public string? PictureUrl { get; set; }
}
