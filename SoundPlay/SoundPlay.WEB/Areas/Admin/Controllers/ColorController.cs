namespace SoundPlay.Web.Areas.Admin.Controllers;

[Area("Admin")]
public sealed class ColorController : Controller
{
    private readonly IViewModelService<Color, ColorViewModel> _colorService;
	private readonly ILogger<ColorController> _logger;

	public ColorController(
		IViewModelService<Color, ColorViewModel> colorService,
		ILogger<ColorController> logger)
    {
        _colorService = colorService;
        _logger = logger;
    }

	[HttpGet]
	public async Task<IActionResult> Index()
	{
        var viewModels = await _colorService.GetViewModelsAsync();
        return View(viewModels);
    }


	[HttpGet]
	public IActionResult Create()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Create(ColorViewModel obj)
	{
        if (ModelState.IsValid)
        {
            await _colorService.CreateViewModelAsync(obj);
            return RedirectToAction(nameof(Index));
        }
        else return View(obj);
    }

	[HttpGet]
	public async Task<IActionResult> Edit(int id)
	{
        var viewModel = await _colorService.GetViewModelByIdAsync(id);
        return View(viewModel);
    }

	[HttpPost]
	public async Task<IActionResult> Edit(ColorViewModel obj)
	{
        if (ModelState.IsValid)
        {
            await _colorService.UpdateViewModelAsync(obj);
            return RedirectToAction(nameof(Index));
        }
        return View(obj);
    }


	[HttpPost]
	public async Task<IActionResult> Delete(int id)
	{
        var viewModel = await _colorService.GetViewModelByIdAsync(id);
        await _colorService.DeleteViewModelAsync(viewModel);
        return RedirectToAction(nameof(Index));
    }
}