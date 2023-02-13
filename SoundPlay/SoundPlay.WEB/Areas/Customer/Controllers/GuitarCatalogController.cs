namespace SoundPlay.WEB.Areas.Customer.Controllers;

[Area("Customer")]
public class GuitarCatalogController : Controller
{
	private readonly ICatalogService _catalogGuitar;
	private readonly ILogger<GuitarCatalogController> _logger; //no logging

	public GuitarCatalogController(
		ICatalogService catalogGuitar,
		ILogger<GuitarCatalogController> logger)
	{
		_catalogGuitar = catalogGuitar;
		_logger = logger;
	}	

	[HttpGet]
	public async Task<IActionResult> Index(GuitarFilterViewModel filter, GuitarType type)
	{
		var listCatalogProducts = await _catalogGuitar.GetCatalogProductsAsync<Guitar>(
			i => (i.CategoryId == (int)type)
			&& (!filter.BrandId.HasValue || i.BrandId == filter.BrandId)
			&& (!filter.ColorId.HasValue || i.ColorId == filter.ColorId)
			&& (!filter.ShapeId.HasValue || i.ShapeId == filter.ShapeId)
			&& (!filter.SoundboardId.HasValue || i.SoundboardId == filter.SoundboardId)
			&& (!filter.NeckId.HasValue || i.NeckId == filter.NeckId)
			&& (!filter.FretboardId.HasValue || i.FretboardId == filter.FretboardId)
			&& (!filter.PickupSetId.HasValue || i.PickupSetId == filter.PickupSetId)
			&& (!filter.TremoloTypeId.HasValue || i.TremoloTypeId == filter.TremoloTypeId));

		var filterViewModel = await _catalogGuitar.GetGuitarCatalogFilterAsync(listCatalogProducts);

		return View(filterViewModel);
	}
}
