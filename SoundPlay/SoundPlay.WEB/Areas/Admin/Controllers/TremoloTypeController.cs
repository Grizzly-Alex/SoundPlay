using Microsoft.AspNetCore.Mvc;
using SoundPlay.BLL.Exceptions;
using SoundPlay.BLL.Interfaces;
using SoundPlay.BLL.ViewModels;

namespace SoundPlay.WEB.Areas.Admin.Controllers
{
	[Area("Admin")]
	public sealed class TremoloTypeController : Controller
	{
		private readonly IItemGenericService<TremoloTypeViewModel> _tremoloTypeService;
		private readonly ILoggerAdapter<TremoloTypeController> _logger;

		public TremoloTypeController(
			IItemGenericService<TremoloTypeViewModel> brandService,
			ILoggerAdapter<TremoloTypeController> logger)
		{
			_tremoloTypeService = brandService;
			_logger = logger;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			try
			{
				var viewModels = await _tremoloTypeService.GetViewModelsAsync();
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
		public async Task<IActionResult> Create(TremoloTypeViewModel obj)
		{
			try
			{
				if (ModelState.IsValid)
				{
					await _tremoloTypeService.CreateViewModelAsync(obj);
					return RedirectToAction("Index");
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
				var viewModel = await _tremoloTypeService.GetViewModelByIdAsync(id);
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
		public async Task<IActionResult> Edit(TremoloTypeViewModel obj)
		{
			try
			{
				if (ModelState.IsValid)
				{
					await _tremoloTypeService.UpdateViewModelAsync(obj);
					return RedirectToAction("Index");
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
				var viewModel = await _tremoloTypeService.GetViewModelByIdAsync(id);
				await _tremoloTypeService.DeleteViewModelAsync(viewModel);
				return RedirectToAction("Index");
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