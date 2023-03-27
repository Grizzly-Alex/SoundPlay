namespace SoundPlay.Web.ViewModels.Pagination;

public sealed class PagedListViewModel<TModel> : PagedInfoViewModel
{
    public List<TModel>? Items { get; set; }
}
