namespace SoundPlay.Core.Interfaces;

public interface ICatalogService
{
	public Task<PagedInfoViewModel<CatalogProductViewModel>> GetCatalogPageInfoAsync<TModel>(
        Expression<Func<TModel, bool>>? filter, int itemsPerPage, int pageIndex)
        where TModel : Product;

    public Task<GuitarFilterViewModel> GetGuitarFilterAsync(GuitarType category, decimal? minPrice, decimal? maxPrice);
}