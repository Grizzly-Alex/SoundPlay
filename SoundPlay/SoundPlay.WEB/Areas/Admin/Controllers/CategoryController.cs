using Microsoft.AspNetCore.Mvc;
using SoundPlay.BLL.Interfaces;
using SoundPlay.BLL.ViewModels;

namespace SoundPlay.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IItemGenericService<CategoryViewModel> _categoryService;

        public CategoryController(IItemGenericService<CategoryViewModel> categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewModels = await _categoryService.GetViewModelsAsync();
            return View(viewModels);
        }
        

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryViewModel obj)
        {    
            if (ModelState.IsValid)
            {
				await _categoryService.CreateViewModelAsync(obj);
				return RedirectToAction("Index");
			}
            return View(obj);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
			var viewModel = await _categoryService.GetViewModelByIdAsync(id);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryViewModel obj)
        {
            if (ModelState.IsValid)
            {
				await _categoryService.UpdateViewModelAsync(obj);
				return RedirectToAction("Index");
			}
            return View(obj);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var viewModel = await _categoryService.GetViewModelByIdAsync(id);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CategoryViewModel obj)
        {
			await _categoryService.DeleteViewModelAsync(obj);
			return RedirectToAction("Index");
		}
    }
}