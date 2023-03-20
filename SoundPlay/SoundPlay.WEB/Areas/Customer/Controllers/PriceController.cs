namespace SoundPlay.Web.Areas.Customer.Controllers;

[Area("Customer")]
public sealed class PriceController : Controller
{
    private readonly ILogger<PriceController>? _logger;
	private readonly IViewModelService<Guitar, GuitarViewModel> _guitars;
	private readonly IMapper _mapper;

    public PriceController(
        ILogger<PriceController>? logger,
        IViewModelService<Guitar, GuitarViewModel> guitars,
        IMapper mapper)
    {
        _logger = logger;
        _guitars = guitars;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var guitars = await _guitars!.GetViewModelsAsync();
        return View(guitars);
    }

    [HttpGet]
    public async Task<IActionResult> AddToBasket(int id)
    {
        var guitar = await _guitars!.GetViewModelByIdAsync(id);

        var basketPosition = _mapper.Map<BasketPosition>(guitar);
        return View(basketPosition);
    }

    [HttpPost]
    public IActionResult AddToBasket(BasketPosition basketPosition)
    {
        #region Formation of a basket taking into account data from the session

        Basket basket = new();

        // getting Basket from session
        var basketFromSession = HttpContext.Session.Get<Basket>(Constants.BasketSession);

        // if there is a filled Basket in the session, then take the data from it    
        if (basketFromSession is not null && basketFromSession!.TotalCount > 0)
        {
            basket = basketFromSession!;
        }

        #endregion

        var position = basket.ProductList!.FirstOrDefault(p => p.ProductId.Equals(basketPosition.ProductId));

        if (position is null) basket.ProductList!.Add(basketPosition);
        else position.Count += basketPosition.Count;

        // putting a basket with new properties into the session
        HttpContext.Session.Set(Constants.BasketSession, basket);
        return RedirectToAction(nameof(Index));
    }
}