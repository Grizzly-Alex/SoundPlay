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

    public async Task<IActionResult> DefineCategory(GuitarType category)
    {
        var _minPrice = await _catalogService.GetMinPrice<Guitar>(i => i.CategoryId == (int)category);
        var _maxPrice = await _catalogService.GetMaxPrice<Guitar>(i => i.CategoryId == (int)category);

        var filter = new GuitarFilterViewModel(category, _minPrice, _maxPrice);

        return RedirectToAction(nameof(Index), filter);
    }

    [HttpGet]
    public async Task<IActionResult> Index(GuitarFilterViewModel filter, PagedInfoViewModel pagedInfo)
    {
        var pagedList = await _catalogService.GetCatalogPageInfoAsync<Guitar>(
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
            Constants.ItemsPerPageCatalog, pagedInfo.PageId);

        var guitarFilter = await _catalogService.GetGuitarFilterAsync(filter.Category, filter.MinPrice, filter.MaxPrice);

        var catalog = new CatalogViewModel<GuitarFilterViewModel>(pagedList, guitarFilter);
       
        return View(catalog);
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var guitarViewModel = await _guitarService.GetViewModelByIdAsync(id);

        return View(guitarViewModel);
    }
}
