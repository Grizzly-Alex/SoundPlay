using SoundPlay.Core.Models.Entities.Items;

namespace SoundPlay.Web.Areas.Admin.Controllers;

[Area("Admin")]
public sealed class PickupSetController : Controller
{
	private readonly IViewModelService<PickupSet, PickupSetViewModel> _pickupSetService;

	public PickupSetController(IViewModelService<PickupSet, PickupSetViewModel> brandService)
	{
		_pickupSetService = brandService;
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