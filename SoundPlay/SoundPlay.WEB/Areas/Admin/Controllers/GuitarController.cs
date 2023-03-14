namespace SoundPlay.Web.Areas.Admin.Controllers;

//[Authorize]
[Area("Admin")]
public sealed class GuitarController : Controller
{
    private readonly IContentManager _contentManager;
    private readonly IViewModelService<Guitar, GuitarViewModel> _guitars;
    private readonly IUnitOfWork _unitOfWork;

	public GuitarController(
        IContentManager contentManager,
        IViewModelService<Guitar, GuitarViewModel> guitars,
        IUnitOfWork unitOfWork)
    {
        _contentManager = contentManager;
        _guitars = guitars;
        _unitOfWork = unitOfWork;
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
        var categories = await _unitOfWork.GetRepository<GuitarCategory>().GetAllAsync();
        var brands = await _unitOfWork.GetRepository<Brand>().GetAllAsync();
        var colors = await _unitOfWork.GetRepository<Color>().GetAllAsync();
        var shapes = await _unitOfWork.GetRepository<GuitarShape>().GetAllAsync();
        var materials = await _unitOfWork.GetRepository<Material>().GetAllAsync();
        var pickupSets = await _unitOfWork.GetRepository<PickupSet>().GetAllAsync();
        var tremoloTypes = await _unitOfWork.GetRepository<TremoloType>().GetAllAsync();

        CreateGuitarViewModel guitarForCreateViewModel = new(
            new GuitarViewModel(),
            categories.ToSelectListItems(),
            brands.ToSelectListItems(),
            colors.ToSelectListItems(),
            shapes.ToSelectListItems(),
            materials.ToSelectListItems(),
            pickupSets.ToSelectListItems(),
            tremoloTypes.ToSelectListItems());

        return View(guitarForCreateViewModel);
    }

    [HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Create(CreateGuitarViewModel guitarForCreateViewModel)
    {
        var files = HttpContext.Request.Form.Files;

        if (files.Count > 0)
        {
            _contentManager.UploadFiles(HttpContext.Request.Form.Files, Constants.GuitarsImages);
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
        var categories = await _unitOfWork.GetRepository<GuitarCategory>().GetAllAsync();
        var brands = await _unitOfWork.GetRepository<Brand>().GetAllAsync();
        var colors = await _unitOfWork.GetRepository<Color>().GetAllAsync();
        var shapes = await _unitOfWork.GetRepository<GuitarShape>().GetAllAsync();
        var materials = await _unitOfWork.GetRepository<Material>().GetAllAsync();
        var pickupSets = await _unitOfWork.GetRepository<PickupSet>().GetAllAsync();
        var tremoloTypes = await _unitOfWork.GetRepository<TremoloType>().GetAllAsync();


        CreateGuitarViewModel guitarForCreateViewModel = new(
            guitars,
            categories.ToSelectListItems(),
            brands.ToSelectListItems(),
            colors.ToSelectListItems(),
            shapes.ToSelectListItems(),
            materials.ToSelectListItems(),
            pickupSets.ToSelectListItems(),
            tremoloTypes.ToSelectListItems());


        return View(guitarForCreateViewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(CreateGuitarViewModel guitarForCreateViewModel)
    {
        var files = HttpContext.Request.Form.Files;

        if (files.Count > 0)
        {
            _contentManager.RemoveFile(Constants.GuitarsImages, guitarForCreateViewModel.GuitarViewModel.PictureUrl);
            _contentManager.UploadFiles(files, Constants.GuitarsImages);
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

        _contentManager.RemoveFile(Constants.GuitarsImages, guitarViewModel.PictureUrl);

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