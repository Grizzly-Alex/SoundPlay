namespace SoundPlay.Core.Interfaces;

public interface ICatalogService
{
	public Task<IPagedList<CatalogProductViewModel>> GetCatalogPageAsync<TModel>(Expression<Func<TModel, bool>>? filter, int currentPageIndex, int totalItems)
        where TModel : Product;

    public Task<GuitarFilterViewModel> GetGuitarFilterAsync(IPagedList<CatalogProductViewModel> catalogProducts, GuitarFilterViewModel filter);
}