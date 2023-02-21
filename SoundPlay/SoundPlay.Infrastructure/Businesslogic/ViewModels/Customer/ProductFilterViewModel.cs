namespace SoundPlay.Infrastructure.Businesslogic.ViewModels;

public abstract class ProductFilterViewModel
{
    public decimal? PriceStart { get; set; }
    public decimal? PriceEnd { get; set; }
    public List<CatalogProductViewModel>? Products { get; set; }
}
