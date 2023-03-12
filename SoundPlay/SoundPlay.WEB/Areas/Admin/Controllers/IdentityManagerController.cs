namespace SoundPlay.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class IdentityManagerController : Controller
{
    private readonly ILogger<IdentityManagerController> _logger;
    private readonly UserManager<AppUser> _userManager;

    public IdentityManagerController(
        UserManager<AppUser> userManager,
        ILogger<IdentityManagerController> logger)
    {
        _userManager = userManager;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Index(Roles role)
    {
        ViewData["role"] = role;
        var customers = await _userManager.GetUsersInRoleAsync(role.ToString());
        return View(customers);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(string returnUrl = null)
    {      
        return View();
    }
}
