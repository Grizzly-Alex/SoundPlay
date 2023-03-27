namespace SoundPlay.Web.Interfaces;

public interface IBasketViewModelService
{
    Task<BasketViewModel> GetBasketForUser(string userId);
    Task<int> CountTotalBasketItems(string userId);
}
