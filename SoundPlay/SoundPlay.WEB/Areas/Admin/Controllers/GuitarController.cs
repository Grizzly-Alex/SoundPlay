using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SoundPlay.BLL.Exceptions;
using SoundPlay.BLL.Interfaces;
using SoundPlay.BLL.Services;
using SoundPlay.BLL.ViewModels;

namespace SoundPlay.WEB.Areas.Admin.Controllers
{
	//[Authorize]
	[Area("Admin")]
	public sealed class GuitarController : Controller
    {
        private readonly IContentLoader _contentLoader;
        private readonly ILoggerAdapter<GuitarService>? _logger;
        private readonly IItemGenericService<GuitarViewModel>? _guitars;
        private readonly IItemGenericService<BrandViewModel>? _brands;
        private readonly IItemGenericService<CategoryViewModel>? _categories;
        private readonly IItemGenericService<ColorViewModel>? _colors;
        private readonly IItemGenericService<GuitarShapeViewModel>? _guitarShapes;
        private readonly IItemGenericService<MaterialViewModel>? _soundBoards;
        private readonly IItemGenericService<MaterialViewModel>? _necks;
        private readonly IItemGenericService<MaterialViewModel>? _fretBoards;
        private readonly IItemGenericService<PickupSetViewModel>? _pickups;
        private readonly IItemGenericService<TremoloTypeViewModel>? _tremoloTypes;


        public GuitarController(
            IContentLoader contentLoader,
            ILoggerAdapter<GuitarService>? logger,
            IItemGenericService<BrandViewModel>? brands,
            IItemGenericService<CategoryViewModel>? categories,
            IItemGenericService<ColorViewModel>? colors,
            IItemGenericService<GuitarShapeViewModel>? guitarShapes,
            IItemGenericService<MaterialViewModel>? soundBoards,
            IItemGenericService<MaterialViewModel>? necks,
            IItemGenericService<MaterialViewModel>? fretBoards,
            IItemGenericService<PickupSetViewModel>? pickups,
            IItemGenericService<TremoloTypeViewModel>? tremoloTypes,
            IItemGenericService<GuitarViewModel>? guitars)
        {
            _contentLoader = contentLoader;
            _logger = logger;
            _guitars = guitars;
            _brands = brands;
            _categories = categories;
            _colors = colors;
            _guitarShapes = guitarShapes;
            _soundBoards = soundBoards;
            _necks = necks;
            _fretBoards = fretBoards;
            _pickups = pickups;
            _tremoloTypes = tremoloTypes;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var guitars = await _guitars!.GetViewModelsAsync();
                return View(guitars);
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
        public async Task<IActionResult> Create()
        {
            try
            {
                var brandList = await _brands!.GetViewModelsAsync();
                var categoryList = await _categories!.GetViewModelsAsync();
                var colorList = await _colors!.GetViewModelsAsync();
                var guitarShapeList = await _guitarShapes!.GetViewModelsAsync();
                var soundBoardsList = await _soundBoards!.GetViewModelsAsync();
                var neckList = await _necks!.GetViewModelsAsync();
                var fretBoard = await _fretBoards!.GetViewModelsAsync();
                var pickupList = await _pickups!.GetViewModelsAsync();
                var tremoloList = await _tremoloTypes!.GetViewModelsAsync();

                GuitarForCreateViewModel guitarForCreateViewModel = new()
                {
                    GuitarViewModel=new(),
                    Brands = brandList!.Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Name }),
                    Categories = categoryList!.Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Name }),
                    Colors = colorList!.Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Name }),
                    GuitarShapes = guitarShapeList!.Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Name }),
                    Soundboards = soundBoardsList!.Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Name }),
                    Necks = neckList!.Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Name }),
                    Fretboards = fretBoard!.Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Name }),
                    PickupSets = pickupList!.Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Name }),
                    TremoloTypes = tremoloList!.Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Name }),
                };

                return View(guitarForCreateViewModel);
            }

            catch (Exception ex)
            {
                _logger!.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(GuitarForCreateViewModel guitarForCreateViewModel)
        {
			try
            {
				_contentLoader.UploadFile(HttpContext.Request.Form.Files, @"/images/products/guitars");
				guitarForCreateViewModel.GuitarViewModel.PictureUrl = _contentLoader.FileUrl;
		
				if (ModelState.IsValid)
                {
                    
                    await _guitars!.CreateViewModelAsync(guitarForCreateViewModel.GuitarViewModel!);
                    return RedirectToAction("Index");
                }

				else return View(guitarForCreateViewModel);
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
                var guitarViewModel = await _guitars!.GetViewModelByIdAsync(id);
                var brandList = await _brands!.GetViewModelsAsync();
                var categoryList = await _categories!.GetViewModelsAsync();
                var colorList = await _colors!.GetViewModelsAsync();
                var guitarShapeList = await _guitarShapes!.GetViewModelsAsync();
                var soundBoardsList = await _soundBoards!.GetViewModelsAsync();
                var neckList = await _necks!.GetViewModelsAsync();
                var fretBoard = await _fretBoards!.GetViewModelsAsync();
                var pickupList = await _pickups!.GetViewModelsAsync();
                var tremoloList = await _tremoloTypes!.GetViewModelsAsync();

                GuitarForCreateViewModel guitarForCreateViewModel = new()
                {
                    GuitarViewModel = guitarViewModel,
                    Brands = brandList!.Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Name }),
                    Categories = categoryList!.Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Name }),
                    Colors = colorList!.Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Name }),
                    GuitarShapes = guitarShapeList!.Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Name }),
                    Soundboards = soundBoardsList!.Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Name }),
                    Necks = neckList!.Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Name }),
                    Fretboards = fretBoard!.Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Name }),
                    PickupSets = pickupList!.Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Name }),
                    TremoloTypes = tremoloList!.Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Name }),
                };

                return View(guitarForCreateViewModel);
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(GuitarForCreateViewModel guitarForCreateViewModel)
        {
            try
            {
                _contentLoader.RemoveFile(@"\images\products\guitars", guitarForCreateViewModel.GuitarViewModel.PictureUrl);
				_contentLoader.UploadFile(HttpContext.Request.Form.Files, @"\images\products\guitars");
				guitarForCreateViewModel.GuitarViewModel.PictureUrl = _contentLoader.FileUrl;


				if (ModelState.IsValid)
                {
                    var viewModel = guitarForCreateViewModel.GuitarViewModel;
                    await _guitars!.UpdateViewModelAsync(viewModel!);

                    return RedirectToAction("FullInfo", new { id = viewModel!.Id });
                }

                else return RedirectToAction();
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
				var guitarViewModel = await _guitars!.GetViewModelByIdAsync(id);

				_contentLoader.RemoveFile(@"/images/products/guitars", guitarViewModel.PictureUrl);

                await _guitars.DeleteViewModelAsync(guitarViewModel);
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

        [HttpGet]
        public async Task<IActionResult> FullInfo(int id)
        {
            try
            {
                var guitarViewModel = await _guitars!.GetViewModelByIdAsync(id);
                return View(guitarViewModel);
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
