namespace SoundPlay.Core.Interfaces;

public interface ICatalogService
{
	public Task<IEnumerable<CatalogProductViewModel>> GetProductsPerPageAsync<TModel>(Expression<Func<TModel, bool>>? filter, int itemsPerPage, int pageIndex)
        where TModel : Product;

    public Task<PaginationInfoViewModel> GetPaginationInfoAsync<TModel>(int itemsPerPage, int pageIndex)
        where TModel : Entity;

    public Task<GuitarFilterViewModel> GetGuitarFilterAsync(GuitarType category, decimal? minPrice, decimal? maxPrice);
}