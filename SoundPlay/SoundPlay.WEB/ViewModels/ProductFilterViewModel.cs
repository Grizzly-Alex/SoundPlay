namespace SoundPlay.Web.ViewModels;

public abstract class ProductFilterViewModel
{
    public decimal? PriceStart { get; set; }
    public decimal? PriceEnd { get; set; }
    public List<CatalogProductViewModel>? Products { get; set; }

    protected ProductFilterViewModel()
    {
    }
    
    protected ProductFilterViewModel(decimal? priceStart, decimal? priceEnd, List<CatalogProductViewModel>? products)
    {
        PriceStart = priceStart ?? default;
        PriceEnd = priceEnd;
        Products = products;
    }
}
