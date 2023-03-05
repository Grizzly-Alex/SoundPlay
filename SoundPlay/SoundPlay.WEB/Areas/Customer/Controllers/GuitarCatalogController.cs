namespace SoundPlay.Web.Areas.Customer.Controllers;

[Area("Customer")]
public class GuitarCatalogController : Controller
{
	private readonly ICatalogService _catalogService;
    private readonly IViewModelService<Guitar, GuitarViewModel> _guitarService;

	public GuitarCatalogController(
        IViewModelService<Guitar, GuitarViewModel> guitarService,
        ICatalogService catalogGuitar)
	{
        _catalogService = catalogGuitar;
        _guitarService = guitarService;
	}

    public IActionResult DefineCategory(GuitarType category)
    {       
        var filter = new GuitarFilterViewModel(category);
        return RedirectToAction(nameof(Index), filter);
    }

    [HttpGet]
    public async Task<IActionResult> Index(GuitarFilterViewModel filter, int pageId)
    {
        var pagedInfo = await _catalogService.GetCatalogPageInfoAsync<Guitar>(
            i => (i.CategoryId == (int)filter.Category)
            && (!filter.MaxPrice.HasValue || i.Price <= filter.MaxPrice)
            && (!filter.MinPrice.HasValue || i.Price >= filter.MinPrice)
            && (!filter.BrandId.HasValue || i.BrandId == filter.BrandId)
            && (!filter.ColorId.HasValue || i.ColorId == filter.ColorId)
            && (!filter.ShapeId.HasValue || i.ShapeId == filter.ShapeId)
            && (!filter.SoundboardId.HasValue || i.SoundboardId == filter.SoundboardId)
            && (!filter.NeckId.HasValue || i.NeckId == filter.NeckId)
            && (!filter.FretboardId.HasValue || i.FretboardId == filter.FretboardId)
            && (!filter.PickupSetId.HasValue || i.PickupSetId == filter.PickupSetId)
            && (!filter.TremoloTypeId.HasValue || i.TremoloTypeId == filter.TremoloTypeId),
            Constants.ItemsPerPageCatalog, pageId);

        var guitarFilter = await _catalogService.GetGuitarFilterAsync(
            filter.Category,
            filter.MinPrice ?? default,
            filter.MaxPrice ?? pagedInfo.Items?.MaxBy(i => i.Price)?.Price);

        var catalog = new CatalogViewModel<GuitarFilterViewModel>(pagedInfo, guitarFilter);
       
        return View(catalog);
    }

    public async Task<IActionResult> Details(int id)
    {
        var guitarViewModel = await _guitarService.GetViewModelByIdAsync(id);

        return View(guitarViewModel);
    }
}
