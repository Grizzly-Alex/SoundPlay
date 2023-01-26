using Microsoft.AspNetCore.Mvc;

namespace SoundPlay.WEB.Areas.Customer.Controllers
{
	public class CatalogController : Controller
	{
		public IActionResult AllCategories() => View();

		public IActionResult Guitars() => View();

		public IActionResult Drums() => View();

		public IActionResult Keys() => View();

		public IActionResult Brass() => View();

		public IActionResult Traditional() => View();

		public IActionResult Studio() => View();

		public IActionResult Cases() => View();

		public IActionResult Cables() => View();

		public IActionResult Accessories() => View();
	}
}
