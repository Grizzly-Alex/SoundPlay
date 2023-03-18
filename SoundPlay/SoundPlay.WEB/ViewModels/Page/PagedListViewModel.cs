namespace SoundPlay.Web.ViewModels.Page;

public sealed class PagedListViewModel<TModel> : PagedInfoViewModel
{
    public List<TModel>? Items { get; set; }
}
