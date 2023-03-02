namespace SoundPlay.Web.ViewModels;

public sealed class PagedInfoViewModel<TModel>
{
    public int PageIndex { get; set; }
    public int TotalPages { get; set; }
    public int ItemsPerPage { get; set; }
    public int TotalItems { get; set; }
    public bool HasPreviousPage => PageIndex > 0;
    public bool HasNextPage => PageIndex < TotalPages;
    public List<TModel>? Items { get;set; }
}
