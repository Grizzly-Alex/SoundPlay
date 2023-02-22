namespace SoundPlay.Core.Interfaces;

public interface ICatalogService<TCatalogModel, TGuitarFilter>
    where TCatalogModel : class
    where TGuitarFilter : class
{
	public Task<IEnumerable<TCatalogModel>> GetCatalogModelsAsync<TModel>(Expression<Func<TModel, bool>>? filter)
        where TModel : Product;

    public Task<TGuitarFilter> GetGuitarFilterAsync(IEnumerable<TCatalogModel> catalogProducts, TGuitarFilter filter);


}