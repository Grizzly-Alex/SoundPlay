using Microsoft.AspNetCore.Mvc;
using SoundPlay.BLL.Interfaces;
using SoundPlay.BLL.ViewModels;

namespace SoundPlay.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public sealed class BrandController : Controller
    {
        private readonly IItemGenericService<BrandViewModel> _brandService;

        public BrandController(IItemGenericService<BrandViewModel> brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewModels = await _brandService.GetViewModelsAsync();
            return View(viewModels);
        }
        

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BrandViewModel obj)
        {    
            if (ModelState.IsValid)
            {
				await _brandService.CreateViewModelAsync(obj);
				return RedirectToAction("Index");
			}
            return View(obj);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
			var viewModel = await _brandService.GetViewModelByIdAsync(id);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BrandViewModel obj)
        {
            if (ModelState.IsValid)
            {
				await _brandService.UpdateViewModelAsync(obj);
				return RedirectToAction("Index");
			}
            return View(obj);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var viewModel = await _brandService.GetViewModelByIdAsync(id);
            await _brandService.DeleteViewModelAsync(viewModel);
            return RedirectToAction("Index");
        }
    }
}