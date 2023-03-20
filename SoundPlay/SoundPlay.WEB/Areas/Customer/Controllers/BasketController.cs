namespace SoundPlay.Web.Areas.Customer.Controllers;

[Area("Customer")]
public sealed class BasketController : Controller
{
    private readonly ILogger<BasketController> _logger;

    public BasketController(ILogger<BasketController> logger)
    {   
        _logger=logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
        #region Formation of a basket taking into account data from the session

        Basket basket = new();

        // getting Basket from session
        //var basketFromSession = HttpContext.Session.Get<Basket>(Constants.BasketSession);

        // if there is a filled Basket in the session, then take the data from it    
        //if (basketFromSession!=null
        //    &&basketFromSession!.TotalCount > 0)
        //{
        //    basket=basketFromSession!;
        //}

        #endregion

        return View(basket);

    }

    [HttpGet]
    public IActionResult Update(Guid id)
    {
        #region Formation of a basket taking into account data from the session

        Basket basket = new();

        // getting Basket from session
        //var basketFromSession = HttpContext.Session.Get<Basket>(Constants.BasketSession);

        // if there is a filled Basket in the session, then take the data from it    
        //if (basketFromSession is not null && basketFromSession!.TotalCount>0)
        //{
        //    basket=basketFromSession!;
        //}

        #endregion

        var position = basket.ProductList!.First(p => p.PositionId.Equals(id));
        if (position is not null) return NotFound();
        else return View(position);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Update(BasketPosition basketPosition)
    {
        #region Formation of a basket taking into account data from the session

        Basket basket = new();

        // getting Basket from session
        //var basketFromSession = HttpContext.Session.Get<Basket>(Constants.BasketSession);

        // if there is a filled Basket in the session, then take the data from it    
        //if (basketFromSession is not null && basketFromSession!.TotalCount>0)
        //{
        //    basket = basketFromSession!;
        //}

        #endregion

        var positionForChange = basket.ProductList!.First(p => p.PositionId.Equals(basketPosition.PositionId));
        if (positionForChange is null) return NotFound();
        else
        {
            basket.ProductList!.Remove(positionForChange!);
            basket.ProductList!.Add(basketPosition!);

            // putting a basket with new properties into the session
            //HttpContext.Session.Set(Constants.BasketSession, basket);
            return RedirectToAction(nameof(Index));
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteFromBasket(Guid id)
    {
        #region Formation of a basket taking into account data from the session

        Basket basket = new();

        // getting Basket from session
        //var basketFromSession = HttpContext.Session.Get<Basket>(Constants.BasketSession);

        // if there is a filled Basket in the session, then take the data from it    
        //if (basketFromSession is not null && basketFromSession!.TotalCount > 0)
        //{
        //    basket=basketFromSession!;
        //}

        #endregion

        var positionForDelete = basket.ProductList!.First(p => p.PositionId.Equals(id));
        if (positionForDelete is not null) return NotFound();
        else
        {
            basket.ProductList!.Remove(positionForDelete!);

            // putting a basket with new properties into the session
            //HttpContext.Session.Set(Constants.BasketSession, basket);
            return RedirectToAction(nameof(Index));
        }
    }

    [HttpGet]
    public IActionResult ClearBasket()
    {
        #region Formation of a basket taking into account data from the session

        Basket basket = new();

        // getting Basket from session
        //var basketFromSession = HttpContext.Session.Get<Basket>(Constants.BasketSession);

        // if there is a filled Basket in the session, then take the data from it    
        //if (basketFromSession is not null && basketFromSession!.TotalCount > 0)
        //{
        //    basket=basketFromSession!;
        //}

        #endregion

        basket.ProductList!.Clear();

        // putting a basket with new properties into the session
        //HttpContext.Session.Set(Constants.BasketSession, basket);
        return RedirectToAction(nameof(Index));
    }
}