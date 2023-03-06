 namespace SoundPlay.Core.ValueModels;

public sealed class PagedList<TItem> : IPagedList<TItem> 
{
    public int ActualPage { get; init; }
    public int TotalPages { get; init; }
    public int ItemsPerPage { get; init; }
    public int TotalItems { get; init; }
    public bool HasPreviousPage => ActualPage > 0;
    public bool HasNextPage => ActualPage + 1 < TotalPages;
    public IList<TItem> Items { get; init; }

    public PagedList(IEnumerable<TItem> items, int actualPage, int itemsPerPage, int totalItems)
    {
        Items = items.ToList();
        ActualPage = actualPage;
        ItemsPerPage = itemsPerPage;
        TotalItems = totalItems;
        TotalPages = (int)Math.Ceiling(totalItems / (double)ItemsPerPage);
    }

    public PagedList() => Items = Array.Empty<TItem>();
}