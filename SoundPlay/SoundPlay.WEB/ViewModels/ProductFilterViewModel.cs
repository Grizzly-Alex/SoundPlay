namespace SoundPlay.Web.ViewModels;

public abstract class ProductFilterViewModel
{
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public IPagedList<CatalogProductViewModel>? Products { get; set; }

    protected ProductFilterViewModel()
    {
    }
    
    protected ProductFilterViewModel(decimal? minPrice, decimal? maxPrice, IPagedList<CatalogProductViewModel>? products)
    {
        MinPrice = minPrice ?? default;
        MaxPrice = maxPrice;
        Products = products;
    }
}
