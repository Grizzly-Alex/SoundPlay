namespace SoundPlay.WEB.Areas.Customer.Controllers;

[Area("Customer")]
public class GuitarCatalogController : Controller
{
	private readonly ICatalogService<Guitar> _catalogGuitar;
	private readonly IUnitOfWork _unitOfWork;

	public GuitarCatalogController(
		ICatalogService<Guitar> catalogGuitar,
		IUnitOfWork unitOfWork)
	{
		_catalogGuitar = catalogGuitar;
		_unitOfWork = unitOfWork;
	}	

	[HttpGet]
	public async Task<IActionResult> Index(GuitarFilterViewModel filter)
	{
		var listCatalogProducts = await _catalogGuitar.GetProductsAsync(
			i => i.CategoryId == filter.CategoryId &&
			i.BrandId == filter.BrandId);

		var filterViewModel = new GuitarFilterViewModel()
		{
			Products = listCatalogProducts.ToList(),
			

		};
		
		return View(filterViewModel);
	}
}
