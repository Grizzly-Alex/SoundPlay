namespace SoundPlay.Web.ViewModels;

public class CatalogViewModel<TFilter>
{
    public List<CatalogProductViewModel> Products { get; set; }
    public PaginationInfoViewModel PaginationInfo { get; set; }
    public TFilter Filter { get; set; }
}
