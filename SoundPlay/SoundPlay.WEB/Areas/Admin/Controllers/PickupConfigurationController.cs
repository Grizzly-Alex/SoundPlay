using Microsoft.AspNetCore.Mvc;
using SoundPlay.BLL.Interfaces;
using SoundPlay.BLL.ViewModels;

namespace SoundPlay.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public sealed class PickupConfigurationController:Controller
    {
        private readonly IItemGenericService<PickupConfigurationViewModel> _pickupConfigurationService;

        public PickupConfigurationController(IItemGenericService<PickupConfigurationViewModel> pickupConfigurationService)
        {
            _pickupConfigurationService = pickupConfigurationService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewModels = await _pickupConfigurationService.GetViewModelsAsync();
            return View(viewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PickupConfigurationViewModel obj)
        {
            if (ModelState.IsValid)
            {
                await _pickupConfigurationService.CreateViewModelAsync(obj);
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var viewModel = await _pickupConfigurationService.GetViewModelByIdAsync(id);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PickupConfigurationViewModel obj)
        {
            if (ModelState.IsValid)
            {
                await _pickupConfigurationService.UpdateViewModelAsync(obj);
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var viewModel = await _pickupConfigurationService.GetViewModelByIdAsync(id);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(PickupConfigurationViewModel obj)
        {
            await _pickupConfigurationService.DeleteViewModelAsync(obj);
            return RedirectToAction("Index");
        }
    }
}
