using Microsoft.AspNetCore.Mvc;
using SoundPlay.BLL.Interfaces;
using SoundPlay.BLL.ViewModels;

namespace SoundPlay.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public sealed class PickupSetController:Controller
    {
        private readonly IItemGenericService<PickupSetViewModel> _pickupSetService;

        public PickupSetController(IItemGenericService<PickupSetViewModel> pickupSetService)
        {
            _pickupSetService = pickupSetService;
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
                return RedirectToAction("Index");
            }
            return View(obj);
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
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var viewModel = await _pickupSetService.GetViewModelByIdAsync(id);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(PickupSetViewModel obj)
        {
            await _pickupSetService.DeleteViewModelAsync(obj);
            return RedirectToAction("Index");
        }
    }
}
