namespace SoundPlay.BLL.Interfaces;

public interface ICatalogService<TProduct> where TProduct : Product
{
	public Task<IEnumerable<CatalogProductViewModel>> GetProductsAsync(Expression<Func<TProduct, bool>>? filter);
}