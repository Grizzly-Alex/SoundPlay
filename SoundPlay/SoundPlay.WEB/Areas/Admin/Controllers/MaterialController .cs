using Microsoft.AspNetCore.Mvc;
using SoundPlay.BLL.Interfaces;
using SoundPlay.BLL.ViewModels;

namespace SoundPlay.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MaterialController : Controller
    {
        private readonly IItemGenericService<MaterialViewModel> _materialService;

        public MaterialController(IItemGenericService<MaterialViewModel> materialService)
        {
            _materialService = materialService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewModels = await _materialService.GetViewModelsAsync();
            return View(viewModels);
        }
        

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MaterialViewModel obj)
        {    
            if (ModelState.IsValid)
            {
				await _materialService.CreateViewModelAsync(obj);
				return RedirectToAction("Index");
			}
            return View(obj);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
			var viewModel = await _materialService.GetViewModelByIdAsync(id);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MaterialViewModel obj)
        {
            if (ModelState.IsValid)
            {
				await _materialService.UpdateViewModelAsync(obj);
				return RedirectToAction("Index");
			}
            return View(obj);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var viewModel = await _materialService.GetViewModelByIdAsync(id);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(MaterialViewModel obj)
        {
			await _materialService.DeleteViewModelAsync(obj);
			return RedirectToAction("Index");
		}
    }
}