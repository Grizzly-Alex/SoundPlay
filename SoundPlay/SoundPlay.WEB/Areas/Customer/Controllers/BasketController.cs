namespace SoundPlay.Web.Areas.Customer.Controllers;

[Area("Customer")]
public sealed class BasketController : Controller
{
    private readonly IBasketManager _basketManager;

    public BasketController(IBasketManager basketManager)
    {   
        _basketManager = basketManager;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var basket = _basketManager.GetBasket(HttpContext.Session);

        return View(basket);
    }


    [HttpPost]
    public async Task<IActionResult> UpdateBasket(int id, byte count)
    {
        var basket = _basketManager.GetBasket(HttpContext.Session);
        var position = await _basketManager.GetBasketPositionAsync<Guitar>(id, count);
        _basketManager.AddPositionToBasket(position);

        _basketManager.SaveBasketInSession(HttpContext.Session);

        return RedirectToAction(nameof(Index));
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteFromBasket(Guid id)
    {
        _basketManager.GetBasket(HttpContext.Session);
        _basketManager.RemovePositionFromBasket(id);
        _basketManager.SaveBasketInSession(HttpContext.Session);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult ClearBasket()
    {
        _basketManager.GetBasket(HttpContext.Session);
        _basketManager.ClearBasket();
        _basketManager.SaveBasketInSession(HttpContext.Session);

        return RedirectToAction(nameof(Index));
    }
}