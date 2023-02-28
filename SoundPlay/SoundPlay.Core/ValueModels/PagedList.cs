namespace SoundPlay.Core.ValueModels;

public sealed class PagedList<TItem> : IPagedList<TItem> 
{
    public bool HasPreviousPage => PageIndex > 0;
    public bool HasNextPage => PageIndex < TotalPages;
    public int PageIndex { get; init; }
    public int TotalPages { get; init; }
    public int ItemsPerPage { get; init; }
    public int TotalItems { get; init; }
    public IList<TItem> Items { get; init; }

    public PagedList(IEnumerable<TItem> items, int pageIndex, int itemsPerPage)
    {
        if (pageIndex < 0)
        {
            throw new ArgumentException($"pageIndex: {pageIndex} < 0, must pageIndex >= 0");
        }

        PageIndex = pageIndex;
        ItemsPerPage = itemsPerPage;
        TotalItems = items.Count();
        TotalPages = (int)Math.Ceiling(TotalItems / (double)ItemsPerPage);
        Items = items.Skip(PageIndex * ItemsPerPage).Take(ItemsPerPage).ToList();      
    }

    public PagedList() => Items = Array.Empty<TItem>();
}
