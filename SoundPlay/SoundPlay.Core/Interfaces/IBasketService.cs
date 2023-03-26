namespace SoundPlay.Core.Interfaces;

public interface IBasketService
{
	public Task<int> GetQuantityItems(int basketId);	
    public Task<string> GetBasketOwnerIdAsync(HttpRequest request, HttpResponse response);
	public Task TransferBasketAsync(string anonymousId, string userId);
	public Task RemoveItemFromBasketAsync(int basketItemId);
	public Task DeleteBasketAsync(int basketId);
	public Task<Basket> AddItemToBasketAsync<TModel>(string userId, int productId, int productQuantity = 1)
		where TModel : Product;
}