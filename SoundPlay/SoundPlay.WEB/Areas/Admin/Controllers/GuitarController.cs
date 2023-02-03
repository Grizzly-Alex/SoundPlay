namespace SoundPlay.WEB.Areas.Admin.Controllers;

//[Authorize]
[Area("Admin")]
public sealed class GuitarController : Controller
{
    private readonly IContentManager _contentManager;
    private readonly ILoggerAdapter<GuitarService>? _logger;
	private readonly IEntityService<GuitarCategory, GuitarCategoryViewModel>? _category;
	private readonly IEntityService<Brand, BrandViewModel>? _brands;
    private readonly IEntityService<Color, ColorViewModel>? _colors;
    private readonly IEntityService<GuitarShape, GuitarShapeViewModel>? _guitarShapes;
    private readonly IEntityService<Material, MaterialViewModel>? _materials;
    private readonly IEntityService<PickupSet, PickupSetViewModel>? _pickups;
    private readonly IEntityService<TremoloType, TremoloTypeViewModel>? _tremoloTypes;
    private readonly IProductService<GuitarViewModel>? _guitars;


    public GuitarController(
        IContentManager contentManager,
		IEntityService<GuitarCategory, GuitarCategoryViewModel> category,
		ILoggerAdapter<GuitarService>? logger,
		IEntityService<Brand, BrandViewModel>? brands,
		IEntityService<Color, ColorViewModel>? colors,
		IEntityService<GuitarShape, GuitarShapeViewModel>? guitarShapes,
		IEntityService<Material, MaterialViewModel>? materials,
		IEntityService<PickupSet, PickupSetViewModel>? pickups,
		IEntityService<TremoloType, TremoloTypeViewModel>? tremoloTypes,
		IProductService<GuitarViewModel>? guitars)
    {
        _category = category;
        _contentManager = contentManager;
        _logger = logger;
        _guitars = guitars;
        _brands = brands;
        _colors = colors;
        _guitarShapes = guitarShapes;
        _materials = materials;
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
            var categoryList = await _category!.GetViewModelsAsync(); 
            var brandList = await _brands!.GetViewModelsAsync();
            var colorList = await _colors!.GetViewModelsAsync();
            var guitarShapeList = await _guitarShapes!.GetViewModelsAsync();
            var soundBoardsList = await _materials!.GetViewModelsAsync();
            var neckList = await _materials!.GetViewModelsAsync();
            var fretBoard = await _materials!.GetViewModelsAsync();
            var pickupList = await _pickups!.GetViewModelsAsync();
            var tremoloList = await _tremoloTypes!.GetViewModelsAsync();

            CreateGuitarViewModel guitarForCreateViewModel = new()
            {             
                GuitarViewModel = new(), 
                Categories = categoryList!.OrderBy(i => i.Name).Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Name }),
				Brands = brandList!.OrderBy(i => i.Name).Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Name }),
                Colors = colorList!.OrderBy(i => i.Name).Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Name }),
                GuitarShapes = guitarShapeList!.OrderBy(i => i.Name).Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Name }),
                Soundboards = soundBoardsList!.OrderBy(i => i.Name).Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Name }),
                Necks = neckList!.OrderBy(i => i.Name).Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Name }),
                Fretboards = fretBoard!.OrderBy(i => i.Name).Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Name }),
                PickupSets = pickupList!.OrderBy(i => i.Name).Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Name }),
                TremoloTypes = tremoloList!.OrderBy(i => i.Name).Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Name }),
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
	public async Task<IActionResult> Create(CreateGuitarViewModel guitarForCreateViewModel)
    {
		try
        {
			var files = HttpContext.Request.Form.Files;

			if (files.Count > 0)
            {
				_contentManager.UploadFiles(HttpContext.Request.Form.Files, WebConstants.GuitarsImages);
				guitarForCreateViewModel.GuitarViewModel!.PictureUrl = _contentManager.NameFiles.FirstOrDefault();
			}
		
			if (ModelState.IsValid)
            {                   
                await _guitars!.CreateViewModelAsync(guitarForCreateViewModel.GuitarViewModel!);
                return RedirectToAction(nameof(Index));
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
			var categoryList = await _category!.GetViewModelsAsync();
			var guitarViewModel = await _guitars!.GetViewModelByIdAsync(id);
            var brandList = await _brands!.GetViewModelsAsync();
            var colorList = await _colors!.GetViewModelsAsync();
            var guitarShapeList = await _guitarShapes!.GetViewModelsAsync();
            var soundBoardsList = await _materials!.GetViewModelsAsync();
            var neckList = await _materials!.GetViewModelsAsync();
            var fretBoard = await _materials!.GetViewModelsAsync();
            var pickupList = await _pickups!.GetViewModelsAsync();
            var tremoloList = await _tremoloTypes!.GetViewModelsAsync();

            CreateGuitarViewModel guitarForCreateViewModel = new()
            {
                GuitarViewModel = guitarViewModel,
				Categories = categoryList!.OrderBy(i => i.Name).Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Name }),
				Brands = brandList!.OrderBy(i => i.Name).Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Name }),
                Colors = colorList!.OrderBy(i => i.Name).Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Name }),
                GuitarShapes = guitarShapeList!.OrderBy(i => i.Name).Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Name }),
                Soundboards = soundBoardsList!.OrderBy(i => i.Name).Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Name }),
                Necks = neckList!.OrderBy(i => i.Name).Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Name }),
                Fretboards = fretBoard!.OrderBy(i => i.Name).Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Name }),
                PickupSets = pickupList!.OrderBy(i => i.Name).Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Name }),
                TremoloTypes = tremoloList!.OrderBy(i => i.Name).Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Name }),
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
    public async Task<IActionResult> Edit(CreateGuitarViewModel guitarForCreateViewModel)
    {
        try
        {
            var files = HttpContext.Request.Form.Files;

            if (files.Count > 0)
            {
				_contentManager.RemoveFile(WebConstants.GuitarsImages, guitarForCreateViewModel.GuitarViewModel.PictureUrl);
				_contentManager.UploadFiles(files, WebConstants.GuitarsImages);
                guitarForCreateViewModel.GuitarViewModel.PictureUrl = _contentManager.NameFiles.FirstOrDefault();              
			}		

			if (ModelState.IsValid)
            {
                var viewModel = guitarForCreateViewModel.GuitarViewModel;
                await _guitars!.UpdateViewModelAsync(viewModel!);

                return RedirectToAction(nameof(FullInfo), new { id = viewModel!.Id });
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

			_contentManager.RemoveFile(WebConstants.GuitarsImages, guitarViewModel.PictureUrl);

            await _guitars.DeleteViewModelAsync(guitarViewModel);
            return RedirectToAction(nameof(Index));
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