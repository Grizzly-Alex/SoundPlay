namespace SoundPlay.WEB.Areas.Admin.Controllers;

//[Authorize]
[Area("Admin")]
public sealed class GuitarController : Controller
{
    private readonly IContentManager _contentManager;
    private readonly ILogger<GuitarService>? _logger;
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
        var guitars = await _guitars!.GetViewModelsAsync();
        return View(guitars);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
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

    [HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Create(CreateGuitarViewModel guitarForCreateViewModel)
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

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
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

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(CreateGuitarViewModel guitarForCreateViewModel)
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

    [HttpPost]
	public async Task<IActionResult> Delete(int id)
    {
        var guitarViewModel = await _guitars!.GetViewModelByIdAsync(id);

        _contentManager.RemoveFile(WebConstants.GuitarsImages, guitarViewModel.PictureUrl);

        await _guitars.DeleteViewModelAsync(guitarViewModel);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var guitarViewModel = await _guitars!.GetViewModelByIdAsync(id);
        return View(guitarViewModel);
    }
}