namespace SoundPlay.Web.Areas.Customer.Controllers;

[Area("Customer")]
public class CatalogController : Controller
{
	[HttpGet]
	public IActionResult AllCategories() => View();
	[HttpGet]
	public IActionResult GuitarsArea() => View();
	[HttpGet]
	public IActionResult DrumsArea() => View();
	[HttpGet]
	public IActionResult KeysArea() => View();
	[HttpGet]
	public IActionResult BrassArea() => View();
	[HttpGet]
	public IActionResult TraditionalArea() => View();
	[HttpGet]
	public IActionResult StudioArea() => View();
	[HttpGet]
	public IActionResult CasesArea() => View();
	[HttpGet]
	public IActionResult CablesArea() => View();
	[HttpGet]
	public IActionResult AccessoriesArea() => View();
}