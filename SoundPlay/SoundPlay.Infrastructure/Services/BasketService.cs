namespace SoundPlay.Infrastructure.Services;

public class BasketService : IBasketService
{
	private readonly IUnitOfWork<CatalogDbContext> _unitOfWork;
	private readonly ILogger<BasketService> _logger;

    public BasketService(
		IUnitOfWork<CatalogDbContext> unitOfWork,
		ILogger<BasketService> logger)
    {
		_unitOfWork = unitOfWork;
		_logger = logger;
	}

    public async Task<Basket> AddItemToBasket(
		string userId, int productId, decimal price, string productType, int quantity = 1)
	{
		var basketRepository = _unitOfWork.GetRepository<Basket>();

		var basket = await basketRepository.GetFirstOrDefaultAsync(
			predicate: i => i.BuyerId == userId,
			include: query => query.Include(b => b.Items));

		if (basket is null) 
		{
			basket = new Basket(userId);
			basketRepository.Add(basket);
		}

		basket.AddItem(productId, price, productType, quantity);

		await _unitOfWork.SaveChangesAsync();

		return basket;
	}

	public async Task DeleteBasketAsync(int basketId)
	{
		var basketRepository = _unitOfWork.GetRepository<Basket>();
		var basket = await basketRepository.GetFirstOrDefaultAsync(predicate: b => b.Id == basketId);
		basketRepository.Remove(basketId); 

		await _unitOfWork.SaveChangesAsync();
	}

	public async Task<Basket> SetQuantities(int basketId, Dictionary<string, int> quantities)
	{
		Guard.Against.Null(quantities, nameof(quantities));
		var basketRepository = _unitOfWork.GetRepository<Basket>();
		var basket = await basketRepository.GetFirstOrDefaultAsync(
			predicate: i => i.Id == basketId,
			include: query => query.Include(b => b.Items));
		Guard.Against.NullBasket(basketId, basket);

		foreach (var item in basket.Items) 
		{
			if(quantities.TryGetValue(item.Id.ToString(), out var quantity))
			{
				_logger?.LogInformation($"Updating quantity of item ID:{item.Id} to {quantity}.");
				item.SetQuantity(quantity);
			}
		}
		basket.RemoveEmptyItems();
		basketRepository.Update(basket);

		await _unitOfWork.SaveChangesAsync();

		return basket;
	}

	public async Task TransferBasketAsync(string anonymousId, string userId)
	{
		Guard.Against.NullOrEmpty(anonymousId, nameof(anonymousId));
		Guard.Against.NullOrEmpty(userId, nameof(userId));

		var basketRepository = _unitOfWork.GetRepository<Basket>();

		var anonymousBasket = await basketRepository.GetFirstOrDefaultAsync(
			predicate: i => i.BuyerId == anonymousId,
			include: query => query.Include(b => b.Items));
		if (anonymousBasket is null) return;

		var userBasket = await basketRepository.GetFirstOrDefaultAsync(
			predicate: i => i.BuyerId == userId,
			include: query => query.Include(b => b.Items));
		if (userBasket is null)
		{
			userBasket = new Basket(userId);
			basketRepository.Add(userBasket);
		}

		foreach (var item in anonymousBasket.Items)
		{
			userBasket.AddItem(item.ProductId, item.UnitPrice, item.ProductType, item.Quantity);
		}

		basketRepository.Update(userBasket);
		basketRepository.Remove(anonymousBasket.Id);

		await _unitOfWork.SaveChangesAsync();
	}
}
