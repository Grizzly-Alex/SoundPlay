namespace SoundPlay.Core.Interfaces;

public interface IBasketManager
{
	public Basket GetBasket(ISession session);
	public void SaveBasketInSession(ISession session);
	public Basket AddPositionToBasket(BasketPosition basketPosition);
	public Basket UpdateBasket(BasketPosition basketPosition);
	public Task<BasketPosition?> GetBasketPositionAsync<TModel>(int id, byte count = 1) 
		where TModel : Product;
}
