namespace SoundPlay.Web.ViewModels;

public class PagedInfoViewModel
{
    public int PageIndex { get; set; }
    public int TotalPages { get; set; }
    public int ItemsPerPage { get; set; }
    public int TotalItems { get; set; }
    public bool HasPreviousPage => PageIndex > 0;
    public bool HasNextPage => PageIndex < TotalPages;
}
