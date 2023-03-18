 namespace SoundPlay.Core.ValueModels;

public sealed class PagedList<TItem> : IPagedList<TItem> 
{
    public int PageId { get; init; }
    public int TotalPages { get; init; }
    public int ItemsPerPage { get; init; }
    public int TotalItems { get; init; }
    public bool HasPreviousPage => PageId > 0;
    public bool HasNextPage => PageId + 1 < TotalPages;
    public IList<TItem> Items { get; init; }

    public PagedList(IList<TItem> items, int pageId, int itemsPerPage, int totalItems, int totalPages)
    {
        Items = items;
        PageId = pageId;
        ItemsPerPage = itemsPerPage;
        TotalItems = totalItems;
        TotalPages = totalPages;
    }

    public PagedList() => Items = Array.Empty<TItem>();
}