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
	public async Task<IActionResult> Index(GuitarFilterViewModel filter, GuitarType type)
	{
		var listCatalogProducts = await _catalogGuitar.GetProductsAsync(
			i => (i.CategoryId == (int)type)
			&& (!filter.BrandId.HasValue || i.BrandId == filter.BrandId)
			&& (!filter.ColorId.HasValue || i.ColorId == filter.ColorId)
			&& (!filter.ShapeId.HasValue || i.ShapeId == filter.ShapeId)
			&& (!filter.SoundboardId.HasValue || i.SoundboardId == filter.SoundboardId)
			&& (!filter.NeckId.HasValue || i.NeckId == filter.NeckId)
			&& (!filter.FretboardId.HasValue || i.FretboardId == filter.FretboardId)
			&& (!filter.PickupSetId.HasValue || i.PickupSetId == filter.PickupSetId)
			&& (!filter.TremoloTypeId.HasValue || i.TremoloTypeId == filter.TremoloTypeId));

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
