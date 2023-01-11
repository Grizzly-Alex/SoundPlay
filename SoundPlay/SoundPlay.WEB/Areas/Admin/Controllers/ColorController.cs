using Microsoft.AspNetCore.Mvc;
using SoundPlay.BLL.Interfaces;
using SoundPlay.BLL.ViewModels;

namespace SoundPlay.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public sealed class ColorController:Controller
    {
        private readonly IItemGenericService<ColorViewModel> _colorService;

        public ColorController(IItemGenericService<ColorViewModel> colorService)
        {
            _colorService = colorService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewModels = await _colorService.GetViewModelsAsync();
            return View(viewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ColorViewModel obj)
        {
            if (ModelState.IsValid)
            {
                await _colorService.CreateViewModelAsync(obj);
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var viewModel = await _colorService.GetViewModelByIdAsync(id);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ColorViewModel obj)
        {
            if (ModelState.IsValid)
            {
                await _colorService.UpdateViewModelAsync(obj);
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var viewModel = await _colorService.GetViewModelByIdAsync(id);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ColorViewModel obj)
        {
            await _colorService.DeleteViewModelAsync(obj);
            return RedirectToAction("Index");
        }
    }
}
