namespace SoundPlay.Core.Interfaces;

public interface ICatalogService<TCatalogModel>
{
	public Task<IEnumerable<TCatalogModel>> GetCatalogModelsAsync<TModel>(Expression<Func<TModel, bool>>? filter)
        where TModel : Product;

    public Task<TFilterModel> GetFilterModelAsync<TFilterModel>(IEnumerable<TCatalogModel> catalogProducts, TFilterModel filter);


}