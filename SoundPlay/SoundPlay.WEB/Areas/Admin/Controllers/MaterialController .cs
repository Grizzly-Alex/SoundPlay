using Microsoft.AspNetCore.Mvc;
using SoundPlay.BLL.Exceptions;
using SoundPlay.BLL.Interfaces;
using SoundPlay.BLL.ViewModels.Admin;

namespace SoundPlay.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public sealed class MaterialController : Controller
    {
		private readonly IItemGenericService<MaterialViewModel> _materialService;
		private readonly ILoggerAdapter<MaterialController> _logger;

		public MaterialController(
			IItemGenericService<MaterialViewModel> brandService,
			ILoggerAdapter<MaterialController> logger)
		{
			_materialService = brandService;
			_logger = logger;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			try
			{
				var viewModels = await _materialService.GetViewModelsAsync();
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
		public async Task<IActionResult> Create(MaterialViewModel obj)
		{
			try
			{
				if (ModelState.IsValid)
				{
					await _materialService.CreateViewModelAsync(obj);
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
				var viewModel = await _materialService.GetViewModelByIdAsync(id);
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
		public async Task<IActionResult> Edit(MaterialViewModel obj)
		{
			try
			{
				if (ModelState.IsValid)
				{
					await _materialService.UpdateViewModelAsync(obj);
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
				var viewModel = await _materialService.GetViewModelByIdAsync(id);
				await _materialService.DeleteViewModelAsync(viewModel);
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