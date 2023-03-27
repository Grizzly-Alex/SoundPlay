namespace SoundPlay.Web.ViewModels.Basket;

public sealed class BasketItemViewModel : EntityViewModel
{
    public int ProductId { get; private set; }
    public string? ProductType { get; private set; }
    public string? ProductName { get; private set; }
    public decimal ProductPrice { get; private set; }
    public string? ProductPictureUrl { get; private set; }
    public string? ProductDescription { get; private set; }

    [Range(0, int.MaxValue, ErrorMessage = "Quantity must be bigger than 0")]
    public int Quantity { get; private set; }
    public decimal ItemPrice => ProductPrice * Quantity;
}