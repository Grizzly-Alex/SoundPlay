namespace SoundPlay.BLL.Services;

public sealed class CatalogService<TProduct> : ICatalogService<TProduct>
	where TProduct : Product
{
	private readonly ILoggerAdapter<CatalogService<TProduct>>? _logger;
	private readonly IUnitOfWork _unitOfWork;

	public CatalogService(
		ILoggerAdapter<CatalogService<TProduct>>? logger,
		IUnitOfWork unitOfWork)
	{
		_logger = logger;
		_unitOfWork = unitOfWork;
	}

	public async Task<IEnumerable<CatalogProductViewModel>> GetProductsAsync(Expression<Func<TProduct, bool>>? filter)
	{
		var catalogProducts = await _unitOfWork.GetRepository<TProduct>().GetAllAsync(
			predicate: filter,
			selector: i => new CatalogProductViewModel
			{
				Id = i.Id,
				Name = i.Name,
				Price = i.Price,
				PictureUrl = i.PictureUrl
			});

		if (catalogProducts is null)
		{
			_logger.LogError("Get_Products operation is failed");
			throw new ObjectNotFoundException("Objects not found");
		}

		return catalogProducts;
	}
}
