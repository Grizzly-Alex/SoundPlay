using Microsoft.AspNetCore.Mvc;
using SoundPlay.BLL.Exceptions;
using SoundPlay.BLL.Interfaces;
using SoundPlay.BLL.ViewModels.Admin;

namespace SoundPlay.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public sealed class GuitarShapeController : Controller
    {
		private readonly IItemGenericService<GuitarShapeViewModel> _guitarShapeService;
		private readonly ILoggerAdapter<GuitarShapeController> _logger;

		public GuitarShapeController(
			IItemGenericService<GuitarShapeViewModel> brandService,
			ILoggerAdapter<GuitarShapeController> logger)
		{
			_guitarShapeService = brandService;
			_logger = logger;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			try
			{
				var viewModels = await _guitarShapeService.GetViewModelsAsync();
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
		public async Task<IActionResult> Create(GuitarShapeViewModel obj)
		{
			try
			{
				if (ModelState.IsValid)
				{
					await _guitarShapeService.CreateViewModelAsync(obj);
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
				var viewModel = await _guitarShapeService.GetViewModelByIdAsync(id);
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
		public async Task<IActionResult> Edit(GuitarShapeViewModel obj)
		{
			try
			{
				if (ModelState.IsValid)
				{
					await _guitarShapeService.UpdateViewModelAsync(obj);
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
				var viewModel = await _guitarShapeService.GetViewModelByIdAsync(id);
				await _guitarShapeService.DeleteViewModelAsync(viewModel);
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
}