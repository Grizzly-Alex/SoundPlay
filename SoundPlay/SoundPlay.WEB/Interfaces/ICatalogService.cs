namespace SoundPlay.Core.Interfaces;

public interface ICatalogService
{
	public Task<IEnumerable<CatalogProductViewModel>> GetCatalogModelsAsync<TModel>(Expression<Func<TModel, bool>>? filter)
        where TModel : Product;

    public Task<GuitarFilterViewModel> GetGuitarFilterAsync(IEnumerable<CatalogProductViewModel> catalogProducts, GuitarFilterViewModel filter);
}