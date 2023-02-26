namespace SoundPlay.Core.Interfaces;

public interface IPagedList<TEntity> where TEntity : Entity
{
    int IndexFrom { get; }
    int PageIndex { get; }  
    int PageSize { get; }
    int TotalCount { get; } 
    int TotalPages { get; }
    IList<TEntity> Items { get; }
    bool HasPreviousPage { get; }
    bool HasNextPage { get; }
}
