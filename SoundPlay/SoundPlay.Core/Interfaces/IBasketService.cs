namespace SoundPlay.Core.Interfaces;

public interface IBasketService
{
	public Task TransferBasketAsync(string anonymousId, string userId);
	public Task<Basket> AddItemToBasket(string userId, int productId, decimal price, string productType, int quantity = 1);
	public Task<Basket> SetQuantities(int basketId, Dictionary<string, int> quantities);
	public Task DeleteBasketAsync(int basketId);
}