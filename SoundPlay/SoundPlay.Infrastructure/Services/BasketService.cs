namespace SoundPlay.Infrastructure.Services;

public class BasketService : IBasketService
{
	private const string _basketCookie = "BasketCookie";
	private readonly IUnitOfWork<ShoppingDbContext> _shopping;
    private readonly IUnitOfWork<CatalogDbContext> _catalog;
    private readonly ILogger<BasketService> _logger;

    public BasketService(
        IUnitOfWork<ShoppingDbContext> shopping,
        IUnitOfWork<CatalogDbContext> catalog,
        ILogger<BasketService> logger)
    {
        _shopping = shopping;
		_catalog = catalog;
		_logger = logger;
	}

    public async Task<int> GetQuantityItems(int basketId)
		=> await _shopping.GetRepository<BasketItem>().SumAsync(
			predicate: i => i.BasketId == basketId,
			selector: i => i.Quantity);

    public async Task<Basket> AddItemToBasketAsync<TModel>(string userId, int productId, int productQuantity = 1)
		where TModel : Product
	{
		var basketRepository = _shopping.GetRepository<Basket>();
		var basket = await basketRepository.GetFirstOrDefaultAsync(
			predicate: i => i.BuyerId == userId,
			include: query => query.Include(b => b.Items));

		if (basket is null)
		{
			basket = new Basket(userId);
			basketRepository.Add(basket);
            await _shopping.SaveChangesAsync();
			_logger.LogInformation("Basket was created.");
        }

		var basketItem = await _catalog.GetRepository<TModel>()
			.GetFirstOrDefaultAsync(
			predicate: product => product.Id == productId,
			selector: product => new BasketItem(product, productQuantity));

		basket.AddItem(basketItem!);

        basketRepository.Update(basket);
        await _shopping.SaveChangesAsync();

        _logger.LogInformation("Basket was updated.");
        return basket;
	}


	public async Task RemoveItemFromBasketAsync(int basketItemId)
	{
        _shopping.GetRepository<BasketItem>().Remove(basketItemId);
		await _shopping.SaveChangesAsync();
	}

	public async Task DeleteBasketAsync(int basketId)
	{
		var basketRepository = _shopping.GetRepository<Basket>();
		var basket = await basketRepository.GetFirstOrDefaultAsync(predicate: b => b.Id == basketId);
		basketRepository.Remove(basketId);

		await _shopping.SaveChangesAsync();
	}

	public async Task TransferBasketAsync(string anonymousId, string userId)
	{
		Guard.Against.NullOrEmpty(anonymousId, nameof(anonymousId));
		Guard.Against.NullOrEmpty(userId, nameof(userId));

		var basketRepository = _shopping.GetRepository<Basket>();

		var anonymousBasket = await basketRepository.GetFirstOrDefaultAsync(
			predicate: i => i.BuyerId == anonymousId,
			include: query => query.Include(b => b.Items));

		if (anonymousBasket is not null) 
		{
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
				userBasket.AddItem(item);
			}

			basketRepository.Update(userBasket);
			basketRepository.Remove(anonymousBasket.Id);

			await _shopping.SaveChangesAsync();
		};
	}

	public async Task<string> GetBasketOwnerIdAsync(HttpRequest request, HttpResponse response)
	{
		string? userId = null;

		if (request.HttpContext.User.Identity.IsAuthenticated)
		{
			return request.HttpContext.User.Identity.Name;
		}

		if (request.Cookies.ContainsKey(_basketCookie))
		{
			userId = request.Cookies[_basketCookie];

			if (!request.HttpContext.User.Identity.IsAuthenticated)
			{
				if (!Guid.TryParse(userId, out var _))
				{
					userId = null;
				}
			}
		}

		if (userId is not null) return userId;

		userId = Guid.NewGuid().ToString();
		var cookieOptions = new CookieOptions
		{
			IsEssential = true,
			Expires = DateTime.Today.AddYears(30)
		};

		response.Cookies.Append(_basketCookie, userId, cookieOptions);

		return userId;
	}



    /*
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
	*/
}
