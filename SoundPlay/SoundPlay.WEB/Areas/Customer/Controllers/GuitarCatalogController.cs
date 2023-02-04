namespace SoundPlay.WEB.Areas.Customer.Controllers;

[Area("Customer")]
public class GuitarCatalogController : Controller
{
	private readonly ILoggerAdapter<GuitarCatalogController> _logger;
	private readonly IProductService<GuitarViewModel> _guitarService;

	public GuitarCatalogController(
		ILoggerAdapter<GuitarCatalogController> logger,
		IProductService<GuitarViewModel> guitarService)
	{
		_logger = logger;
		_guitarService = guitarService;
	}

	[HttpGet]
	public IActionResult Index(GuitarType guitarType)
	{
		return View();
	}
}
