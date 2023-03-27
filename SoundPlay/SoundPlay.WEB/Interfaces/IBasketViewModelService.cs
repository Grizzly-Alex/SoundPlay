namespace SoundPlay.Web.Interfaces;

public interface IBasketViewModelService
{
    Task<BasketViewModel> GetBasketForUser(string userName);
    Task<int> CountTotalBasketItems(string username);
}
