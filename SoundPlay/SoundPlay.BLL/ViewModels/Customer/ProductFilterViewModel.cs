namespace SoundPlay.BLL.ViewModels.Customer;

public abstract class ProductFilterViewModel
{
    [Display (Name = "Range Price")]
    public RangePrice? RangePrice { get; set; } 
    public List<CatalogProductViewModel>? Products { get; set; }
}
