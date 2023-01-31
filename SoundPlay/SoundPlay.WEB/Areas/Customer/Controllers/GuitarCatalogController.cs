namespace SoundPlay.WEB.Areas.Customer.Controllers;

[Area("Customer")]
public class GuitarCatalogController : Controller
{
	[HttpGet]
	public IActionResult ElectricGuitar()
	{
		return View();
	}

	[HttpGet]
	public IActionResult Details(int id)
	{
		return View();
	}
}
