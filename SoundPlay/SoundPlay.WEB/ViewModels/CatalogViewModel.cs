namespace SoundPlay.Web.ViewModels;

public class CatalogViewModel<TFilter>
{
    public PagedInfoViewModel<CatalogProductViewModel>? PagedInfo { get; set; }
    public TFilter? Filter { get; set; }

    public CatalogViewModel(PagedInfoViewModel<CatalogProductViewModel>? pagedInfo, TFilter? filter)
    {
        PagedInfo = pagedInfo;
        Filter = filter;
    }
}
