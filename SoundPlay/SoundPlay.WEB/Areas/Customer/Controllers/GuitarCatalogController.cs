namespace SoundPlay.WEB.Areas.Customer.Controllers;

[Area("Customer")]
public class GuitarCatalogController : Controller
{
	private readonly ICatalogService _catalogGuitar;
    private readonly IEntityService<Guitar, GuitarViewModel> _guitarService;

	public GuitarCatalogController(
        IEntityService<Guitar, GuitarViewModel> guitarService,
        ICatalogService catalogGuitar)
	{
        _catalogGuitar = catalogGuitar;
        _guitarService = guitarService;
	}


    public IActionResult DefineCategory(GuitarType category)
    {       
        var filterViewModel = new GuitarFilterViewModel(category);
        return RedirectToAction(nameof(Index), filterViewModel);
    }

    [HttpGet]
    public async Task<IActionResult> Index(GuitarFilterViewModel filter)
    {
        var listCatalogProducts = await _catalogGuitar.GetCatalogProductsAsync<Guitar>(
            i => (i.CategoryId == (int)filter.Category)
            && (!filter.PriceEnd.HasValue || i.Price <= filter.PriceEnd)
            && (!filter.PriceStart.HasValue || i.Price >= filter.PriceStart)
            && (!filter.BrandId.HasValue || i.BrandId == filter.BrandId)
            && (!filter.ColorId.HasValue || i.ColorId == filter.ColorId)
            && (!filter.ShapeId.HasValue || i.ShapeId == filter.ShapeId)
            && (!filter.SoundboardId.HasValue || i.SoundboardId == filter.SoundboardId)
            && (!filter.NeckId.HasValue || i.NeckId == filter.NeckId)
            && (!filter.FretboardId.HasValue || i.FretboardId == filter.FretboardId)
            && (!filter.PickupSetId.HasValue || i.PickupSetId == filter.PickupSetId)
            && (!filter.TremoloTypeId.HasValue || i.TremoloTypeId == filter.TremoloTypeId));

        var filterViewModel = await _catalogGuitar.GetGuitarCatalogFilterAsync(listCatalogProducts, filter);
       
        return View(filterViewModel);
    }

    public async Task<IActionResult> Details(int id)
    {
        var guitarViewModel = await _guitarService.GetViewModelByIdAsync(id);

        return View(guitarViewModel);
    }
}
