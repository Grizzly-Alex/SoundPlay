namespace SoundPlay.WEB.Areas.Customer.Controllers;

[Area("Customer")]
public sealed class PriceController : Controller
{
    private readonly ILoggerAdapter<PriceController>? _logger;
	private readonly IEntityService<Guitar, GuitarViewModel> _guitars;
	private readonly IMapper _mapper;

    public PriceController(
        ILoggerAdapter<PriceController>? logger,
        IEntityService<Guitar, GuitarViewModel> guitars,
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
        var basketFromSession = HttpContext.Session.Get<Basket>(WebConstants.BasketSession);

        // if there is a filled Basket in the session, then take the data from it    
        if (basketFromSession!=null
            &&basketFromSession!.TotalCount>0)
        {
            basket=basketFromSession!;
        }

        #endregion

        var position = basket.ProductList!.First(p => p.ProductId.Equals(basketPosition.ProductId));

        if (position==null) basket.ProductList!.Add(basketPosition);
        else position.Count+=basketPosition.Count;

        // putting a basket with new properties into the session
        HttpContext.Session.Set(WebConstants.BasketSession, basket);
        return RedirectToAction(nameof(Index));
    }
}