namespace SoundPlay.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class IdentityManagerController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IUserStore<AppUser> _userStore;
    //private readonly IUserEmailStore<AppUser> _emailStore;
    private readonly ILogger<IdentityManagerController> _logger;
    private readonly IMapper _mapper;
    private readonly RoleManager<IdentityRole> _roleManager;

    public IdentityManagerController(
        UserManager<AppUser> userManager,
        IUserStore<AppUser> userStore,
        //IUserEmailStore<AppUser> emailStore,
        ILogger<IdentityManagerController> logger,
        IMapper mapper,
        RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _userStore = userStore;
        //_emailStore = emailStore; 
        _logger = logger;
        _mapper = mapper;
        _roleManager = roleManager;
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
        var user = new UserViewModel
        {
            RoleList = _roleManager.Roles
            .Select(x => x.Name)
            .Select(i => new SelectListItem { Text = i, Value = i })
        };
        return View(user);
    }

    [HttpPost]
    public async Task<IActionResult> Create(UserViewModel userView)
    {
        if (ModelState.IsValid)
        {
            var user = _mapper.Map<AppUser>(userView);
            await _userStore.SetUserNameAsync(user, userView.Name, CancellationToken.None);           
            var result = await _userManager.CreateAsync(user, userView.Password);

            if (result.Succeeded)
            {
                _logger.LogInformation("User created a new account with password.");
                await _userManager.AddToRoleAsync(user, userView.Role);
            }
        }
        return RedirectToAction(nameof(Index), userView.Role);
    }
}
