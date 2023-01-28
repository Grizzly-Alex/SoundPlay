using Microsoft.AspNetCore.Mvc;

namespace SoundPlay.WEB.Areas.Customer.Controllers
{
	[Area("Customer")]
	public class CatalogController : Controller
	{
		[HttpGet]
		public IActionResult AllCategories() => View();
		[HttpGet]
		public IActionResult Guitars() => View();
		[HttpGet]
		public IActionResult Drums() => View();
		[HttpGet]
		public IActionResult Keys() => View();
		[HttpGet]
		public IActionResult Brass() => View();
		[HttpGet]
		public IActionResult Traditional() => View();
		[HttpGet]
		public IActionResult Studio() => View();
		[HttpGet]
		public IActionResult Cases() => View();
		[HttpGet]
		public IActionResult Cables() => View();
		[HttpGet]
		public IActionResult Accessories() => View();
	}
}
