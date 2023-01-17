using Microsoft.AspNetCore.Mvc;
using SoundPlay.BLL.Exceptions;
using SoundPlay.BLL.Interfaces;
using SoundPlay.BLL.ViewModels;

namespace SoundPlay.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public sealed class BrandController : Controller
    {
        private readonly IItemGenericService<BrandViewModel> _brandService;
        private readonly ILoggerAdapter<BrandController> _logger;

        public BrandController(
            IItemGenericService<BrandViewModel> brandService,
            ILoggerAdapter<BrandController> logger)
        {
            _brandService = brandService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
				var viewModels = await _brandService.GetViewModelsAsync();
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
        public async Task<IActionResult> Create(BrandViewModel obj)
        {
            try
            {
				if (ModelState.IsValid)
				{
					await _brandService.CreateViewModelAsync(obj);
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
				var viewModel = await _brandService.GetViewModelByIdAsync(id);
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
        public async Task<IActionResult> Edit(BrandViewModel obj)
        {
			try
			{
				if (ModelState.IsValid)
				{
					await _brandService.UpdateViewModelAsync(obj);
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
				var viewModel = await _brandService.GetViewModelByIdAsync(id);
				await _brandService.DeleteViewModelAsync(viewModel);
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