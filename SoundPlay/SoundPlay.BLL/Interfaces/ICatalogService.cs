namespace SoundPlay.BLL.Interfaces;

public interface ICatalogService
{
	public Task<IEnumerable<CatalogProductViewModel>> GetCatalogProductsAsync<TProduct>(Expression<Func<TProduct, bool>>? filter)
		where TProduct : Product;

	public Task<GuitarFilterViewModel> GetGuitarCatalogFilterAsync(IEnumerable<CatalogProductViewModel> catalogProducts, GuitarFilterViewModel filter);
}