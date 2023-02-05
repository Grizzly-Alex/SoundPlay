namespace SoundPlay.BLL.Services;

public sealed class CatalogService<TProduct> : ICatalogService<TProduct>
	where TProduct : Product
{
	private readonly ILoggerAdapter<CatalogService<TProduct>>? _logger;
	private readonly IUnitOfWork _unitOfWork;

	public CatalogService(
		ILoggerAdapter<CatalogService<TProduct>>? logger,
		IUnitOfWork unitOfWork,
		IMapper mapper)
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

	public async Task<IEnumerable<SelectListItem>> GetSelectList<TEntity>() where TEntity : Entity
	{
		var listEntity = await _unitOfWork.GetRepository<TEntity>().GetAllAsync();
		var selectList = listEntity!.OrderBy(i => i.Name).Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Name });
		return selectList;
	}
}
