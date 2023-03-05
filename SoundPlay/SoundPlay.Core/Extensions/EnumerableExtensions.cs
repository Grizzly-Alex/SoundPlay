namespace SoundPlay.Core.Extensions;

public static class EnumerableExtensions
{
    public static IPagedList<TItem> ToPagedList<TItem>(this IEnumerable<TItem> source, int actualPage, int itemsPerPage)
        => new PagedList<TItem>(source, actualPage, itemsPerPage, source.Count());       
}