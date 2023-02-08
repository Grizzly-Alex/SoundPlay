namespace SoundPlay.WEB.Areas.Admin.Controllers;

//[Authorize]
[Area("Admin")]
public sealed class GuitarController : Controller
{
    private readonly IContentManager _contentManager;
    private readonly ILoggerAdapter<GuitarService>? _logger;
    private readonly IEntityService<Guitar, GuitarViewModel> _guitars;
    private readonly IRepresentationService _representationService;


	public GuitarController(
        IContentManager contentManager,
		IEntityService<Guitar, GuitarViewModel> guitars,
        IRepresentationService representationService)
    {
        _contentManager = contentManager;
        _guitars = guitars;
        _representationService = representationService;
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
			var selectCategories = await _representationService.GetSelectListAsync<GuitarCategory>();
			var selectBrands = await _representationService.GetSelectListAsync<Brand>();
			var selectColors = await _representationService.GetSelectListAsync<Color>();
			var selectGuitarShapes = await _representationService.GetSelectListAsync<GuitarShape>();
			var selectMaterials = await _representationService.GetSelectListAsync<Material>();
			var selectPickupSets = await _representationService.GetSelectListAsync<PickupSet>();
			var selectTremoloTypes = await _representationService.GetSelectListAsync<TremoloType>();

			CreateGuitarViewModel guitarForCreateViewModel = new()
            {             
                GuitarViewModel = new(), 
                Categories = selectCategories,
				Brands = selectBrands,
                Colors = selectColors,
				GuitarShapes = selectGuitarShapes,
				Soundboards = selectMaterials,
                Necks = selectMaterials,
				Fretboards = selectMaterials,
                PickupSets = selectPickupSets,
                TremoloTypes = selectTremoloTypes,
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
            var guitars = await _guitars!.GetViewModelByIdAsync(id);
			var selectCategories = await _representationService.GetSelectListAsync<GuitarCategory>();
			var selectBrands = await _representationService.GetSelectListAsync<Brand>();
			var selectColors = await _representationService.GetSelectListAsync<Color>();
			var selectGuitarShapes = await _representationService.GetSelectListAsync<GuitarShape>();
			var selectMaterials = await _representationService.GetSelectListAsync<Material>();
			var selectPickupSets = await _representationService.GetSelectListAsync<PickupSet>();
			var selectTremoloTypes = await _representationService.GetSelectListAsync<TremoloType>();


			CreateGuitarViewModel guitarForCreateViewModel = new()
            {
                GuitarViewModel = guitars,
                Categories = selectCategories,
                Brands = selectBrands,
                Colors = selectColors,
                GuitarShapes = selectGuitarShapes,
                Soundboards = selectMaterials,
                Necks = selectMaterials,
                Fretboards = selectMaterials,
                PickupSets = selectPickupSets,
                TremoloTypes = selectTremoloTypes,
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

                return RedirectToAction(nameof(Details), new { id = viewModel!.Id });
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
    public async Task<IActionResult> Details(int id)
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