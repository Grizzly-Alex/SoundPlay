namespace SoundPlay.Web.Areas.Admin.Controllers;

[Area("Admin")]
public sealed class TremoloTypeController : Controller
{
	private readonly IViewModelService<TremoloType, TremoloTypeViewModel> _tremoloTypeService;

	public TremoloTypeController(IViewModelService<TremoloType, TremoloTypeViewModel> brandService)
	{
		_tremoloTypeService = brandService;
	}

	[HttpGet]
	public async Task<IActionResult> Index()
	{
        var viewModels = await _tremoloTypeService.GetViewModelsAsync();
        return View(viewModels);
    }


	[HttpGet]
	public IActionResult Create()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Create(TremoloTypeViewModel obj)
	{
        if (ModelState.IsValid)
        {
            await _tremoloTypeService.CreateViewModelAsync(obj);
            return RedirectToAction(nameof(Index));
        }
        else return View(obj);
    }

	[HttpGet]
	public async Task<IActionResult> Edit(int id)
	{
        var viewModel = await _tremoloTypeService.GetViewModelByIdAsync(id);
        return View(viewModel);
    }

	[HttpPost]
	public async Task<IActionResult> Edit(TremoloTypeViewModel obj)
	{
        if (ModelState.IsValid)
        {
            await _tremoloTypeService.UpdateViewModelAsync(obj);
            return RedirectToAction(nameof(Index));
        }
        return View(obj);
    }


	[HttpPost]
	public async Task<IActionResult> Delete(int id)
	{
        var viewModel = await _tremoloTypeService.GetViewModelByIdAsync(id);
        await _tremoloTypeService.DeleteViewModelAsync(viewModel);
        return RedirectToAction(nameof(Index));
    }
}