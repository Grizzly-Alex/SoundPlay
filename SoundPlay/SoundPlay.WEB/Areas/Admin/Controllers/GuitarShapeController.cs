namespace SoundPlay.WEB.Areas.Admin.Controllers;

[Area("Admin")]
public sealed class GuitarShapeController : Controller
{
	private readonly IEntityService<GuitarShape, GuitarShapeViewModel> _guitarShapeService;
	private readonly ILoggerAdapter<GuitarShapeController> _logger;

	public GuitarShapeController(
		IEntityService<GuitarShape, GuitarShapeViewModel> brandService,
		ILoggerAdapter<GuitarShapeController> logger)
	{
		_guitarShapeService = brandService;
		_logger = logger;
	}

	[HttpGet]
	public async Task<IActionResult> Index()
	{
        var viewModels = await _guitarShapeService.GetViewModelsAsync();
        return View(viewModels);
    }


	[HttpGet]
	public IActionResult Create()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Create(GuitarShapeViewModel obj)
	{
        if (ModelState.IsValid)
        {
            await _guitarShapeService.CreateViewModelAsync(obj);
            return RedirectToAction(nameof(Index));
        }
        else return View(obj);
    }

	[HttpGet]
	public async Task<IActionResult> Edit(int id)
	{
        var viewModel = await _guitarShapeService.GetViewModelByIdAsync(id);
        return View(viewModel);
    }

	[HttpPost]
	public async Task<IActionResult> Edit(GuitarShapeViewModel obj)
	{
        if (ModelState.IsValid)
        {
            await _guitarShapeService.UpdateViewModelAsync(obj);
            return RedirectToAction(nameof(Index));
        }
        return View(obj);
    }


	[HttpPost]
	public async Task<IActionResult> Delete(int id)
	{
        var viewModel = await _guitarShapeService.GetViewModelByIdAsync(id);
        await _guitarShapeService.DeleteViewModelAsync(viewModel);
        return RedirectToAction(nameof(Index));
    }
}