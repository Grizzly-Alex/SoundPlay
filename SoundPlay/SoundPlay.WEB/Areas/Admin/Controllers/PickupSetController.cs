namespace SoundPlay.WEB.Areas.Admin.Controllers;

[Area("Admin")]
public sealed class PickupSetController : Controller
{
	private readonly IEntityService<PickupSet, PickupSetViewModel> _pickupSetService;
	private readonly ILogger<PickupSetController> _logger;

	public PickupSetController(
		IEntityService<PickupSet, PickupSetViewModel> brandService,
		ILogger<PickupSetController> logger)
	{
		_pickupSetService = brandService;
		_logger = logger;
	}

	[HttpGet]
	public async Task<IActionResult> Index()
	{
        var viewModels = await _pickupSetService.GetViewModelsAsync();
        return View(viewModels);
    }


	[HttpGet]
	public IActionResult Create()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Create(PickupSetViewModel obj)
	{
        if (ModelState.IsValid)
        {
            await _pickupSetService.CreateViewModelAsync(obj);
            return RedirectToAction(nameof(Index));
        }
        else return View(obj);
    }

	[HttpGet]
	public async Task<IActionResult> Edit(int id)
	{
        var viewModel = await _pickupSetService.GetViewModelByIdAsync(id);
        return View(viewModel);
    }

	[HttpPost]
	public async Task<IActionResult> Edit(PickupSetViewModel obj)
	{
        if (ModelState.IsValid)
        {
            await _pickupSetService.UpdateViewModelAsync(obj);
            return RedirectToAction(nameof(Index));
        }
        return View(obj);
    }


	[HttpPost]
	public async Task<IActionResult> Delete(int id)
	{
        var viewModel = await _pickupSetService.GetViewModelByIdAsync(id);
        await _pickupSetService.DeleteViewModelAsync(viewModel);
        return RedirectToAction(nameof(Index));
    }
}