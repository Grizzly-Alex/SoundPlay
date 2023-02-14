using SoundPlay.DAL.Extensions;

namespace SoundPlay.WEB.Areas.Customer.Controllers;

[Area("Customer")]
public class GuitarCatalogController : Controller
{
	private readonly ICatalogService _catalogGuitar;
<<<<<<< HEAD
	private readonly ILogger<GuitarCatalogController> _logger; //no logging

	public GuitarCatalogController(
		ICatalogService catalogGuitar,
		ILogger<GuitarCatalogController> logger)
=======

	public GuitarCatalogController(
		ICatalogService catalogGuitar)
>>>>>>> 0953c78 (Update Models Configuration)
	{
		_catalogGuitar = catalogGuitar;
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
            && (!filter.BrandId.HasValue || i.BrandId == filter.BrandId)
            && (!filter.ColorId.HasValue || i.ColorId == filter.ColorId)
            && (!filter.ShapeId.HasValue || i.ShapeId == filter.ShapeId)
            && (!filter.SoundboardId.HasValue || i.SoundboardId == filter.SoundboardId)
            && (!filter.NeckId.HasValue || i.NeckId == filter.NeckId)
            && (!filter.FretboardId.HasValue || i.FretboardId == filter.FretboardId)
            && (!filter.PickupSetId.HasValue || i.PickupSetId == filter.PickupSetId)
            && (!filter.TremoloTypeId.HasValue || i.TremoloTypeId == filter.TremoloTypeId));

        var filterViewModel = await _catalogGuitar.GetGuitarCatalogFilterAsync(listCatalogProducts, filter.Category);
        ViewData["MaxPrice"] = filterViewModel.Products?.MaxBy(i => i.Price)?.Price.ToString() ?? new string("0.00");
       
        return View(filterViewModel);
    }
}
