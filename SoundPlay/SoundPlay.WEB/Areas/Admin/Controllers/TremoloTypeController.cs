using Microsoft.AspNetCore.Mvc;
using SoundPlay.BLL.Interfaces;
using SoundPlay.BLL.ViewModels;

namespace SoundPlay.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public sealed class TremoloTypeController : Controller
    {
        private readonly IItemGenericService<TremoloTypeViewModel> _tremoloTypeService;

        public TremoloTypeController(IItemGenericService<TremoloTypeViewModel> tremoloTypeService)
        {
            _tremoloTypeService = tremoloTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewModels = await _tremoloTypeService.GetViewModelsAsync();
            return View(viewModels);
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TremoloTypeViewModel obj)
        {    
            if (ModelState.IsValid)
            {
				await _tremoloTypeService.CreateViewModelAsync(obj);
				return RedirectToAction("Index");
			}
            return View(obj);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
			var viewModel = await _tremoloTypeService.GetViewModelByIdAsync(id);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TremoloTypeViewModel obj)
        {
            if (ModelState.IsValid)
            {
				await _tremoloTypeService.UpdateViewModelAsync(obj);
				return RedirectToAction("Index");
			}
            return View(obj);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var viewModel = await _tremoloTypeService.GetViewModelByIdAsync(id);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TremoloTypeViewModel obj)
        {
			await _tremoloTypeService.DeleteViewModelAsync(obj);
			return RedirectToAction("Index");
		}
    }
}