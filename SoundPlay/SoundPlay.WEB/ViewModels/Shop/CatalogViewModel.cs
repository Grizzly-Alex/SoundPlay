using SoundPlay.Web.ViewModels.Page;

namespace SoundPlay.Web.ViewModels.Shop;

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
