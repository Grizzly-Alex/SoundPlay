namespace SoundPlay.WEB.Areas.Admin.Controllers;

[Area("Admin")]
public sealed class ColorController : Controller
{
    private readonly IItemGenericService<ColorViewModel> _colorService;
	private readonly ILoggerAdapter<ColorController> _logger;

	public ColorController(
        IItemGenericService<ColorViewModel> colorService,
		ILoggerAdapter<ColorController> logger)
    {
        _colorService = colorService;
        _logger = logger;
    }

	[HttpGet]
	public async Task<IActionResult> Index()
	{
		try
		{
			var viewModels = await _colorService.GetViewModelsAsync();
			return View(viewModels);
		}

		catch (ObjectNotFoundException ex)
		{
			_logger!.LogError(ex.Message);
			return NotFound(ex.Message);
		}

		catch (Exception ex)
		{
			_logger!.LogError(ex.Message);
			return BadRequest(ex.Message);
		}
	}


	[HttpGet]
	public IActionResult Create()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Create(ColorViewModel obj)
	{
		try
		{
			if (ModelState.IsValid)
			{
				await _colorService.CreateViewModelAsync(obj);
				return RedirectToAction(nameof(Index));
			}
			else return View(obj);
		}

		catch (Exception ex)
		{
			_logger!.LogError(ex.Message);
			return BadRequest(ex.Message);
		}
	}

	[HttpGet]
	public async Task<IActionResult> Edit(int id)
	{
		try
		{
			var viewModel = await _colorService.GetViewModelByIdAsync(id);
			return View(viewModel);
		}

		catch (ObjectNotFoundException ex)
		{
			_logger!.LogError(ex.Message);
			return NotFound(ex.Message);
		}

		catch (Exception ex)
		{
			_logger!.LogError(ex.Message);
			return BadRequest(ex.Message);
		}
	}

	[HttpPost]
	public async Task<IActionResult> Edit(ColorViewModel obj)
	{
		try
		{
			if (ModelState.IsValid)
			{
				await _colorService.UpdateViewModelAsync(obj);
				return RedirectToAction(nameof(Index));
			}
			return View(obj);
		}

		catch (Exception ex)
		{
			_logger!.LogError(ex.Message);
			return BadRequest(ex.Message);
		}
	}


	[HttpPost]
	public async Task<IActionResult> Delete(int id)
	{
		try
		{
			var viewModel = await _colorService.GetViewModelByIdAsync(id);
			await _colorService.DeleteViewModelAsync(viewModel);
			return RedirectToAction(nameof(Index));
		}

		catch (ObjectNotFoundException ex)
		{
			_logger!.LogError(ex.Message);
			return NotFound(ex.Message);
		}

		catch (Exception ex)
		{
			_logger!.LogError(ex.Message);
			return BadRequest(ex.Message);
		}
	}
}