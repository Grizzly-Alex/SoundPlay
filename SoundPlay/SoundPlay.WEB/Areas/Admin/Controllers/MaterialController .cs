namespace SoundPlay.WEB.Areas.Admin.Controllers;

[Area("Admin")]
public sealed class MaterialController : Controller
{
	private readonly IEntityService<Material, MaterialViewModel> _materialService;
	private readonly ILoggerAdapter<MaterialController> _logger;

	public MaterialController(
		IEntityService<Material, MaterialViewModel> brandService,
		ILoggerAdapter<MaterialController> logger)
	{
		_materialService = brandService;
		_logger = logger;
	}

	[HttpGet]
	public async Task<IActionResult> Index()
	{
        var viewModels = await _materialService.GetViewModelsAsync();
        return View(viewModels);
    }


	[HttpGet]
	public IActionResult Create()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Create(MaterialViewModel obj)
	{
        if (ModelState.IsValid)
        {
            await _materialService.CreateViewModelAsync(obj);
            return RedirectToAction(nameof(Index));
        }
        else return View(obj);
    }

	[HttpGet]
	public async Task<IActionResult> Edit(int id)
	{
        var viewModel = await _materialService.GetViewModelByIdAsync(id);
        return View(viewModel);
    }

	[HttpPost]
	public async Task<IActionResult> Edit(MaterialViewModel obj)
	{
        if (ModelState.IsValid)
        {
            await _materialService.UpdateViewModelAsync(obj);
            return RedirectToAction(nameof(Index));
        }
        return View(obj);
    }


	[HttpPost]
	public async Task<IActionResult> Delete(int id)
	{
        var viewModel = await _materialService.GetViewModelByIdAsync(id);
        await _materialService.DeleteViewModelAsync(viewModel);
        return RedirectToAction(nameof(Index));
    }
}