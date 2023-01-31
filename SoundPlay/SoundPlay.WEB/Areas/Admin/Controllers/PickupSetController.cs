namespace SoundPlay.WEB.Areas.Admin.Controllers;

[Area("Admin")]
public sealed class PickupSetController : Controller
{
	private readonly IEntityService<PickupSet, PickupSetViewModel> _pickupSetService;
	private readonly ILoggerAdapter<PickupSetController> _logger;

	public PickupSetController(
		IEntityService<PickupSet, PickupSetViewModel> brandService,
		ILoggerAdapter<PickupSetController> logger)
	{
		_pickupSetService = brandService;
		_logger = logger;
	}

	[HttpGet]
	public async Task<IActionResult> Index()
	{
		try
		{
			var viewModels = await _pickupSetService.GetViewModelsAsync();
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
	public async Task<IActionResult> Create(PickupSetViewModel obj)
	{
		try
		{
			if (ModelState.IsValid)
			{
				await _pickupSetService.CreateViewModelAsync(obj);
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
			var viewModel = await _pickupSetService.GetViewModelByIdAsync(id);
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
	public async Task<IActionResult> Edit(PickupSetViewModel obj)
	{
		try
		{
			if (ModelState.IsValid)
			{
				await _pickupSetService.UpdateViewModelAsync(obj);
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
			var viewModel = await _pickupSetService.GetViewModelByIdAsync(id);
			await _pickupSetService.DeleteViewModelAsync(viewModel);
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