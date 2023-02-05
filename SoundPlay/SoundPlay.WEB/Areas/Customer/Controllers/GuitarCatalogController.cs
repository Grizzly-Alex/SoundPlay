namespace SoundPlay.WEB.Areas.Customer.Controllers;

[Area("Customer")]
public class GuitarCatalogController : Controller
{
	private readonly ICatalogService<Guitar> _catalogGuitar;
	private readonly IRepresentationService _representationService;


	public GuitarCatalogController(
		ICatalogService<Guitar> catalogGuitar,
		IRepresentationService representationService)
	{
		_catalogGuitar = catalogGuitar;
		_representationService = representationService;
	}	

	[HttpGet]
	public async Task<IActionResult> Index(GuitarFilterViewModel filter)
	{
		var listCatalogProducts = await _catalogGuitar.GetProductsAsync(
			i => i.CategoryId == filter.CategoryId &&
			i.BrandId == filter.BrandId &&
			i.ColorId == filter.ColorId &&
			i.ShapeId == filter.ShapeId &&	
			i.SoundboardId == filter.SoundboardId &&
			i.NeckId == filter.NeckId &&
			i.FretboardId == filter.FretboardId &&
			i.PickupSetId == filter.PickupSetId &&
			i.TremoloTypeId == filter.TremoloTypeId);

		var selectBrands = await _representationService.GetSelectListAsync<Brand>();
		var selectColors = await _representationService.GetSelectListAsync<Color>();
		var selectGuitarShapes = await _representationService.GetSelectListAsync<GuitarShape>();
		var selectMaterials = await _representationService.GetSelectListAsync<Material>();
		var selectPickupSets = await _representationService.GetSelectListAsync<PickupSet>();
		var selectTremoloTypes = await _representationService.GetSelectListAsync<TremoloType>();

		var filterViewModel = new GuitarFilterViewModel()
		{
			Products = listCatalogProducts.ToList(),
			CategoryId = filter.CategoryId,
			Brands = selectBrands,
			Colors = selectColors,
			GuitarShapes = selectGuitarShapes,
			Soundboards = selectMaterials,
			Necks = selectMaterials,
			Fretboards = selectMaterials,
			PickupSets = selectPickupSets,
			TremoloTypes = selectTremoloTypes,
		};
		
		return View(filterViewModel);
	}
}
