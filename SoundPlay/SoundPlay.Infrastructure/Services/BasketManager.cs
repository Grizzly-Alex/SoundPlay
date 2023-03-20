namespace SoundPlay.Infrastructure.Services;

public sealed class BasketManager : IBasketManager
{
	private const string _basketSession = "BasketSession";
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

	public Basket? GetBasket(ISession session)
	{
		var basketFromSession = session.Get<Basket>(_basketSession);
		_logger.LogInformation("Get basket from session");
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
		_logger.LogInformation("Get basket position");
		return basketPosition ?? throw new ObjectNotFoundException($"Product not exist! Product Id = {id}");
	}

	public BasketPosition? AddPositionToBasket(BasketPosition basketPosition)
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
		_logger.LogInformation("Position was added in basket");
		return position;
	}

    public BasketPosition? RemovePositionFromBasket(Guid id)
    {
        var position = Basket.ProductList!.FirstOrDefault(p => p.PositionId.Equals(id));
        if (position is not null)
		{
            Basket.ProductList!.Remove(position!);
			_logger.LogInformation("Position was removed from basket");
        }
        return position;
    }

	public Basket? UpdateBasket(BasketPosition basketPosition)
	{
		var position = Basket.ProductList!.FirstOrDefault(p => p.PositionId.Equals(basketPosition.PositionId));
		if (position is not null)
		{
			Basket.ProductList!.Remove(position!);
			Basket.ProductList!.Add(basketPosition!);
			_logger.LogInformation("Basket was updated");
		}
		else
		{
			throw new ObjectNotFoundException($"Basket position not exist! Product Id = {basketPosition.PositionId}");
		}
		return Basket;
	}

	public void SaveBasketInSession(ISession session)
	{
		session.Set(_basketSession, Basket);
        _logger.LogInformation("Basket was saved in session");
    }

	public void ClearBasket()
	{
		Basket.ProductList?.Clear();
        _logger.LogInformation("Basket was cleared");
    }
}
