using SoundPlay.Core.ValueModels;

namespace SoundPlay.Core.Extensions
{
    public static class IQueryableExtensions
    {
        public static async Task<IPagedList<T>> ToPagedListAsync<T>(this IQueryable<T> source, int pageIndex,
            int itemsPerPage, CancellationToken cancellationToken = default)
        {
            var items = await source
                .Skip(pageIndex * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync(cancellationToken);

            return new PagedList<T>(items, pageIndex, itemsPerPage);
        }
    }
}
