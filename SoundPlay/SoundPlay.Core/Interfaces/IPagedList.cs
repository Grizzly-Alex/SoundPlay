namespace SoundPlay.Core.Interfaces;

public interface IPagedList<TResult> where TResult : class
{
    public int IndexFrom { get; }
    public int PageIndex { get; }  
    public int PageSize { get; }
    public int TotalCount { get; } 
    public int TotalPages { get; }
    public IList<TResult> Items { get; }
    public bool HasPreviousPage { get; }
    public bool HasNextPage { get; }
}
