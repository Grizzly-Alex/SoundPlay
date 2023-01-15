using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SoundPlay.BLL.Exceptions;
using SoundPlay.BLL.Interfaces;
using SoundPlay.BLL.Services;
using SoundPlay.BLL.ViewModels;

namespace SoundPlay.WEB.Areas.Admin.Controllers
{
    //[Authorize]
    public class GuitarController : Controller
    {
        private readonly ILoggerAdapter<GuitarService>? _logger;
        private readonly IItemGenericService<GuitarViewModel>? _guitars;

        //private readonly ILoggerAdapter<GuitarService>? _logger;
        //private readonly IItemGenericService<BrandViewModel>? _brands;
        //private readonly IItemGenericService<CategoryViewModel>? _categories;
        //private readonly IItemGenericService<ColorViewModel>? _colors;
        //private readonly IItemGenericService<GuitarShapeViewModel>? _guitarShapes;
        //private readonly IItemGenericService<MaterialViewModel>? _soundBoards;
        //private readonly IItemGenericService<MaterialViewModel>? _necks;
        //private readonly IItemGenericService<GuitarShapeViewModel>? _fretBoards;
        //private readonly IItemGenericService<PickupSetViewModel>? _pickups;
        //private readonly IItemGenericService<TremoloTypeViewModel>? _tremoloTypes;
        //private readonly IItemGenericService<GuitarService>? _guitars;

        private readonly IEnumerable<BrandViewModel>? _brands;
        private readonly IEnumerable<CategoryViewModel>? _categories;
        private readonly IEnumerable<ColorViewModel>? _colors;
        private readonly IEnumerable<GuitarShapeViewModel>? _guitarShapes;
        private readonly IEnumerable<MaterialViewModel>? _soundBoards;
        private readonly IEnumerable<MaterialViewModel>? _necks;
        private readonly IEnumerable<MaterialViewModel>? _fretBoards;
        private readonly IEnumerable<PickupSetViewModel>? _pickups;
        private readonly IEnumerable<TremoloTypeViewModel>? _tremoloTypes;

        public GuitarController(
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
            _logger= logger;
            _guitars= guitars;

            //_logger= logger;
            //_brands= brands;
            //_categories= categories;
            //_colors= colors;
            //_guitarShapes= guitarShapes;
            //_materials= materials;
            //_pickups= pickups;
            //_tremoloTypes= tremoloTypes;

            _brands= brands!.GetViewModelsAsync().Result;
            _categories= categories!.GetViewModelsAsync().Result;
            _colors= colors!.GetViewModelsAsync().Result;
            _guitarShapes= guitarShapes!.GetViewModelsAsync().Result;
            _soundBoards= soundBoards!.GetViewModelsAsync().Result;
            _necks= necks!.GetViewModelsAsync().Result;
            _fretBoards= fretBoards!.GetViewModelsAsync().Result;
            _pickups= pickups!.GetViewModelsAsync().Result;
            _tremoloTypes= tremoloTypes!.GetViewModelsAsync().Result;
        }
        [HttpGet]
        public async Task<IActionResult> Index( )
        {
            try
            {
                var guitars = await _guitars!.GetViewModelsAsync();
                return View(guitars);
            }

            catch ( ObjectNotFoundException ex )
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
        public IActionResult Create()
        {
            try
            {
                GuitarForCreateViewModel guitarForCreateViewModel = new()
                {
                    GuitarViewModel=new(),
                    Brands=_brands!.Select(i => new SelectListItem {Value=i.Id.ToString(), Text=i.Name}),
                    Categories=_categories!.Select(i => new SelectListItem { Value=i.Id.ToString(), Text=i.Name }),
                    Colors=_colors!.Select(i => new SelectListItem { Value=i.Id.ToString(), Text=i.Name }),
                    GuitarShapes=_guitarShapes!.Select(i => new SelectListItem { Value=i.Id.ToString(), Text=i.Name }),
                    Soundboards=_soundBoards!.Select(i => new SelectListItem { Value=i.Id.ToString(), Text=i.Name }),
                    Necks=_necks!.Select(i => new SelectListItem { Value=i.Id.ToString(), Text=i.Name }),
                    Fretboards=_fretBoards!.Select(i => new SelectListItem { Value=i.Id.ToString(), Text=i.Name }),
                    PickupSets=_pickups!.Select(i => new SelectListItem { Value=i.Id.ToString(), Text=i.Name }),
                    TremoloTypes=_tremoloTypes!.Select(i => new SelectListItem { Value=i.Id.ToString(), Text=i.Name }),
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
        public async Task<IActionResult> Create(GuitarForCreateViewModel guitarForCreateViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var viewModel = guitarForCreateViewModel.GuitarViewModel;
                    await _guitars!.CreateViewModelAsync(viewModel!);
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
        public async Task<IActionResult> Update(int id)
        {
            try
            {
                var guitarViewModel = await _guitars!.GetViewModelByIdAsync(id);

                GuitarForCreateViewModel guitarForCreateViewModel = new()
                {
                    GuitarViewModel=guitarViewModel,
                    Brands=_brands!.Select(i => new SelectListItem { Value=i.Id.ToString(), Text=i.Name }),
                    Categories=_categories!.Select(i => new SelectListItem { Value=i.Id.ToString(), Text=i.Name }),
                    Colors=_colors!.Select(i => new SelectListItem { Value=i.Id.ToString(), Text=i.Name }),
                    GuitarShapes=_guitarShapes!.Select(i => new SelectListItem { Value=i.Id.ToString(), Text=i.Name }),
                    Soundboards=_soundBoards!.Select(i => new SelectListItem { Value=i.Id.ToString(), Text=i.Name }),
                    Necks=_necks!.Select(i => new SelectListItem { Value=i.Id.ToString(), Text=i.Name }),
                    Fretboards=_fretBoards!.Select(i => new SelectListItem { Value=i.Id.ToString(), Text=i.Name }),
                    PickupSets=_pickups!.Select(i => new SelectListItem { Value=i.Id.ToString(), Text=i.Name }),
                    TremoloTypes=_tremoloTypes!.Select(i => new SelectListItem { Value=i.Id.ToString(), Text=i.Name }),
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
        public async Task<IActionResult> Update(GuitarForCreateViewModel guitarForCreateViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var viewModel = guitarForCreateViewModel.GuitarViewModel;
                    await _guitars!.UpdateViewModelAsync(viewModel!);
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
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var guitarViewModel = await _guitars!.GetViewModelByIdAsync(id);

                GuitarForCreateViewModel guitarForCreateViewModel = new()
                {
                    GuitarViewModel=guitarViewModel,
                    Brands=_brands!.Select(i => new SelectListItem { Value=i.Id.ToString(), Text=i.Name }),
                    Categories=_categories!.Select(i => new SelectListItem { Value=i.Id.ToString(), Text=i.Name }),
                    Colors=_colors!.Select(i => new SelectListItem { Value=i.Id.ToString(), Text=i.Name }),
                    GuitarShapes=_guitarShapes!.Select(i => new SelectListItem { Value=i.Id.ToString(), Text=i.Name }),
                    Soundboards=_soundBoards!.Select(i => new SelectListItem { Value=i.Id.ToString(), Text=i.Name }),
                    Necks=_necks!.Select(i => new SelectListItem { Value=i.Id.ToString(), Text=i.Name }),
                    Fretboards=_fretBoards!.Select(i => new SelectListItem { Value=i.Id.ToString(), Text=i.Name }),
                    PickupSets=_pickups!.Select(i => new SelectListItem { Value=i.Id.ToString(), Text=i.Name }),
                    TremoloTypes=_tremoloTypes!.Select(i => new SelectListItem { Value=i.Id.ToString(), Text=i.Name }),
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
        public async Task<IActionResult> Delete(GuitarForCreateViewModel guitarForCreateViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var viewModel = guitarForCreateViewModel.GuitarViewModel;
                    await _guitars!.DeleteViewModelAsync(viewModel!);
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

        //Use without View();
        //[HttpPost]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    try
        //    {
        //        var guitarViewModel = await _guitars!.GetViewModelByIdAsync(id);
        //        await _guitars.DeleteViewModelAsync(guitarViewModel);
        //        return RedirectToAction("Index");
        //    }

        //    catch (ObjectNotFoundException ex)
        //    {
        //        _logger!.LogError(ex.Message);
        //        return NotFound(ex.Message);
        //    }

        //    catch (Exception ex)
        //    {
        //        _logger!.LogError(ex.Message);
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}
