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
            CreateGuitarViewModel guitarForCreateViewModel = new()
            {             
                GuitarViewModel = new(), 
                Categories = await _representationService.GetSelectListAsync<GuitarCategory>(),
				Brands = await _representationService.GetSelectListAsync<Brand>(),
                Colors = await _representationService.GetSelectListAsync<Color>(),
				GuitarShapes = await _representationService.GetSelectListAsync<GuitarShape>(),
				Soundboards = await _representationService.GetSelectListAsync<Material>(),
                Necks = await _representationService.GetSelectListAsync<Material>(),
				Fretboards = await _representationService.GetSelectListAsync<Material>(),
                PickupSets = await _representationService.GetSelectListAsync<PickupSet>(),
                TremoloTypes = await _representationService.GetSelectListAsync<TremoloType>(),
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
            CreateGuitarViewModel guitarForCreateViewModel = new()
            {
                GuitarViewModel = await _guitars!.GetViewModelByIdAsync(id),
				Categories = await _representationService.GetSelectListAsync<GuitarCategory>(),
				Brands = await _representationService.GetSelectListAsync<Brand>(),
				Colors = await _representationService.GetSelectListAsync<Color>(),
				GuitarShapes = await _representationService.GetSelectListAsync<GuitarShape>(),
				Soundboards = await _representationService.GetSelectListAsync<Material>(),
				Necks = await _representationService.GetSelectListAsync<Material>(),
				Fretboards = await _representationService.GetSelectListAsync<Material>(),
				PickupSets = await _representationService.GetSelectListAsync<PickupSet>(),
				TremoloTypes = await _representationService.GetSelectListAsync<TremoloType>(),
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