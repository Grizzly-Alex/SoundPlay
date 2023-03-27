namespace SoundPlay.Web.Services;

public sealed class BasketViewModelService //: IBasketViewModelService
{
    private readonly IUnitOfWork<ShoppingDbContext> _shoping;
    private readonly IUnitOfWork<CatalogDbContext> _catalog;
    private readonly IMapper _mapper;

    public BasketViewModelService(
        IUnitOfWork<ShoppingDbContext> shoping,
        IUnitOfWork<CatalogDbContext> catalog,
        IMapper mapper)
    {
        _catalog = catalog;
        _shoping = shoping;
        _mapper = mapper;
    }

    /*
    public async Task<BasketViewModel> GetBasketForUser(string userId)
    {
        var basketRepository = _shoping.GetRepository<Basket>();

        var basket = await basketRepository.GetFirstOrDefaultAsync(
            predicate: b => b.BuyerId == userId,
            include: query => query.Include(b => b.Items));

        if (basket is null)
        {
            basket = new Basket(userId);
            basketRepository.Add(basket);
            await _shoping.SaveChangesAsync();

            return _mapper.Map<BasketViewModel>(basket);
        }

        //TODO
    }

    private async Task<List<BasketItemViewModel>> GetBasketItems(IReadOnlyCollection<BasketItem> basketItems)
    {
        foreach (var basketItem in basketItems)
        {
            Type type = Type.GetType(basketItem.ProductType);

            if (type is not null)
            {
                object productType = Activator.CreateInstance(type);
                var repository = _catalog.GetRepository<productType>();


            }

        }

        var basketItemViewModelList = basketItems.Select(basketItem => 
        {

        }).ToList();

    }

    public async Task<int> CountTotalBasketItems(string userId)
    {
        throw new NotImplementedException();
    }
    */
}
