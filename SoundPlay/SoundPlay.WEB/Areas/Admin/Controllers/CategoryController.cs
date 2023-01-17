using Microsoft.AspNetCore.Mvc;
using SoundPlay.BLL.Exceptions;
using SoundPlay.BLL.Interfaces;
using SoundPlay.BLL.ViewModels;
using SoundPlay.DAL.Models;

namespace SoundPlay.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public sealed class CategoryController : Controller
    {
        private readonly IItemGenericService<CategoryViewModel> _categoryService;
		private readonly ILoggerAdapter<CategoryController> _logger;

		public CategoryController(
            IItemGenericService<CategoryViewModel> categoryService,
			ILoggerAdapter<CategoryController> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
			try
			{
				var viewModels = await _categoryService.GetViewModelsAsync();
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
        public async Task<IActionResult> Create(CategoryViewModel obj)
        {
			try
			{
				if (ModelState.IsValid)
				{
					await _categoryService.CreateViewModelAsync(obj);
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
				var viewModel = await _categoryService.GetViewModelByIdAsync(id);
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
        public async Task<IActionResult> Edit(CategoryViewModel obj)
        {
			try
			{
				if (ModelState.IsValid)
				{
					await _categoryService.UpdateViewModelAsync(obj);
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
				var viewModel = await _categoryService.GetViewModelByIdAsync(id);
				await _categoryService.DeleteViewModelAsync(viewModel);
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