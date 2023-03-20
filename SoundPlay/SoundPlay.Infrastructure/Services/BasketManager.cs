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
		Type type = typeof(TModel);	

		var basketPosition = await _unitOfWork.GetRepository<TModel>()
			.GetFirstOrDefaultAsync(
			predicate: i => i.Id == id,
			selector: i => new BasketPosition
			{
				ProductId = i.Id,
				ProductName = i.Name,
				ProductPictureUrl = i.PictureUrl,
				ProductPrice = i.Price,
				ProductDescription = i.Description,
				Count = count,
				TypeName = type.Name,
            });

		return basketPosition ?? throw new ObjectNotFoundException($"Product not exist! Product Id = {id}");
	}

	public Basket AddPositionToBasket(BasketPosition basketPosition)
	{
		var position = Basket.ProductList!.FirstOrDefault(p => p.ProductId.Equals(basketPosition.ProductId));
		if (position is null)
		{
			Basket.ProductList!.Add(basketPosition);
		}
		else
		{
			position.Count += basketPosition.Count;
		} 
		return Basket;
	}

	public Basket UpdateBasket(BasketPosition basketPosition)
	{
		var positionForChange = Basket.ProductList!.FirstOrDefault(p => p.PositionId.Equals(basketPosition.PositionId));
		if (positionForChange is not null)
		{
			Basket.ProductList!.Remove(positionForChange!);
			Basket.ProductList!.Add(basketPosition!);
		}
		else
		{
			throw new ObjectNotFoundException($"Basket position not exist! Product Id = {basketPosition.PositionId}");
		}
		return Basket;
	}

    public void SaveBasketInSession(ISession session) => session.Set("BasketSession", Basket);
}
