using Microsoft.AspNetCore.Mvc;
using SoundPlay.BLL.Services;
using SoundPlay.BLL.ViewModels;

namespace SoundPlay.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
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

        [HttpPut]
        public async Task<IActionResult> Create(CategoryViewModel obj)
        {
            var viewModel = await _categoryService.CreateViewModelAsync(obj);
            return View(viewModel);
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
            var viewModel = await _categoryService.UpdateViewModelAsync(obj);
            return View(viewModel);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var viewModel = await _categoryService.GetViewModelByIdAsync(id);
            return View(viewModel);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(CategoryViewModel obj)
        {
            var viewModel = await _categoryService.DeleteViewModelAsync(obj);
            return View(viewModel);
        }
    }
}