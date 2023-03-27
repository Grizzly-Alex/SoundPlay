namespace SoundPlay.Web.ViewModels.Catalog;

public class CatalogViewModel<TFilter>
{
    public PagedListViewModel<CatalogProductViewModel>? PagedInfo { get; set; }
    public TFilter? Filter { get; set; }

    public CatalogViewModel(PagedListViewModel<CatalogProductViewModel>? pagedInfo, TFilter? filter)
    {
        PagedInfo = pagedInfo;
        Filter = filter;
    }
}
