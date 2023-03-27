namespace SoundPlay.Web.ViewModels.Basket;

public sealed class BasketViewModel : EntityViewModel
{
    public string? BuyerId { get; set; }
    public decimal TotalPrice => Items!.Sum(item => item.ItemPrice);
    public List<BasketItemViewModel>? Items { get; set; } = new();
}
