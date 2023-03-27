namespace SoundPlay.Web.ViewModels.Basket;

public sealed class BasketItemViewModel : EntityViewModel
{
    public int ProductId { get; set; }
    public string? ProductName { get; set; }
    public decimal ProductPrice { get; set; }
    public string? ProductPictureUrl { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Quantity must be bigger than 0")]
    public int Quantity { get; set; }
    public decimal ItemPrice => ProductPrice * Quantity;
}