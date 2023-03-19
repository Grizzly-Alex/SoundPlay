namespace SoundPlay.Infrastructure.Services;

public sealed class BasketManager : IBasketManager
{
	private readonly IUnitOfWork<CatalogDbContext> _unitOfWork;
	private readonly ILogger<BasketManager> _logger;
	public Basket Basket { get; set; }
	
	public BasketManager(
		IUnitOfWork<CatalogDbContext> unitOfWork,
		ILogger<BasketManager> logger)
    {
		_unitOfWork = unitOfWork;
		_logger = logger;
		Basket = new();
    }

	public Basket GetBasket(ISession session)
	{
		var basketFromSession = session.Get<Basket>("BasketSession");

		if (basketFromSession is not null && basketFromSession!.TotalCount > 0)
		{
			Basket = basketFromSession!;
		}
		return Basket;
	}

	public async Task<BasketPosition?> GetBasketPositionAsync<TModel>(int id, byte count = 1)
		where TModel : Product
	{
		var basketPosition = await _unitOfWork.GetRepository<TModel>()
			.GetFirstOrDefaultAsync(
			predicate: i => i.Id == id,
			selector: i => new BasketPosition
			{
				Product = i,
				Count = count,
				Type = typeof(TModel)	
			});

		return basketPosition ?? throw new ObjectNotFoundException($"Product not exist! Product Id = {id}");
	}
	public Basket AddPositionToBasket(BasketPosition basketPosition)
	{
		var position = Basket.ProductList!.FirstOrDefault(p => p.Product.Id.Equals(basketPosition.Product.Id));
		if (position is null) Basket.ProductList!.Add(basketPosition);
		else position.Count += basketPosition.Count;
		return Basket;
	}


	public Basket UpdateBasket(BasketPosition basketPosition)
	{
		var positionForChange = Basket.ProductList!.First(p => p.Id.Equals(basketPosition.Id));
		if (positionForChange is not null)
		{
			Basket.ProductList!.Remove(positionForChange!);
			Basket.ProductList!.Add(basketPosition!);
		}
		else
		{
			throw new ObjectNotFoundException($"Basket position not exist! Product Id = {basketPosition.Id}");
		}
		return Basket;
	}
}
