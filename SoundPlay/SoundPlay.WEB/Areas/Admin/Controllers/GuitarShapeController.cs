using Microsoft.AspNetCore.Mvc;
using SoundPlay.BLL.Interfaces;
using SoundPlay.BLL.ViewModels;

namespace SoundPlay.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public sealed class GuitarShapeController : Controller
    {
        private readonly IItemGenericService<GuitarShapeViewModel> _guitarShapeService;

        public GuitarShapeController(IItemGenericService<GuitarShapeViewModel> guitarShapeService)
        {
            _guitarShapeService = guitarShapeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewModels = await _guitarShapeService.GetViewModelsAsync();
            return View(viewModels);
        }
        

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GuitarShapeViewModel obj)
        {    
            if (ModelState.IsValid)
            {
				await _guitarShapeService.CreateViewModelAsync(obj);
				return RedirectToAction("Index");
			}
            return View(obj);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
			var viewModel = await _guitarShapeService.GetViewModelByIdAsync(id);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(GuitarShapeViewModel obj)
        {
            if (ModelState.IsValid)
            {
				await _guitarShapeService.UpdateViewModelAsync(obj);
				return RedirectToAction("Index");
			}
            return View(obj);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var viewModel = await _guitarShapeService.GetViewModelByIdAsync(id);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(GuitarShapeViewModel obj)
        {
			await _guitarShapeService.DeleteViewModelAsync(obj);
			return RedirectToAction("Index");
		}
    }
}