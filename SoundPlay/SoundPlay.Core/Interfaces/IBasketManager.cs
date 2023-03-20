namespace SoundPlay.Core.Interfaces;

public interface IBasketManager
{
    public void ClearBasket();
	public void SaveBasketInSession(ISession session);
	public Basket? GetBasket(ISession session);
    public Basket? UpdateBasket(BasketPosition basketPosition);
	public BasketPosition? AddPositionToBasket(BasketPosition basketPosition);
    public BasketPosition? RemovePositionFromBasket(Guid id);
    public Task<BasketPosition?> GetBasketPositionAsync<TModel>(int id, byte count = 1) 
		where TModel : Product;
}