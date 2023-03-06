namespace SoundPlay.Core.Interfaces;

public interface ICatalogService
{
    public Task<decimal> GetMinPrice<TModel>(Expression<Func<TModel, bool>>? filter = null)
        where TModel : Product;
    public Task<decimal> GetMaxPrice<TModel>(Expression<Func<TModel, bool>>? filter = null)
        where TModel : Product;
    public Task<PagedListViewModel<CatalogProductViewModel>> GetCatalogPageInfoAsync<TModel>(
        Expression<Func<TModel, bool>>? filter, int itemsPerPage, int pageIndex)
        where TModel : Product;
    public Task<GuitarFilterViewModel> GetGuitarFilterAsync(GuitarType category, decimal? minPrice, decimal? maxPrice);
}