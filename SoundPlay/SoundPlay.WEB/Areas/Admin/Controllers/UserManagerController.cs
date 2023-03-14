namespace SoundPlay.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class UserManagerController : Controller
{
	private readonly SignInManager<AppUser> _signInManager;
	private readonly UserManager<AppUser> _userManager;
    private readonly IUserStore<AppUser> _userStore;
    private readonly ILogger<UserManagerController> _logger;
    private readonly IMapper _mapper;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UserManagerController(
		SignInManager<AppUser> signInManager,
		UserManager<AppUser> userManager,
        IUserStore<AppUser> userStore,
        ILogger<UserManagerController> logger,
        IMapper mapper,
        RoleManager<IdentityRole> roleManager)
    {
		_signInManager = signInManager;
		_userManager = userManager;
        _userStore = userStore;
        _logger = logger;
        _mapper = mapper;
        _roleManager = roleManager;
    }

    [HttpGet]
    public async Task<IActionResult> Index(string role)
    {
        TempData["role"] = role;
		var customers = await _userManager.GetUsersInRoleAsync(role.ToString());
        return View(customers);
    }

    [HttpGet]
    public IActionResult Create()
    {
        var user = new CreateUserViewModel
        {
            RoleList = _roleManager.Roles
            .Where(i =>  i.Name != Roles.Customer.ToString())
            .Select(i => i.Name)
            .Select(i => new SelectListItem { Text = i, Value = i })
        };
        return View(user);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserViewModel userView)
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

                return RedirectToAction(nameof(Index), new {role = userView.Role});
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
        }
        return View(userView);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(string userId, string role)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user is not null)
        {
            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                _logger.LogInformation("User deleted.");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
        }
        return RedirectToAction(nameof(Index), new { role = role });
    }

    [HttpGet]
    public async Task<IActionResult> Edit(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user is null) 
        { 
            return NotFound();
        }

        var roles = await _userManager.GetRolesAsync(user);

		var userView = _mapper.Map<EditUserViewModel>(user);
        userView.Role = roles.FirstOrDefault(); 

        userView.RoleList = _roleManager.Roles
            .Where(i => i.Name != Roles.Customer.ToString())
            .Select(i => i.Name)
            .Select(i => new SelectListItem { Text = i, Value = i });

		return View(userView);
	}

    [HttpPost]
    public async Task<IActionResult> Edit(EditUserViewModel userView)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByIdAsync(userView.Id);

            if (user is not null)
            {
                user.Name= userView.Name;
                user.PhoneNumber = userView.PhoneNumber;
                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
					var roles = await _userManager.GetRolesAsync(user);
                    var role = roles.FirstOrDefault();

                    if(!role.Equals(userView.Role, StringComparison.CurrentCultureIgnoreCase))
					{
						await _userManager.RemoveFromRoleAsync(user, role);
						await _userManager.AddToRoleAsync(user, userView.Role);
						await _signInManager.RefreshSignInAsync(user);
					}

					return RedirectToAction(nameof(Index), new { role = userView.Role });
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
        }
        return View(userView);
    }
}
