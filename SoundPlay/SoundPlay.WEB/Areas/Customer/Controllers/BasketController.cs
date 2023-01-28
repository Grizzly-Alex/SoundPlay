using Microsoft.AspNetCore.Mvc;
using SoundPlay.BLL.Interfaces;
using SoundPlay.BLL.Utility;
using SoundPlay.BLL.ViewModels.Customer;

namespace SoundPlay.WEB.Areas.Customer.Controllers
{
	[Area("Customer")]
	public sealed class BasketController : Controller
    {
        private readonly ILoggerAdapter<BasketController> _logger;

        public BasketController(ILoggerAdapter<BasketController> logger)
        {
            _logger=logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                #region Formation of a basket taking into account data from the session

                Basket basket = new();

                // getting Basket from session
                var basketFromSession = HttpContext.Session.Get<Basket>(WebConstants.BasketSession);

                // if there is a filled Basket in the session, then take the data from it    
                if (basketFromSession!=null
                    &&basketFromSession!.TotalCount>0)
                {
                    basket=basketFromSession!;
                }

                #endregion

                return View(basket);
            }

            catch (Exception ex)
            {
                _logger!.LogError(ex.Message);
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        public IActionResult Update(Guid id)
        {
            try
            {
                #region Formation of a basket taking into account data from the session

                Basket basket = new();

                // getting Basket from session
                var basketFromSession = HttpContext.Session.Get<Basket>(WebConstants.BasketSession);

                // if there is a filled Basket in the session, then take the data from it    
                if (basketFromSession!=null
                    &&basketFromSession!.TotalCount>0)
                {
                    basket=basketFromSession!;
                }

                #endregion

                var position = basket.ProductList!.First(p => p.BasketPositionId.Equals(id));
                if (position!=null) return NotFound();
                else return View(position);
            }

            catch (Exception ex)
            {
                _logger!.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(BasketPosition basketPosition)
        {
            try
            {
                #region Formation of a basket taking into account data from the session

                Basket basket = new();

                // getting Basket from session
                var basketFromSession = HttpContext.Session.Get<Basket>(WebConstants.BasketSession);

                // if there is a filled Basket in the session, then take the data from it    
                if (basketFromSession!=null
                    &&basketFromSession!.TotalCount>0)
                {
                    basket=basketFromSession!;
                }

                #endregion

                var positionForChange = basket.ProductList!.First(p => p.BasketPositionId.Equals(basketPosition.BasketPositionId));
                if (positionForChange!=null) return NotFound();
                else
                {
                    basket.ProductList!.Remove(positionForChange!);
                    basket.ProductList!.Add(basketPosition!);

                    // putting a basket with new properties into the session
                    HttpContext.Session.Set(WebConstants.BasketSession, basket);
                    return RedirectToAction(nameof(Index));
                }
            }

            catch (Exception ex)
            {
                _logger!.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteFromBasket(Guid id)
        {
            try
            {
                #region Formation of a basket taking into account data from the session

                Basket basket = new();

                // getting Basket from session
                var basketFromSession = HttpContext.Session.Get<Basket>(WebConstants.BasketSession);

                // if there is a filled Basket in the session, then take the data from it    
                if (basketFromSession!=null
                    &&basketFromSession!.TotalCount>0)
                {
                    basket=basketFromSession!;
                }

                #endregion

                var positionForDelete = basket.ProductList!.First(p => p.BasketPositionId.Equals(id));
                if (positionForDelete!=null) return NotFound();
                else
                {
                    basket.ProductList!.Remove(positionForDelete!);

                    // putting a basket with new properties into the session
                    HttpContext.Session.Set(WebConstants.BasketSession, basket);
                    return RedirectToAction(nameof(Index));
                }
            }

            catch (Exception ex)
            {
                _logger!.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult ClearBasket()
        {
            try
            {
                #region Formation of a basket taking into account data from the session

                Basket basket = new();

                // getting Basket from session
                var basketFromSession = HttpContext.Session.Get<Basket>(WebConstants.BasketSession);

                // if there is a filled Basket in the session, then take the data from it    
                if (basketFromSession!=null
                    &&basketFromSession!.TotalCount>0)
                {
                    basket=basketFromSession!;
                }

                #endregion

                basket.ProductList!.Clear();

                // putting a basket with new properties into the session
                HttpContext.Session.Set(WebConstants.BasketSession, basket);
                return RedirectToAction(nameof(Index));
            }

            catch (Exception ex)
            {
                _logger!.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }


}
