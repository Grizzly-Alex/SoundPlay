using SoundPlay.Core.Constants;
using SoundPlay.Core.Models.Entities.Products;

namespace SoundPlay.Web.Interfaces;

public interface ICatalogService
{
    public Task<decimal?> GetMinPrice<TModel>(Expression<Func<TModel, bool>>? filter = null)
        where TModel : Product;
    public Task<decimal?> GetMaxPrice<TModel>(Expression<Func<TModel, bool>>? filter = null)
        where TModel : Product;
    public Task<PagedListViewModel<CatalogProductViewModel>> GetCatalogPageInfoAsync<TModel>(
        Expression<Func<TModel, bool>>? filter, int itemsPerPage, int pageIndex)
        where TModel : Product;
    public Task<GuitarFilterViewModel> GetGuitarFilterAsync(GuitarTag category, decimal? minPrice, decimal? maxPrice);
}