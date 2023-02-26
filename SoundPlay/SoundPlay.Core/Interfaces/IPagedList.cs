namespace SoundPlay.Core.Interfaces;

public interface IPagedList<TItem> where TItem : class
{
    public int IndexFrom { get; }
    public int PageIndex { get; }  
    public int PageSize { get; }
    public int TotalCount { get; } 
    public int TotalPages { get; }
    public IList<TItem> Items { get; }
    public bool HasPreviousPage { get; }
    public bool HasNextPage { get; }
}
