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
		//_logger = logger;
	}

    [HttpGet]
    public async Task<IActionResult> Index(GuitarFilterViewModel filter)
    {
        var listCatalogProducts = await _catalogGuitar.GetCatalogProductsAsync<Guitar>(
            i => (i.CategoryId == filter.CategoryId)
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


    public IActionResult DefineFilter(GuitarType type)
    {
        var filterViewModel = new GuitarFilterViewModel(type);
        return RedirectToAction(nameof(Index), filterViewModel);
    }



    //public async Task<IActionResult> Index(
    //    GuitarType type,
    //    int? brandId,
    //    int? colorId,
    //    int? shapeId,
    //    int? soundboardId,
    //    int? neckId,
    //    int? fretboardId,
    //    int? puckupSetId,
    //    int? tremoloTypeId)
    //{
    //    var listCatalogProducts = await _catalogGuitar.GetCatalogProductsAsync<Guitar>(
    //        i => (i.CategoryId == (int)type)
    //        && (!brandId.HasValue || i.BrandId == brandId)
    //        && (!colorId.HasValue || i.ColorId == colorId)
    //        && (!shapeId.HasValue || i.ShapeId == shapeId)
    //        && (!soundboardId.HasValue || i.SoundboardId == soundboardId)
    //        && (!neckId.HasValue || i.NeckId == neckId)
    //        && (!fretboardId.HasValue || i.FretboardId == fretboardId)
    //        && (!puckupSetId.HasValue || i.PickupSetId == puckupSetId)
    //        && (!tremoloTypeId.HasValue || i.TremoloTypeId == tremoloTypeId));

    //    var filterViewModel = await _catalogGuitar.GetGuitarCatalogFilterAsync(listCatalogProducts);
    //    filterViewModel.Type = type;

    //    return View(filterViewModel);
    //}
}
