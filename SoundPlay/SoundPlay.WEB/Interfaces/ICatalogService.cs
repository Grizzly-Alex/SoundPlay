namespace SoundPlay.Core.Interfaces;

public interface ICatalogService
{
	public Task<PagedInfoViewModel<CatalogProductViewModel>> GetProductPagedInfoAsync<TModel>(
        Expression<Func<TModel, bool>>? filter, int itemsPerPage, int totalItems, int pageIndex)
        where TModel : Product;

    public Task<GuitarFilterViewModel> GetGuitarFilterAsync(GuitarType category, decimal? minPrice, decimal? maxPrice);
}